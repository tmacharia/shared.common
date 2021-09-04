using System.IO;

namespace System
{
    /// <summary>
    /// Event handler delegate with no parameters and returns void.
    /// </summary>
    public delegate void EmptyEventHandler();
    /// <summary>
    /// Event handler delegate that receives an <see cref="int"/> parameter
    /// and returns void.
    /// </summary>
    /// <param name="n"></param>
    public delegate void IntEventHandler(int n);
    /// <summary>
    /// Event handler delegate that receives a <see cref="bool"/> parameter
    /// and returns void.
    /// </summary>
    /// <param name="b"></param>
    public delegate void BoolEventHandler(bool b);
    /// <summary>
    /// Event handler delegate that receives a <see cref="string"/> parameter
    /// and returns void.
    /// </summary>
    /// <param name="s"></param>
    public delegate void StringEventHandler(string s);
    /// <summary>
    /// Event handler delegate that receives a <see cref="decimal"/> parameter
    /// and returns void.
    /// </summary>
    /// <param name="d"></param>
    public delegate void DecimalEventHandler(decimal d);
    /// <summary>
    /// Event handler delegate that receives a <see cref="double"/> parameter
    /// and returns void.
    /// </summary>
    /// <param name="d"></param>
    public delegate void DoubleEventHandler(double d);
    /// <summary>
    /// Event handler delegate that receives a <see cref="byte"/> array parameter
    /// and returns void.
    /// </summary>
    /// <param name="bytes"></param>
    public delegate void BytesEventHandler(byte[] bytes);
    /// <summary>
    /// Event handler delegate that receives a <see cref="Stream"/> parameter
    /// and returns void.
    /// </summary>
    /// <param name="stream"></param>
    public delegate void StreamEventHandler(Stream stream);
}