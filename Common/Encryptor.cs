using Common.Structs;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Common
{
    /// <summary>
    /// Contains encyption and decryption methods.
    /// </summary>
    public class Encryptor : IEncryptor
    {
        private static readonly RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider();

        /// <summary>
        /// Gets the MD5 Hash of a specified text.
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns>MD5 Hash</returns>
        public string GetMD5(string plaintext)
        {
            byte[] bytes = GeneralUtils.md5.ComputeHash(plaintext.ToByteArray());

            return BitConverter.ToString(bytes)
                               .Replace("-", string.Empty)
                               .ToLower(Constants.Culture);
        }
        /// <summary>
        /// Encrypts plaintext to ciphertext
        /// </summary>
        /// <param name="plainText">Human readable text.</param>
        /// <returns>Ciphertext</returns>
        public string Encrypt(string plainText) =>
                      cryptoServiceProvider.Encrypt(plainText.ToByteArray(), RSAEncryptionPadding.Pkcs1).ToBase64String();
        /// <summary>
        /// Decrypts ciphertext to plaintext
        /// </summary>
        /// <param name="cipherText">Ciphertext.</param>
        /// <returns>Plaintext</returns>
        public string Decrypt(string cipherText) =>
                      cryptoServiceProvider.Decrypt(cipherText.FromBase64ToArray(), RSAEncryptionPadding.Pkcs1).ConvertToString();

        /// <summary>
        /// Encrypt plaintext to ciphertext using an X509 certificate
        /// </summary>
        /// <param name="plainText">Human readable text</param>
        /// <param name="certificatePath">Absolute path to certificate file.</param>
        /// <returns>Ciphertext</returns>
        public string Encrypt(string plainText, string certificatePath)
        {
            byte[] bytes = plainText.ToByteArray();

            // Load X509 Certificate from file
            X509Certificate2 certificate = new X509Certificate2(certificatePath);
            
            // Use certificate to get RSA algorithm to use with it
            RSA pub_key = certificate.GetRSAPublicKey();
            
            // Use PKCS padding mode instead of OAEP
            RSAEncryptionPadding padding = RSAEncryptionPadding.Pkcs1;
            
            byte[] final = pub_key.Encrypt(bytes, padding);

            return final.ToBase64String();
        }
        /// <summary>
        /// Decrypts ciphertext to plaintext using an X509 certificate
        /// </summary>
        /// <param name="cipherText">Ciphertext</param>
        /// <param name="certificatePath">Absolute path to certificate file.</param>
        /// <returns>Plaintext</returns>
        public string Decrypt(string cipherText, string certificatePath)
        {
            byte[] hash = cipherText.FromBase64ToArray();

            // Load X509 Certificate from file
            var cer = X509Certificate.CreateFromSignedFile(certificatePath);
            
            X509Certificate2 certificate = new X509Certificate2(certificatePath,string.Empty);
            // Use certificate to get RSA algorithm to use with it
            RSA pub_key = certificate.GetRSAPublicKey();
            // Use PKCS padding mode instead of OAEP
            RSAEncryptionPadding padding = RSAEncryptionPadding.Pkcs1;

            byte[] final = pub_key.Decrypt(hash, padding);
            
            return hash.ConvertToString();
        }
    }
}