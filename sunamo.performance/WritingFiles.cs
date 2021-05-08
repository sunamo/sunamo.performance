using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class WritingFiles
{
    public static void WritingSpeed()
    {
        /*
TF.SaveFile takes 101ms
File.WriteAllText takes 8ms
         */

        var file = @"d:\_Test\sunamo.performance\WritingSpeed\a.txt";
        var content = string.Empty.PadLeft(1000000, AllChars.commat);

        StopwatchStatic.Start();
        TF.SaveFile(content, file);
        StopwatchStatic.StopAndPrintElapsed("TF.SaveFile");

        StopwatchStatic.Start();
        File.WriteAllText( file, content);
        StopwatchStatic.StopAndPrintElapsed("File.WriteAllText");
    }
}