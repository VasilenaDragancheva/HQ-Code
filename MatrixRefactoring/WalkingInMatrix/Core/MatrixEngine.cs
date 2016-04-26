namespace WalkInMatrix.Core
{
    using WalkInMatrix.Contracts;
    using WalkInMatrix.Models;

    public class MatrixEngine : IEngine
    {
        public MatrixEngine(IReader reader, IPrinter printer)
        {
            this.Reader = reader;
            this.Printer = printer;
        }

        public IReader Reader { get; private set; }

        public IPrinter Printer { get; private set; }

        public void Run()
        {
            this.Printer.Print("Enter a positive number ");
            string input = this.Reader.Read();
            int n;

            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                this.Printer.Print("You haven't entered a correct positive number");
                input = this.Reader.Read();
            }

            var matrix = new WalkingInMatrix(n);
            matrix.WalkInMatrix();
            this.Printer.Print(matrix.Print());
        }
    }
}