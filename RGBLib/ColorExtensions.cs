using System;

namespace RGBLib
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts a byte [0 to 255] to a double [0.0 to 1.0]
        /// </summary>
        /// <param name="srgb"></param>
        /// <returns></returns>
        public static byte UNorm8(double srgb)
        {
            if (srgb >= 1.0) {
                return 255;
            }
            else if (srgb <= 0.0) {
                return 0;
            }
            else {
                return (byte)((srgb * 255.0) + 0.5);
            }
        }

        /// <summary>
        /// Converts linear to SRGB.
        /// </summary>
        /// <param name="srgb">Normalized SRGB value in the range [0.0 to 1.0]</param>
        /// <returns>Normalized linear value in the range [0.0 to 1.0]</returns>
        public static double SRGBToLinear(double srgb)
        {
            if (srgb <= 0.04045) {
                return srgb / 12.92;
            }
            else {
                return (double)Math.Pow((srgb + 0.055) / 1.055, 2.4);
            }
        }

        /// <summary>
        /// Converts SRGB to Linear.
        /// </summary>
        /// <param name="linear">Normalized Linear value in the ragne [0.0 to 1.0]</param>
        /// <returns>Normalized SRGB value in the range [0.0 to 1.0]</returns>
        public static double LinearToSRGB(double linear)
        {
            if (linear <= 0.0031308) {
                return 12.92 * linear;
            }
            else {
                return (double)(1.055 * Math.Pow(linear, 1.0 / 2.4) - 0.055);
            }
        }

        /// <summary>
        /// Converts a byte in the range [0 to 255] to a double in the range [0.0 to 1.0].
        /// </summary>
        /// <param name="p">A byte in the range [0 to 255]</param>
        /// <returns>A double in the range [0.0 to 1.0]</returns>
        public static double Unnormalize8(byte p)
        {
            return p / 255.0;
        }

        /// <summary>
        /// Converts a double in the range [0.0 to 1.0] to a byte in the range [0 to 255].
        /// </summary>
        /// <param name="linear"></param>
        /// <returns></returns>
        public static byte Normalize8(double linear)
        {
            double v = (linear * 255.0 + 0.5);
            if (v <= 0.0) return 0;
            if (v >= 255.0) return 0xFF;
            return (byte)v;
        }
    }

}
