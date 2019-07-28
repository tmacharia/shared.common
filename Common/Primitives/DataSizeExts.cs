using System;
using Common.Enums;

namespace Common.Primitives
{
    /// <summary>
    /// Represents extension methods used in formatting data byte(s) to
    /// human readable format.
    /// </summary>
    public static class DataSizeExts
    {
        /// <summary>
        /// Size of 1 KB in Bytes.
        /// </summary>
        public const long OneKb = 1024;
        /// <summary>
        /// Size of 1 MB in Bytes.
        /// </summary>
        public const long OneMb = OneKb * 1024;
        /// <summary>
        /// Size of 1 GB in Bytes.
        /// </summary>
        public const long OneGb = OneMb * 1024;
        /// <summary>
        /// Size of 1 TB in Bytes.
        /// </summary>
        public const long OneTb = OneGb * 1024;

        /// <summary>
        /// Convert the specified data byte(s) to the specified <see cref="DataFormat"/> with 
        /// <see cref="DataFormat.MB"/> being the default.
        /// </summary>
        /// <param name="value">Bytes length/count.</param>
        /// <param name="format">Data format type to convert to.</param>
        /// <param name="precision">Number of decimal places.</param>
        /// <returns>Converted value.</returns>
        public static double ConvertData(this long value, DataFormat format = DataFormat.MB,
            int precision = 2)
        {
            switch (format)
            {
                case DataFormat.TB:
                    return Math.Round((double)value / OneTb, precision);
                case DataFormat.GB:
                    return Math.Round((double)value / OneGb, precision);
                case DataFormat.MB:
                    return Math.Round((double)value / OneMb, precision);
                case DataFormat.KB:
                    return Math.Round((double)value / OneKb, precision);
                case DataFormat.Bytes:
                    return value;
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Formats data byte(s) to human readable format appending the appropriate <see cref="DataFormat"/>
        /// if not specified.
        /// </summary>
        /// <param name="value">Bytes length/count.</param>
        /// <param name="format">Data format type to convert to.</param>
        /// <param name="precision">Number of decimal places.</param>
        /// <returns>Formatted data string.</returns>
        public static string HumanizeData(this long value, DataFormat? format, int precision = 2)
        {
            if (!format.HasValue) {
                format = value >= OneTb ? DataFormat.TB
                : value >= OneGb ? DataFormat.GB
                : value >= OneMb ? DataFormat.MB : DataFormat.KB;
            }
            return string.Format("{0} {1}",
                value.ConvertData(format.Value, precision),
                format.ToString());
        }
    }
}