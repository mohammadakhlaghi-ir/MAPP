using Force.Crc32;
using System.Text;

namespace ShadowApp.Application.Utilities
{
    public static class CrcHelper
    {
        public static string ComputeCrc(string input)
        {
            input ??= string.Empty;

            var bytes = Encoding.UTF8.GetBytes(input);
            var crcValue = Crc32Algorithm.Compute(bytes);

            return crcValue.ToString("X8");
        }
    }
}
