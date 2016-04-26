namespace WalkInMatrix
{
    using WalkInMatrix.Core;

    public class WalkingMatrixProgram
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var printer = new ConsolePrinter();
            var engine = new MatrixEngine(reader, printer);
            engine.Run();
        }
    }
}