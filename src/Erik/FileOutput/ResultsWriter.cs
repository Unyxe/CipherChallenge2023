using FileOutput;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement
{
    public class ResultsWriter : JSONWriter
    {
        private const string KEY = "ResultsDirectory";
        readonly string ResultsDirectory;
        public ResultsWriter()
        {
            if (ConfigurationManager.AppSettings[KEY] == null)
                throw new KeyNotFoundException($"No value for {KEY} found in app.config. Check that this key exists in the config file.");
            ResultsDirectory = ConfigurationManager.AppSettings[KEY] ?? "";
        }
        /// <summary>
        /// Writes the results of a cipher cracking to a file.
        /// </summary>
        /// <param name="challengeID">The ID of the challenge. Example: <c>2B</c>.
        /// <c>2B</c> will become <c>Challenge2B.json</c></param>
        /// <param name="ciphertext"></param>
        /// <param name="key"></param>
        /// <param name="plaintext"></param>
        /// <param name="cipherName">A string name of the cipher.</param>
        /// <param name="silent">Whether to prompt the user before overwriting files or creating directories.</param>
        public void WriteToFile(string challengeID, string ciphertext, string key, string plaintext, string cipherName, bool silent = false)
        {
            var data = new CipherFileData(ciphertext, key, plaintext, cipherName);
            WriteToFile(Path.Combine(ResultsDirectory, $"Challenge{challengeID}.json"), data, silent);
        }
    }
}
