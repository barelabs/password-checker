using System.Collections.Generic;
using System.Linq;

namespace PasswordChecker
{
    class PasswordTest
    {
        private readonly string _fileInput;
        public List<string> InputPasswords { get; }
        public List<string> PasswordResults = new List<string>();

        //List of passwords to test against initialized through the constructor
        public PasswordTest(string fileInput)
        {
            _fileInput = fileInput;
            this.InputPasswords = this.LoadInputPasswords();
        }
        //Loads input passwords from file
        public List<string> LoadInputPasswords()
        {
            var readInPutFile = new FileReader();
            return readInPutFile.ReadFile(this._fileInput).ToList();
        }

        //Keeps track of password results after they have been tested
        public void AddPasswordResult(string passwordResult)
        {
            this.PasswordResults.Add(passwordResult);
        }
    }
}