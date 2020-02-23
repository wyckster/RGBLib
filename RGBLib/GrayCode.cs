namespace RGBLib
{
    public static class GrayCode
    {
        /// <summary>
        /// This function converts a binary
        /// number to reflected binary Gray code.
        /// </summary>
        /// <param name="num">A binary number</param>
        /// <returns>The gray coded number</returns>
        public static int BinaryToGray(int num)
        {
            // The operator >> is shift right. The operator ^ is exclusive or.
            return num ^ (num >> 1);
        }

        /// <summary>
        /// This function converts an unsigned binary
        /// number to reflected binary Gray code.
        /// </summary>
        /// <param name="num">A binary number</param>
        /// <returns>The gray coded number</returns>
        public static uint BinaryToGray(uint num)
        {
            return num ^ (num >> 1);
        }

        /// <summary>
        /// This function converts a reflected binary
        /// Gray code number to a binary number.
        /// </summary>
        /// <param name="num">A gray coded number</param>
        /// <returns>The binary number</returns>
        public static int GrayToBinary(int num)
        {
            // Each Gray code bit is exclusive-ored with all
            // more significant bits.
            int mask = num >> 1;
            while (mask != 0) {
                num = num ^ mask;
                mask = mask >> 1;
            }
            return num;
        }

        /// <summary>
        /// This function converts a reflected binary
        /// Gray code number to an unsigned binary number.
        /// </summary>
        /// <param name="num">A gray coded number</param>
        /// <returns>The binary number</returns>
        public static uint GrayToBinary(uint num)
        {
            uint mask = num >> 1;
            while (mask != 0) {
                num = num ^ mask;
                mask = mask >> 1;
            }
            return num;
        }

        /// <summary>
        /// A more efficient version for Gray codes 32 bits or fewer.
        /// </summary>
        /// <param name="num">A gray coded number</param>
        /// <returns>The binary number</returns>
        public static int GrayToBinary32(int num)
        {
            /// through the use of SWAR (SIMD within a register) techniques.
            /// It implements a parallel prefix XOR function.  The assignment
            /// statements can be in any order.
            /// 
            /// This function can be adapted for longer Gray codes by adding steps.
            /// A 4-bit variant changes a binary number (abcd)2 to (abcd)2 ^ (00ab)2,
            /// then to (abcd)2 ^ (00ab)2 ^ (0abc)2 ^ (000a)2.
            num = num ^ (num >> 16);
            num = num ^ (num >> 8);
            num = num ^ (num >> 4);
            num = num ^ (num >> 2);
            num = num ^ (num >> 1);
            return num;
        }

        /// <summary>
        /// A more efficient version for Gray codes 32 bits or fewer.
        /// </summary>
        /// <param name="num">A gray coded number</param>
        /// <returns>The binary number</returns>
        public static uint GrayToBinary32(uint num)
        {
            num = num ^ (num >> 16);
            num = num ^ (num >> 8);
            num = num ^ (num >> 4);
            num = num ^ (num >> 2);
            num = num ^ (num >> 1);
            return num;
        }
    }
}
