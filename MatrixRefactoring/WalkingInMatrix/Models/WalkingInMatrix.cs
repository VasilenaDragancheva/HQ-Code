namespace WalkInMatrix.Models
{
    using System;
    using System.Text;

    public class WalkingInMatrix
    {
        private readonly int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };

        private readonly int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        private int dimensionSize;

        private int directionIndex;

        private int[,] matrix;

        public WalkingInMatrix(int dimensionSize)
        {
            this.DimensionSize = dimensionSize;
            this.DirectionIndex = 0;
            this.Y = 0;
            this.X = 0;
        }

        public int DirectionIndex
        {
            get
            {
                return this.directionIndex;
            }

            private set
            {
                this.directionIndex = value > 7 ? 0 : value;
            }
        }

        public int DeltaX
        {
            get
            {
                return this.directionsX[this.directionIndex];
            }
        }

        public int DeltaY
        {
            get
            {
                return this.directionsY[this.directionIndex];
            }
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public bool IsOutsideBoundries
        {
            get
            {
                bool outsideCol = this.X + this.DeltaX >= this.dimensionSize || this.X + this.DeltaX < 0;
                bool outsideRow = this.Y + this.DeltaY >= this.dimensionSize || this.Y + this.DeltaY < 0;
                return outsideCol || outsideRow || this.matrix[this.X + this.DeltaX, this.Y + this.DeltaY] != 0;
            }
        }

        private int DimensionSize
        {
            get
            {
                return this.dimensionSize;
            }

            set
            {
                if (value <= 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.dimensionSize = value;
                this.matrix = new int[value, value];
            }
        }

        public string Print()
        {
            var result = new StringBuilder();

            for (int r = 0; r < this.dimensionSize; r++)
            {
                for (int c = 0; c < this.dimensionSize; c++)
                {
                    result.AppendFormat("{0,3}", this.matrix[r, c]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        public void WalkInMatrix()
        {
            int value = 0;

            while (true)
            {
                value++;
                this.matrix[this.X, this.Y] = value;

                if (!this.CheckCell())
                {
                    break;
                }

                while (this.IsOutsideBoundries)
                {
                    this.ChangeDirection();
                }

                this.X += this.DeltaX;
                this.Y += this.DeltaY;
            }

            this.FindCell();
            if (this.X != 0 && this.Y != 0 && this.matrix[this.X, this.Y] == 0)
            {
                this.DirectionIndex = 0;
                value++;

                while (true)
                {
                    this.matrix[this.X, this.Y] = value;

                    if (!this.CheckCell())
                    {
                        break;
                    }

                    while (this.IsOutsideBoundries)
                    {
                        this.ChangeDirection();
                    }

                    this.X += this.DeltaX;
                    this.Y += this.DeltaY;
                    value++;
                }
            }
        }

        private void ChangeDirection()
        {
            this.DirectionIndex++;
        }

        // TODO:refactor
        private bool CheckCell()
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (this.X + dirX[i] >= this.DimensionSize || this.X + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (this.Y + dirY[i] >= this.DimensionSize || this.Y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (this.matrix[this.X + dirX[i], this.Y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void FindCell()
        {
            for (int x = 0; x < this.dimensionSize; x++)
            {
                for (int y = 0; y < this.dimensionSize; y++)
                {
                    if (this.matrix[x, y] == 0)
                    {
                        this.X = x;
                        this.Y = y;
                    }
                }
            }
        }
    }
}