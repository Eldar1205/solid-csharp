using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Solid.C_LSP1
{
    public class Rectangle
    {
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }

        public int CalcArea()
        {
            return Height*Width;
        }
    }

    public class Square : Rectangle
    {
        private int _height;
        private int _width;

        public override int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                _height = value;
            }
        }

        public override int Height
        {
            get { return _height; }
            set
            {
                _width = value;
                _height = value;
            }
        }
    }

    public class RectangleTests
    {
        public void TestRectangle()
        {
            InnerTestRectangle(new Rectangle());
        }

        public void TestSquare()
        {
            InnerTestRectangle(new Square());
        }

        private static void InnerTestRectangle(Rectangle r)
        {
            r.Height = 3;
            r.Width = 6;
            int area = r.CalcArea();

            Debug.Assert(area == 18); // Fails for Square
        }
    }
}
