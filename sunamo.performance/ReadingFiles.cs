public class ReadingFiles
{
    public static void ReadingFilesTest()
    {
        var file = @"D:\_Test\sunamo.performance\FileManipulation.cs";

        StopwatchStatic.Start();
        var content = TF.ReadAllText(file);
        StopwatchStatic.StopAndPrintElapsed("TF.ReadAllText");

        var file2 = FS.InsertBetweenFileNameAndExtension(file, "2");

        StopwatchStatic.Start();
        var content2 = FS.ReadAllText(file2);
        StopwatchStatic.StopAndPrintElapsed("FS.ReadAllText");

        var file3 = FS.InsertBetweenFileNameAndExtension(file, "2");

        StopwatchStatic.Start();
        var content3 = TF.ReadAllTextParallel(file3, null, null);
        StopwatchStatic.StopAndPrintElapsed("TF.ReadAllTextParallel");

        var file4 = FS.InsertBetweenFileNameAndExtension(file, "2");

        StopwatchStatic.Start();
        var content4 = TF.ReadAllLines(file4);
        StopwatchStatic.StopAndPrintElapsed("TF.ReadAllLines");
    }
}
