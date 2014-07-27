using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FNFR2
{
    [Flags]
    public enum InputErrors
    {
        NoProblems                             = 0x00,
        InvalidBaseDirectory                   = 0x01,
        InvalidFilterCharacters                = 0x02,
        ConflictingContainsAllWithContainsNone = 0x04,
        ConflictingFindThisWithContainsNone    = 0x08,
        InvalidCharactersInReplacement         = 0x10,
    }
}
