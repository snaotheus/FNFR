using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;



namespace FNFR2
{
    class FileSearchThing
    {
        private SearchParameters searchParameters; // Contains everything for the search
        private SearchResults searchResults;       // Contains the search results
        private bool Searched = false;             // Tells me if I've already done this search.
        private bool ReplacePreviewed = false;     // Tells me if I've already filled the RenamedFiles collection.

        // Lets outsiders access the search results.
        public SearchResults Results { get { return searchResults; } }

        public FileSearchThing()
        {
            searchParameters = new SearchParameters();
            searchResults = new SearchResults();
        }

        public FileSearchThing(SearchParameters mSearchParameters)
        {
            searchParameters = mSearchParameters;
            searchResults = new SearchResults();
        }

        // Search. Pretty easy to understand.
        // Does not perform any replacements whatsoever.
        // Only searches if it hasn't searched yet.
        public void Search()
        {
            if (!Searched)
            {
                searchResults = new SearchResults(); // starting from scratch.
                getDirectories();
                getFiles();
                Searched = true;
                ReplacePreviewed = false;
                if (searchParameters.FindThisString == searchParameters.ReplacementString)
                {
                    // Why go through the work if the results are indistinguishable from the preconditions?
                    searchResults.AddRenamedFiles(searchResults.FileNames);
                    ReplacePreviewed = true;
                }
            }
        }


        // First search, then fill the ReplacedFileNames with what the filenames would become.
        public void PreviewReplace()
        {
            Search();
            if (!ReplacePreviewed)
            {
                FindAndReplace(false);
            }
        }

        // First search, then actually change the file names.
        public void Replace()
        {
            Search();
            FindAndReplace(true);
        }

        // Performs the file name replacements if ModifyFiles = TRUE.
        // Otherwise, it just fills the RenamedFiles collection with what the replacement would actually do.
        // This is designed to be somewhat safe: if I try to replace "a" with "aa", it does NOT get into an infinite loop.
        // It only replaces characters in the original file name, not in the modified string name.
        private void FindAndReplace(bool ModifyFiles)
        {
            if (searchParameters.FindThisString.Length == 0)
            {
                return; // No replacement to do. Why bother.
            }

            if (!ModifyFiles && ReplacePreviewed)
            {
                return; // Already done the work. Why do it again?
            }

            foreach (string ThisFile in searchResults.FileNames)
            {
                string Path = ExtractPath(ThisFile);         // get just the path portion of the filename
                string ThisFileName = ExtractFile(ThisFile); // get just the filename portion of the filename
                int StartSearchAt = 0;
                bool StillContainsHits = true;

                // Moves through the string from left to right, replacing as it goes.
                while (StillContainsHits)
                {
                    string AlreadySearched = ThisFileName.Substring(0, StartSearchAt);
                    string SearchThisPart = ThisFileName.Substring(StartSearchAt);
                    int FirstHitLocation = 0;
                    if (searchParameters.CaseSensitive)
                    {
                        FirstHitLocation = SearchThisPart.IndexOf(searchParameters.FindThisString);
                    }
                    else
                    {
                        FirstHitLocation = SearchThisPart.ToLower().IndexOf(searchParameters.FindThisString.ToLower());
                    }

                    AlreadySearched += SearchThisPart.Substring(0, FirstHitLocation);
                    AlreadySearched += searchParameters.ReplacementString;
                    SearchThisPart = SearchThisPart.Substring(FirstHitLocation + searchParameters.FindThisString.Length);

                    StartSearchAt = AlreadySearched.Length;
                    if (searchParameters.CaseSensitive)
                    {
                        StillContainsHits = SearchThisPart.Contains(searchParameters.FindThisString);
                    }
                    else
                    {
                        StillContainsHits = SearchThisPart.ToLower().Contains(searchParameters.FindThisString.ToLower());
                    }
                    ThisFileName = AlreadySearched + SearchThisPart;
                }

                if (ModifyFiles)
                {
                    File.Move(ThisFile, Path + ThisFileName);
                }
                searchResults.AddRenamedFile(Path + ThisFileName);
            }
            if (ModifyFiles)
            {
                // changing file names invalidates search results.
                searchResults.ClearFileNames();
                Searched = false;
            }
            ReplacePreviewed = true;
        }

        // getDirectories obeys the Recursive property of the search parameters
        // and fills AllowedDirectories and BannedDirectories
        //
        // There is some risk here because I'm manually manipulating my iterator
        // in the string collection under the assumption that it will be a completely 
        // linear progression. I can't guarantee that's true, but I don't care right now.
        // I'm manually manipulating my iterator because I don't know how the "foreach"
        // style loop will handle a changing MyStringCollection.
        private void getDirectories()
        {
            searchResults.AddAllowedDirectory(searchParameters.BaseDirectory);

            if (searchParameters.Recursive)
            {
                int CurrentEntry = 0;
                while (CurrentEntry < searchResults.AllowedDirectories.Count)
                {
                    try
                    {
                        string[] newPathList = Directory.GetDirectories(searchResults.AllowedDirectories[CurrentEntry]);
                        searchResults.AddAllowedDirectories(newPathList);
                        CurrentEntry++;
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        searchResults.AddBannedDirectory(searchResults.AllowedDirectories[CurrentEntry]);
                        searchResults.AllowedDirectories.RemoveAt(CurrentEntry);
                    }
                }
            }
        }

        // updates search results to contain all files in all allowed directories
        // that meet the requirements
        private void getFiles()
        {
            foreach (string ThisDirectory in searchResults.AllowedDirectories)
            {
                foreach (string ThisFileFilter in searchParameters.FileFilters)
                {
                    string[] ThisBatch = Directory.GetFiles(ThisDirectory, ThisFileFilter);

                    foreach (string ThisFile in ThisBatch)
                    {
                        if (MeetsRequirements(ThisFile))
                        {
                            searchResults.AddFileName(ThisFile);
                        }
                    }
                }
            }
        }


        // MeetsRequirements tells you whether or not the file name contains the search string,
        // contains all of the required strings, and does not contain any of the disallowed strings.
        private bool MeetsRequirements(string FileName)
        {
            string FileNameOnly = ExtractFile(FileName);
            if (!searchParameters.CaseSensitive)
            {
                FileNameOnly = FileNameOnly.ToLower();
            }

            // First test: Filename must contain the string to replace (if there is a string to replace)
            if (searchParameters.FindThisString.Length > 0)
            {
                if (!FileNameOnly.Contains(searchParameters.FindThisString))
                {
                    return false; // failed the test
                }
            }
            // Second test: Filename must contain all of the strings specified as necessary
            foreach (string MustContainThis in searchParameters.ContainsAll)
            {
                if (MustContainThis.Length > 0)
                {
                    if (!FileNameOnly.Contains(MustContainThis))
                    {
                        return false; // failed the test
                    }
                }
            }
            // Third test: Filename must NOT contain any of the strings specied as unwanted
            foreach (string MustNotContainThis in searchParameters.ContainsNone)
            {
                if (MustNotContainThis.Length > 0)
                {
                    if (FileNameOnly.Contains(MustNotContainThis))
                    {
                        return false; // failed the test
                    }
                }
            }
            // Passed all the tests, so...
            return true;
        }

        // ExtractFile removes the path information from a file name and gives you just the file...
        // i.e. "C:\folder\file.txt" would return "file.txt"
        private string ExtractFile(string LongFileName)
        {
            int lastSlashIndex = LongFileName.LastIndexOf("\\");
            return LongFileName.Substring(lastSlashIndex + 1);
        }

        // Take a long file name, return the path portion of it.
        private string ExtractPath(string LongFileName)
        {
            int lastSlashIndex = LongFileName.LastIndexOf("\\");
            return LongFileName.Substring(0, lastSlashIndex + 1);
        }

        // Take a long file name and strip off the path portion of it.
        public bool UsesTheseParameters(SearchParameters NewSearchParameters)
        {
            return searchParameters.IsIdenticalTo(NewSearchParameters);
        }
    }
}
