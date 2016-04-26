namespace WalkInMatrix.Contracts
{
    public interface IWalkingInMatrix
    {
        int DimensionSize { get; }

        void WalkInMatrix();
    }
}