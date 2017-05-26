using System.Collections.Generic;

namespace EnvironmentSystem.Models.Objects
{
    public class Explosion : EnvironmentObject
    {

        private int lifetime = 2;

        public Explosion(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.CollisionGroup = CollisionGroup.Explosion;
            this.ImageProfile = this.GenerateImageProfile();
        }

        public override void Update()
        {
            this.lifetime--;
            if (this.lifetime == 0)
            {
                this.Exists = false;
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {

        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }

        protected virtual char[,] GenerateImageProfile()
        {
            char[,] image = new char[this.Bounds.Height, this.Bounds.Width];
            for (int row = 0; row < image.GetLength(0); row++)
            {
                for (int col = 0; col < image.GetLength(1); col++)
                {
                    if (col != 2 || row != 2)
                    {
                        image[row, col] = '*';
                    }
                }
            }
            return image;
        }

    }
}
