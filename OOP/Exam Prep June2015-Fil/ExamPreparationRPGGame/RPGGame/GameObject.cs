using RPGGame.Exception;
using System;

namespace RPGGame
{
    public abstract class GameObject
    {

        private Position position;
        private char objectSymbol;

        protected GameObject(Position position, char objectSymbol)
        {
            this.Position = position;
            this.ObjectSymbol = objectSymbol;
        }

        public Position Position
        {
            get { return this.position; }
            set
            {
                if (value.X < 0 || value.Y < 0)
                {
                    throw new ObjectOutOfRangeException("The object coordinates are outside of map");
                }
                this.position = value;
            }

        }

        public char ObjectSymbol
        {
            get { return this.objectSymbol; }
            set
            {
                if (!char.IsUpper(value))
                {
                    throw new ArgumentOutOfRangeException("object symbol",
                        "Object symbol must be upper case letter");
                }
                this.objectSymbol = value;
            }
        }
    }
}
