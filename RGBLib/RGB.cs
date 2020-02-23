using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBLib
{
    public struct RGB
    {
        public RGB(double r, double g, double b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        public double r, g, b;

        public static RGB Black = new RGB(0, 0, 0);
        public static RGB White = new RGB(1, 1, 1);
        public static RGB Red = new RGB(1, 0, 0);
        public static RGB Green = new RGB(0, 1, 0);
        public static RGB Blue = new RGB(0, 0, 1);

        public SRGBA ToSRGBA()
        {
            return new SRGBA(
                ColorExtensions.Normalize8(ColorExtensions.LinearToSRGB(r)),
                ColorExtensions.Normalize8(ColorExtensions.LinearToSRGB(g)),
                ColorExtensions.Normalize8(ColorExtensions.LinearToSRGB(b)),
                0xFF
                );
        }

        // Addition
        public static RGB operator +(RGB A, RGB B)
        {
            return new RGB(A.r + B.r, A.g + B.g, A.b + B.b);
        }

        // Unary Plus
        public static RGB operator +(RGB A)
        {
            return new RGB(+A.r, +A.g, +A.b);
        }

        // Subtraction
        public static RGB operator -(RGB A, RGB B)
        {
            return new RGB(A.r - B.r, A.g - B.g, A.b - B.b);
        }

        // Unary Negative
        public static RGB operator -(RGB A)
        {
            return new RGB(0.0 - A.r, 0.0 - A.g, 0.0 - A.b);
        }

        // Scalar Multiplication
        public static RGB operator *(RGB A, double v)
        {
            return new RGB(A.r * v, A.g * v, A.b * v);
        }

        public static RGB operator *(double v, RGB A)
        {
            return new RGB(v * A.r, v * A.g, v * A.b);
        }

        // Scalar Division
        public static RGB operator /(RGB A, double v)
        {
            return new RGB(A.r / v, A.g / v, A.b / v);
        }

        // Modulation
        public static RGB operator *(RGB A, RGB B)
        {
            return new RGB(A.r * B.r, A.g * B.g, A.b * B.b);
        }

        // Conversion to String
        public override string ToString()
        {
            return string.Format("{0}{1}, {2}, {3}{4}", '(', r, g, b, ')');
        }
    }

}
