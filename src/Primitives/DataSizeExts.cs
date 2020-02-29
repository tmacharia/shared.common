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
        /// Base 10.
        /// </summary>
        public const int Ten = 10;
        /// <summary>
        /// Size of 1 KB in Bytes.
        /// </summary>
        public static double OneKb = Math.Pow(Ten,(int)DataFormat.KB);
        /// <summary>
        /// Size of 1 MB in Bytes.
        /// </summary>
        public static double OneMb = Math.Pow(Ten, (int)DataFormat.MB);
        /// <summary>
        /// Size of 1 GB in Bytes.
        /// </summary>
        public static double OneGb = Math.Pow(Ten, (int)DataFormat.GB);
        /// <summary>
        /// Size of 1 TB in Bytes.
        /// </summary>
        public static double OneTb = Math.Pow(Ten, (int)DataFormat.TB);

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
                    return Math.Round(value / OneTb, precision);
                case DataFormat.GB:
                    return Math.Round(value / OneGb, precision);
                case DataFormat.MB:
                    return Math.Round(value / OneMb, precision);
                case DataFormat.KB:
                    return Math.Round(value / OneKb, precision);
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
        public static string HumanizeData(this long value, DataFormat? format=null, int precision = 2)
        {
            if (!format.HasValue) {
                format = value >= OneTb ? DataFormat.TB
                : value >= OneGb ? DataFormat.GB
                : value >= OneMb ? DataFormat.MB : DataFormat.KB;
            }
            return string.Format("{0} {1}",
                value.ConvertData(format.Value, precision).ToHuman(precision),
                format.Value.GetName());
        }
        /// <summary>
        /// Formats data byte(s) to human readable format appending the appropriate <see cref="DataFormat"/>
        /// based on the bytes size.
        /// </summary>
        /// <param name="value">Bytes length/count.</param>
        /// <param name="precision">Number of decimal places.</param>
        /// <returns>Formatted data string.</returns>
        public static string HumanizeData(this long value, int precision = 2) => value.HumanizeData(null, precision);
        /// <summary>
        /// Formats data byte(s) to human readable format appending the appropriate <see cref="DataFormat"/>
        /// based on the bytes size.
        /// </summary>
        /// <param name="value">Bytes length/count.</param>
        /// <param name="format"></param>
        /// <param name="precision">Number of decimal places.</param>
        /// <returns>Formatted data string.</returns>
        public static string FormatDataSize(this long value, DataFormat? format = null, int precision = 2) => value.HumanizeData(format, precision);
        /// <summary>
        /// Formats data byte(s) to human readable format appending the appropriate <see cref="DataFormat"/>
        /// based on the bytes size.
        /// </summary>
        /// <param name="value">Bytes length/count.</param>
        /// <param name="precision">Number of decimal places.</param>
        /// <returns>Formatted data string.</returns>
        public static string FormatDataSize(this long value, int precision = 2) => value.HumanizeData(null, precision);
        /// <summary>
        /// Formats data byte(s) to human readable format appending the appropriate <see cref="DataFormat"/>
        /// based on the bytes size.
        /// </summary>
        /// <param name="value">Bytes length/count.</param>
        /// <param name="format"></param>
        /// <param name="precision">Number of decimal places.</param>
        /// <returns>Formatted data string.</returns>
        public static string FormatBytes(this long value, DataFormat? format = null, int precision = 2) => value.HumanizeData(format, precision);
        /// <summary>
        /// Formats data byte(s) to human readable format appending the appropriate <see cref="DataFormat"/>
        /// based on the bytes size.
        /// </summary>
        /// <param name="value">Bytes length/count.</param>
        /// <param name="precision">Number of decimal places.</param>
        /// <returns>Formatted data string.</returns>
        public static string FormatBytes(this long value, int precision = 2) => value.HumanizeData(null, precision);
        /// <summary>
        /// Formats data byte(s) to human readable format appending the appropriate <see cref="DataFormat"/>
        /// based on the bytes size.
        /// </summary>
        /// <param name="value">Bytes length/count.</param>
        /// <param name="format"></param>
        /// <param name="precision">Number of decimal places.</param>
        /// <returns>Formatted data string.</returns>
        public static string HumanizeBytes(this long value, DataFormat? format = null, int precision = 2) => value.HumanizeData(format, precision);
        /// <summary>
        /// Formats data byte(s) to human readable format appending the appropriate <see cref="DataFormat"/>
        /// based on the bytes size.
        /// </summary>
        /// <param name="value">Bytes length/count.</param>
        /// <param name="precision">Number of decimal places.</param>
        /// <returns>Formatted data string.</returns>
        public static string HumanizeBytes(this long value, int precision = 2) => value.HumanizeData(null, precision);
    }
}