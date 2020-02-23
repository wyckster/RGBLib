namespace RGBLib
{
    public struct SRGBA
    {
        public SRGBA(byte r, byte g, byte b, byte a = 255)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }

        public byte R, G, B, A;
        public static SRGBA Zero = new SRGBA(0, 0, 0, 0);
        public static SRGBA Black = new SRGBA(0, 0, 0, 255);
        public static SRGBA White = new SRGBA(255, 255, 255, 255);
        public static SRGBA Red = new SRGBA(255, 0, 0, 255);
        public static SRGBA Green = new SRGBA(0, 255, 0, 255);
        public static SRGBA Blue = new SRGBA(0, 0, 255, 255);

        public RGB ToRGB()
        {
            return new RGB(
                ColorExtensions.SRGBToLinear(ColorExtensions.Unnormalize8(R)),
                ColorExtensions.SRGBToLinear(ColorExtensions.Unnormalize8(G)),
                ColorExtensions.SRGBToLinear(ColorExtensions.Unnormalize8(B))
                );
        }

        public string ToHexString()
        {
            return string.Format(string.Format("{0,0:X2}{1,0:X2}{2,0:X2}", R, G, B));
        }
    }
}
