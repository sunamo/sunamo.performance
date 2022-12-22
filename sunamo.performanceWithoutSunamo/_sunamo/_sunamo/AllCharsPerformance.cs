using System;
using System.Collections.Generic;
using System.Text;

public static partial class AllChars
{
    public static List<char> specialCharsAll = new List<char>();

    static AllChars()
    {
        specialCharsAll.AddRange(specialChars);
        specialCharsAll.AddRange(specialChars2);
    }
}
