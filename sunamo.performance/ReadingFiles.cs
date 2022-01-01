using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class ReadingFiles
{
    public static void ReadingFilesTest()
    {
        var file = @"d:\_Test\sunamo.performance\FileManipulation.cs";

        StopwatchStatic.Start();
        var content = TF.ReadFile(file);
        StopwatchStatic.StopAndPrintElapsed("TF.ReadFile");

        var file2 = FS.InsertBetweenFileNameAndExtension(file, "2");

        StopwatchStatic.Start();
        var content2 = FS.ReadAllText(file2);
        StopwatchStatic.StopAndPrintElapsed("FS.ReadAllText");

        var file3 = FS.InsertBetweenFileNameAndExtension(file, "2");

        StopwatchStatic.Start();
        var content3 = TF.ReadFileParallel(file3, null, null);
        StopwatchStatic.StopAndPrintElapsed("TF.ReadFileParallel");

        var file4 = FS.InsertBetweenFileNameAndExtension(file, "2");

        StopwatchStatic.Start();
        var content4 = TF.ReadAllLines(file4);
        StopwatchStatic.StopAndPrintElapsed("TF.ReadAllLines");
    }
}