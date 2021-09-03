using Common;

namespace System.IO
{
    /// <summary>
    /// Extension methods for all Streams.
    /// </summary>
    public static class StreamExts
    {
        /// <summary>
        /// Converts a byte[] to its equivalent <see cref="string"/> of
        /// text using UTF encoding.
        /// </summary>
        /// <param name="bytes">byte array</param>
        /// <returns>
        /// <see cref="string"/> of text
        /// </returns>
        public static string ConvertToString(this byte[] bytes) => Constants.Encoding.GetString(bytes);
        /// <summary>
        /// Converts a stream of byte[] to a Base64 encoded
        /// <see cref="string"/> of text.
        /// </summary>
        /// <param name="bytes">Byte array</param>
        /// <returns>Base64 encoded <see cref="string"/></returns>
        public static string ToBase64String(this byte[] bytes) => Convert.ToBase64String(bytes);
        /// <summary>
        /// Converts a byte[] to a <see cref="Stream"/>
        /// </summary>
        /// <param name="bytes">Array of bytes to convert</param>
        /// <returns>A stream</returns>
        public static Stream ToStream(this byte[] bytes) => bytes != null ? new MemoryStream(bytes) : null;
        /// <summary>
        /// Converts any object that inherits from <see cref="Stream"/> to a 
        /// byte[]
        /// </summary>
        /// <param name="inputStream">Input stream.</param>
        /// <returns>Byte Array</returns>
        /// <exception cref="ArgumentNullException">If input stream is null</exception>
        public static byte[] ToArray(this Stream inputStream)
        {
            if (inputStream == null)
                throw new ArgumentNullException(nameof(inputStream));

            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}