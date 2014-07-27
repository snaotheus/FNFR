using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace FNFR2
{
    class SearchResults
    {
        private MyStringCollection _BannedDirectories = new MyStringCollection();
        private MyStringCollection _AllowedDirectories = new MyStringCollection();
        private MyStringCollection _FileNames = new MyStringCollection();
        private MyStringCollection _RenamedFiles = new MyStringCollection();

        public MyStringCollection BannedDirectories  { get { return _BannedDirectories;  } }
        public MyStringCollection AllowedDirectories { get { return _AllowedDirectories; } }
        public MyStringCollection FileNames          { get { return _FileNames;          } }
        public MyStringCollection RenamedFiles       { get { return _RenamedFiles;       } }

        public SearchResults()
        {
        }

        public void AddBannedDirectories(string[] mBannedDirectories)
        {
            foreach (string ThisDirectory in mBannedDirectories)
            {
                AddBannedDirectory(ThisDirectory);
            }
        }

        public void AddBannedDirectory(string ThisDirectory)
        {
            if (!_BannedDirectories.Contains(ThisDirectory))
            {
                _BannedDirectories.Add(ThisDirectory);
            }
        }

        public void AddAllowedDirectories(string[] mAllowedDirectories)
        {
            foreach (string ThisDirectory in mAllowedDirectories)
            {
                AddAllowedDirectory(ThisDirectory);
            }
        }

        public void AddAllowedDirectory(string ThisDirectory)
        {
            if (!_AllowedDirectories.Contains(ThisDirectory))
            {
                _AllowedDirectories.Add(ThisDirectory);
            }
        }

        public void AddFileNames(string[] mFileNames)
        {
            foreach (string ThisFileName in mFileNames)
            {
                AddFileName(ThisFileName);
            }
        }

        public void AddFileName(string ThisFileName)
        {
            if (!_FileNames.Contains(ThisFileName))
            {
                _FileNames.Add(ThisFileName);
            }
        }

        public void AddRenamedFiles(string[] mRenamedFiles)
        {
            foreach (string ThisRenamedFile in mRenamedFiles)
            {
                AddRenamedFile(ThisRenamedFile);
            }
        }

        public void AddRenamedFiles(MyStringCollection mRenamedFiles)
        {
            foreach (string ThisRenamedFile in mRenamedFiles)
            {
                AddRenamedFile(ThisRenamedFile);
            }
        }

        public void AddRenamedFile(string ThisRenamedFile)
        {
            if (!_RenamedFiles.Contains(ThisRenamedFile))
            {
                _RenamedFiles.Add(ThisRenamedFile);
            }
        }
        public void ClearFileNames()
        {
            _FileNames = new MyStringCollection();
        }

        ///////////////////////////////////
        ///////////////////////////////////
        // I don't think these really belong here, but I didn't think they really belonged
        // anywhere else, either.

        public TreeNode ReplacementsToTree()
        {
            return MyCollectionToTreeNode(_AllowedDirectories[0], _RenamedFiles);
        }

        public TreeNode FileNamesToTree()
        {
            return MyCollectionToTreeNode(_AllowedDirectories[0], _FileNames);
        }

        // Handy service that takes a collection of filename strings and puts them into
        // TreeNode format. No sorting.
        private TreeNode MyCollectionToTreeNode(string RootString, MyStringCollection CollectionOfFiles)
        {
            if ( (RootString[RootString.Length - 1] == '\\'))
            {
                // I just don't like the way it looks if the top node ends 
                // in a slash and the other nodes don't.
                RootString = RootString.Substring(0,RootString.Length-1);
            }

            TreeNode Tree = new TreeNode(RootString);

            foreach (string ThisFile in CollectionOfFiles)
            {
                // Recursive. No sorting.
                Tree = PutTree(Tree, ThisFile.Substring(RootString.Length));
            }
            return Tree;
        }

        // Takes a file name and figures out where it belongs, and puts a node there.
        // Adds directory nodes if necessary.
        private TreeNode PutTree(TreeNode ThisNode, string ThisFile)
        {
            if (ThisFile[0] == '\\')
            {
                // If it starts in a slash, we want to get rid of the slash.
                ThisFile = ThisFile.Substring(1);
            }
            if (ThisFile.Contains("\\"))
            {
                // If it contains a slash, we're not done. So figure it out, 
                // and call it again.
                string FirstFolder = ThisFile.Substring(0, ThisFile.IndexOf("\\"));
                string RestOfPath = ThisFile.Substring(ThisFile.IndexOf("\\") + 1);
                int NextChild = WhichChildContainsString(ThisNode, FirstFolder);
                if (NextChild == -1)
                {
                    ThisNode.Nodes.Add(FirstFolder);
                    NextChild = WhichChildContainsString(ThisNode, FirstFolder);
                }
                PutTree(ThisNode.Nodes[NextChild], RestOfPath);
            }
            else
            {
                // No slashes means we're adding an actual file instead of a directory.
                // That's the end of the road. So return it.
                ThisNode.Nodes.Add(ThisFile);
            }
            return ThisNode;
        }

        // Checks the first generation children to see if any of them contain ThisString.
        // If not, return -1. If so, return the index of the child.
        private int WhichChildContainsString(TreeNode ThisNode, string ThisString)
        {
            int FoundIt = -1;

            if (ThisNode.Nodes.Count == 0)
            {
                FoundIt = -1;
            }
            else
            {
                int i = 0;
                while (FoundIt == -1 && i < ThisNode.Nodes.Count)
                {
                    if (ThisNode.Nodes[i].Text == ThisString)
                    {
                        FoundIt = i;
                    }
                    i++;
                }
            }
            return FoundIt;
        }
    }
}
