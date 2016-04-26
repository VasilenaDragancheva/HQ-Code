namespace Minesweeper
{
    using System;

    public class Player
    {
        private string name;
        private int points;

        public Player()
        {
        }

        public Player(string playerName, int points)
        {
            this.Name = playerName;
            this.Points = points;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("player name");
                }

                this.name = value; 
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                this.points = value;
            }
        }
    }
}
