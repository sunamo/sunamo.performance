public class WritingFiles
{
    public static void WritingSpeed()
    {
        /*
TF.SaveFile takes 101ms
TF.WriteAllText takes 8ms
         */

        var file = @"D:\_Test\sunamo.performance\WritingSpeed\a.txt";
        var content = string.Empty.PadLeft(1000000, AllChars.commat);

        StopwatchStatic.Start();
        TF.SaveFile(content, file);
        StopwatchStatic.StopAndPrintElapsed("TF.SaveFile");

        StopwatchStatic.Start();
        TF.WriteAllText( file, content);
        StopwatchStatic.StopAndPrintElapsed("TF.WriteAllText");
    }
}
