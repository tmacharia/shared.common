using System;
using System.ComponentModel;
using System.IO;

namespace Common.IO
{
    /// <summary>
    /// Extension methods for all Streams.
    /// </summary>
    public static class StreamExts
    {
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