using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class ManyStringReplacing
{
    public static void MainManyStringReplacing()
    {
        var file = @"d:\_Test\sunamo.performance\FileManipulation.cs";

        StopwatchStatic.Start();
        var content = FS.ReadAllText(file);
        StopwatchStatic.StopAndPrintElapsed("FS.ReadAllText");

        /*
TF.ReadFile takes 228ms
FS.ReadAllText takes 0ms
TF.ReadFileParallel takes 1ms
         */



        #region Replacement
     
        #endregion

        /*
 ReplaceAll3 takes 254ms
ReplaceUnsafeUnmanaged takes 7532ms
ReplaceAllSb 1242ms
 */

        var tuple = SH.SplitFromReplaceManyFormat(replacePairs);
        var from = SH.GetLines(tuple.Item1);
        var to = SH.GetLines(tuple.Item2);
        var sb = new StringBuilder(content);

        StopwatchStatic.Start();
        var replaced = SH.ReplaceAll3(from, to, false, content);
        StopwatchStatic.StopAndPrintElapsed("ReplaceAll3");

        //StopwatchStatic.Start();
        //var replaced2 = SHUnsafe.ReplaceUnsafeUnmanaged(new StringBuilder(content), from, to).ToString();
        //StopwatchStatic.StopAndPrintElapsed("ReplaceUnsafeUnmanaged");

        //StopwatchStatic.Start();
        //for (int i = 0; i < from.Count; i++)
        //{
        //    sb = SH.ReplaceAllSb(sb, to[i], from[i]);
        //}
        //StopwatchStatic.StopAndPrintElapsed("ReplaceAllSb");

        StopwatchStatic.Start();
        var replaced4 = TF.ReadFileParallel(file, from, to);
        StopwatchStatic.StopAndPrintElapsed("TF.ReadFileParallel");
    }
}