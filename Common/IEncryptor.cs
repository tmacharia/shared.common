namespace Common
{
    /// <summary>
    /// Represents an interface with a list of encryption and decryption methods.
    /// </summary>
    public interface IEncryptor
    {
        /// <summary>
        /// Generates the MD5 hash of the specified <see cref="string"/> text.
        /// </summary>
        /// <param name="plaintext">Text to convert.</param>
        /// <returns>MD5 hash</returns>
        string GetMD5(string plaintext);
        /// <summary>
        /// Encrypts a <see cref="string"/> of plaintext using RSA algorithm
        /// into ciphertext
        /// </summary>
        /// <param name="plainText">Block of text to encrypt</param>
        /// <returns>
        ///     Base64 encoded ciphertext
        /// </returns>
        string Encrypt(string plainText);
        /// <summary>
        /// Decrypts a <see cref="string"/> of ciphertext using RSA algorithm
        /// into plaintext
        /// </summary>
        /// <param name="cipherText">Block of text to decrypt</param>
        /// <returns>
        ///     Plaintext
        /// </returns>
        string Decrypt(string cipherText);
        /// <summary>
        /// Encrypts a block of text using RSA algorithm from the public key 
        /// in the certificate file provided.
        /// </summary>
        /// <param name="plainText">Block of text to encrypt</param>
        /// <param name="certificatePath">File path to the Public Key Certificate
        /// on the current machine.
        /// </param>
        /// <returns>
        ///     Base64 encoded ciphertext
        /// </returns>
        string Encrypt(string plainText, string certificatePath);
        /// <summary>
        /// Decrypts a block of ciphertext using RSA algorithm from the public key 
        /// in the certificate file provided.
        /// </summary>
        /// <param name="cipherText">Block of ciphertext to decrypt</param>
        /// <param name="certicatePath">File path to the Public Key Certificate
        /// on the current machine.
        /// </param>
        /// <returns>
        ///     Plaintext
        /// </returns>
        string Decrypt(string cipherText, string certicatePath);
    }
}