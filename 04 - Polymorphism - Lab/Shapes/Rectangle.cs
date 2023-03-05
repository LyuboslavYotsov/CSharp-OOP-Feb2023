using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Width
        {
            get { return width; }
            private set { width = value; }
        }


        public double Height
        {
            get { return height; }
            private set { height = value; }
        }

        public override double CalculateArea() => this.Height * this.Width;

        public override double CalculatePerimeter() => 2 * this.Width + 2 * this.Height;
    }
}
