namespace WalkInMatrix.Contracts
{
    public interface IEngine
    {
        IReader Reader { get; }

        IPrinter Printer { get; }

        void Run();
    }
}