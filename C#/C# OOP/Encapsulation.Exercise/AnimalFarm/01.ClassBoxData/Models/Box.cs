using System;

namespace _01.ClassBoxData
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double GetSurfaceArea()
        {
            return 2 * (this.Length * this.Height + this.Width * this.Height + this.Length * this.Width);
        }

        public double GetLateralSurfaceArea()
        {
            return 2 * (this.Length * this.Height + this.Width * this.Height);
        }

        public double GetVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine($"Surface Area - {this.GetSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.GetVolume():f2}");

            return sb.ToString().TrimEnd();
        }

    }
}
