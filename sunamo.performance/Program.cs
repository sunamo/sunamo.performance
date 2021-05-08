using System;
using cmd.Essential;
using sunamo.Essential;

namespace sunamo.performance
{
    class Program
    {
        static void Main(string[] args)
        {
            CmdApp.EnableConsoleLogging(true);
            InitApp.Logger = ConsoleLogger.Instance;
            InitApp.TemplateLogger = ConsoleTemplateLogger.Instance;
            InitApp.TypedLogger = TypedConsoleLogger.Instance;

            //ManyStringReplacing.MainManyStringReplacing();
            WritingFiles.WritingSpeed();

            Console.WriteLine("App finished");
            Console.ReadLine();
        }
    }
}