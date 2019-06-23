using System.Collections.Generic;
using System.Linq;

namespace PasswordChecker
{
    class PasswordTest
    {
        private readonly string _fileInput;
        public List<string> InputPasswords { get; }
        public List<string> PasswordResults = new List<string>();

        public PasswordTest(string fileInput)
        {
            _fileInput = fileInput;
            this.InputPasswords = this.LoadInputPasswords();
        }
        public List<string> LoadInputPasswords()
        {
            var readInPutFile = new FileReader();
            return readInPutFile.ReadFile(this._fileInput).ToList();
        }

        public void AddPasswordResult(string passwordResult)
        {
            this.PasswordResults.Add(passwordResult);
        }
    }
}