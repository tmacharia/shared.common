using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Represents an interface for a custom Http Handler.
    /// </summary>
    public interface IHttpHandler : IDisposable
    {
        /// <summary>
        /// Base/Root Address
        /// </summary>
        Uri BaseAddress { get; set; }
        /// <summary>
        /// Adds a header item to the default request headers.
        /// </summary>
        /// <param name="key">Header name</param>
        /// <param name="value">Header value</param>
        void AddHeader(string key, string value);
        /// <summary>
        /// Runs a Http GET request.
        /// </summary>
        /// <param name="uri">Uri resource/route</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetAsync(Uri uri);
        /// <summary>
        /// Runs a Http POST request
        /// </summary>
        /// <param name="uri">Uri resource/route</param>
        /// <param name="content">Body content to post.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content);
    }
}