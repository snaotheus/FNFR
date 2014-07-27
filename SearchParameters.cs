using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.IO;

namespace FNFR2
{
    class SearchParameters
    {
        public string BaseDirectory = "C:\\";
        public MyStringCollection FileFilters = new MyStringCollection();
        public MyStringCollection ContainsAll = new MyStringCollection();
        public MyStringCollection ContainsNone = new MyStringCollection();
        public string FindThisString = "";
        public string ReplacementString = "";
        public bool Recursive = false;
        public bool CaseSensitive = true;

        public SearchParameters()
        {
        }


        // This does all the boring work of splitting strings by the 
        // separator character and loading the string collections
        public SearchParameters(string mBaseDirectory, string FileFilterString, string ContainsAllString, string ContainsNoneString, string Separator, string mFindThisString, string mReplacementString, bool mRecursive, bool mCaseSensitive)
        {
            Recursive = mRecursive;
            CaseSensitive = mCaseSensitive;
            
            BaseDirectory = mBaseDirectory;
            FindThisString = mFindThisString;
            ReplacementString = mReplacementString;

            if (!CaseSensitive)
            {
                FindThisString = FindThisString.ToLower();
            }

            ReplacementString = mReplacementString;

            if (FileFilterString.Length > 0)
            {
                string[] FilterArray = FileFilterString.Split(Separator.ToCharArray()[0]);
                foreach (string thisfilter in FilterArray)
                {
                    if (!FileFilters.Contains(thisfilter))
                    {
                        FileFilters.Add(thisfilter);
                    }
                }
            }
            else
            {
                FileFilters.Add("*");
            }
            if (ContainsAllString.Length > 0)
            {
                string[] ContainsAllArray = ContainsAllString.Split(Separator.ToCharArray()[0]);
                foreach (string ThisString in ContainsAllArray)
                {
                    string CheckingThis = ThisString;
                    if (!CaseSensitive)
                    {
                        CheckingThis = CheckingThis.ToLower();
                    }
                    if (!ContainsAll.Contains(CheckingThis))
                    {
                        ContainsAll.Add(CheckingThis);
                    }
                }
            }
            if (ContainsNoneString.Length > 0)
            {
                string[] ContainsNoneArray = ContainsNoneString.Split(Separator.ToCharArray()[0]);
                foreach (string ThisString in ContainsNoneArray)
                {
                    string CheckingThis = ThisString;
                    if (!CaseSensitive)
                    {
                        CheckingThis = CheckingThis.ToLower();
                    }
                    if (!ContainsNone.Contains(CheckingThis))
                    {
                        ContainsNone.Add(CheckingThis);
                    }
                }
            }
        }

        // Checks whether or not the contents of another SearchParameters are
        // identical to this SearchParameters.
        public bool IsIdenticalTo(SearchParameters OtherParameters)
        {

            if (ReplacementString  != OtherParameters.ReplacementString)  return false;
            // technically doesn't mean search needs to be redone, but if I don't do this, only 
            // changing the replacement string in the UI does not get reflected in the data
            
            if (BaseDirectory      != OtherParameters.BaseDirectory)      return false;
            if (FindThisString     != OtherParameters.FindThisString)     return false;
            if (Recursive          != OtherParameters.Recursive)          return false;
            if (CaseSensitive      != OtherParameters.CaseSensitive)      return false;
            if (FileFilters.Count  != OtherParameters.FileFilters.Count)  return false;
            if (ContainsAll.Count  != OtherParameters.ContainsAll.Count)  return false;
            if (ContainsNone.Count != OtherParameters.ContainsNone.Count) return false;
            // done checking the easy stuff

            // I expect these checks to work even though they're not programmatically thorough, 
            // because I ensured that none of the MyStringCollections contained duplicates, and
            // up above I ensure that they had the same number of entries.
            // I'm making the assumption that "Contains" is case sensitive.
            foreach (string ThisString in FileFilters)
            {
                if (!OtherParameters.FileFilters.Contains(ThisString))
                {
                    return false;
                }
            }
            foreach (string ThisString in ContainsAll)
            {
                if (!OtherParameters.ContainsAll.Contains(ThisString))
                {
                    return false;
                }
            }
            foreach (string ThisString in ContainsNone)
            {
                if (!OtherParameters.ContainsNone.Contains(ThisString))
                {
                    return false;
                }
            }
            return true;
        }

        // This allows me to do fancy input error handling by giving me
        // a lot of information all at once. I could have done this with
        // fancy math, too, but I wanted to learn about enums.
        public InputErrors AreValid()
        {
            InputErrors MyErrors = InputErrors.NoProblems;

            // definitely not a complete check yet
            if (!Directory.Exists(BaseDirectory))
            {
                MyErrors = MyErrors | InputErrors.InvalidBaseDirectory;
            }

            if (ContainsInvalidFileCharacters(ReplacementString))
            {
                MyErrors = MyErrors | InputErrors.InvalidCharactersInReplacement;
            }

            if (ContainsInvalidFilterCharacters(FileFilters))
            {
                MyErrors = MyErrors | InputErrors.InvalidFilterCharacters;
            }

            if (ContainCommonString(ContainsAll, ContainsNone))
            {
                MyErrors = MyErrors | InputErrors.ConflictingContainsAllWithContainsNone;
            }

            if (ContainsNone.Contains(FindThisString))
            {
                MyErrors = MyErrors | InputErrors.ConflictingFindThisWithContainsNone;
            }

            return MyErrors;
        }

        // Very simple.
        private bool ContainCommonString(MyStringCollection CollectionA, MyStringCollection CollectionB)
        {
            foreach(string ThisString in CollectionA)
            {
                if(CollectionB.Contains(ThisString))
                {
                    return true;
                }
            }
            return false;
        }

        // Pretty obvious what this does...
        // No research, so may not be complete or correct.
        private bool ContainsInvalidFileCharacters(string ThisString)
        {
            string[] BadCharacters = { "\\", "/", ":", "*", "?", "\"", "<", ">", "|" };

            foreach(string ThisCharacter in BadCharacters)
            {
                if(ThisString.Contains(ThisCharacter))
                {
                    return true;
                }
            }
            return false;
        }

        // Pretty obvious what this does.
        private bool ContainsInvalidFileCharacters(MyStringCollection TheseStrings)
        {
            foreach(string ThisString in TheseStrings)
            {
                if(ContainsInvalidFileCharacters(ThisString))
                {
                    return true;
                }
            }
            return false;
        }


        // pretty obvious what this does...
        // May not be a complete or correct list...I didn't do any research.
        private bool ContainsInvalidFilterCharacters(string ThisString)
        {
            string[] BadCharacters = { "\\", "/", ":", "\"", "<", ">", "|" };

            foreach(string ThisCharacter in BadCharacters)
            {
                if(ThisString.Contains(ThisCharacter))
                {
                    return true;
                }
            }
            return false;
        }

        // pretty obvious what this does...
        private bool ContainsInvalidFilterCharacters(MyStringCollection TheseStrings)
        {
            foreach(string ThisString in TheseStrings)
            {
                if(ContainsInvalidFilterCharacters(ThisString))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
