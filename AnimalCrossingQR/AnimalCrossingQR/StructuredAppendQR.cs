using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ZXing.Common;
using ZXing.Common.ReedSolomon;
using ZXing.QrCode.Internal;

// I feel like I should apologize for the crimes against humanity that the
//  following code commits. If anyone knows any other way to accomplish this,
//  please let me know so I can remove this horrible train-wreck.
namespace AnimalCrossingQR
{
    public class StructuredAppendQR
    {
        private static readonly int[][] MaxQRSize = 
        {
           new int[] { 17, 32, 53, 78, 106, 134, 154, 192, 230, 271, 321, 367, 425, 458, 520, 586, 644,
               718, 792, 858, 929, 1003, 1091, 1171, 1273, 1367, 1465, 1528, 1628, 1732, 1840, 1952,
               2068, 2188, 2303, 2431, 2563, 2699, 2809, 2953 },
           new int[] { 14, 26, 42, 62, 84, 106, 122, 152, 180, 213, 251, 287, 331, 362, 412, 450, 504, 
               560, 624, 666, 711, 779, 857, 911, 997, 1059, 1125, 1190, 1264, 1370, 1452, 1538, 1628,
               1722, 1809, 1911, 1989, 2099, 2213, 2331 },
           new int[] { 11, 20, 32, 46, 60, 74, 86, 108, 130, 151, 177, 203, 241, 258, 292, 322, 364, 
                394, 442, 482, 509, 565, 611, 661, 715, 751, 805, 868, 908, 982, 1030, 1112, 1168, 1228,
                1283, 1351, 1423, 1499, 1579, 1663 },
           new int[] { 7, 14, 24, 34, 44, 58, 64, 84, 98, 119, 137, 155, 177, 194, 220, 250, 280, 310,
                338, 382, 403, 439, 461, 511, 535, 593, 625, 658, 698, 742, 790, 842, 898, 958, 983,
                1051, 1093, 1139, 1219, 1273 },
        };

        private static Action<int, BitArray> terminateBits;
        private static Func<BitArray, int, int, int, BitArray> interleaveWithECBytes;
        private static Func<BitArray, ErrorCorrectionLevel, ZXing.QrCode.Internal.Version, ByteMatrix, int> chooseMaskPattern;

        static StructuredAppendQR()
        {
            // Proving that 'private internal' is just a suggestion. Seriously, I'm sorry.

            terminateBits = (a, b) => typeof(ZXing.QrCode.Internal.Encoder)
                .GetMethod("terminateBits", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                .Invoke(null, new object[] { a, b });

            interleaveWithECBytes = (a, b, c, d) => (BitArray)typeof(ZXing.QrCode.Internal.Encoder)
                .GetMethod("interleaveWithECBytes", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                .Invoke(null, new object[] { a, b, c, d });
            
            chooseMaskPattern = (a, b, c, d) => (int)typeof(ZXing.QrCode.Internal.Encoder)
                .GetMethod("chooseMaskPattern", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                .Invoke(null, new object[] { a, b, c, d });
        }

        private static int GetSmallestVersion(int size, ErrorCorrectionLevel errorCorrectionLevel)
        {
            return Array.FindIndex(MaxQRSize[errorCorrectionLevel.ordinal()], i => i >= size) + 1;
        }

        public static ByteMatrix CreateRawQR(byte[] rawData, ErrorCorrectionLevel errorCorrectionLevel)
        {
            int versionNumber = GetSmallestVersion(rawData.Length, errorCorrectionLevel);
            ZXing.QrCode.Internal.Version version = ZXing.QrCode.Internal.Version.getVersionForNumber(versionNumber);

            BitArray dataBits = new BitArray();
            foreach (byte b in rawData)
                dataBits.appendBits(b, 8);
            
            ZXing.QrCode.Internal.Version.ECBlocks ecBlocks = version.getECBlocksForLevel(errorCorrectionLevel);
            int bytesLength = version.TotalCodewords - ecBlocks.TotalECCodewords;
            terminateBits(bytesLength, dataBits);

            BitArray resultBits = interleaveWithECBytes(dataBits, version.TotalCodewords, bytesLength, ecBlocks.NumBlocks);
            
            ByteMatrix matrix = new ByteMatrix(version.DimensionForVersion, version.DimensionForVersion);
            int maskPattern = chooseMaskPattern(resultBits, errorCorrectionLevel, version, matrix);

            MatrixUtil.buildMatrix(resultBits, errorCorrectionLevel, version, maskPattern, matrix);
            return matrix;
        }
    }
}
