using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PasswordChecker
{
    class Program
    {

        static void Main()
        {
            var passwordTest = new PasswordTest("passwdin.txt");
            var passwordChecker = new Passw0rd();

            foreach (string password in passwordTest.InputPasswords)
            {
                var messageToPrint = passwordChecker.CheckPassword(password);
                Console.WriteLine(messageToPrint);
                passwordTest.AddPasswordResult($"{password} - {messageToPrint}");
            }
            //todo: need to output to file
            File.WriteAllLines("passwdout.txt", passwordTest.PasswordResults);
        }
    }

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

    class Passw0rd
    {
        private List<string> _oldPasswords;

        public string CheckPassword(string psswd)
        {
            var test = new FileReader();
            _oldPasswords = test.ReadFile("oldpasswd.txt");

            if (!CheckIfPreviousPasswordNotUsed(psswd))
            {
                return "Your password has been used within the last six password changes.  " +
                                "Please select a new password.";
            }

            if (!CheckIfAtLeastSixCharacters(psswd))
            {
                return "Your password must be at least six characters long.  Please choose a longer password.";
            }

            if (!CheckIfAtLeastOneUpperCase(psswd))
            {
                return "Your password must contain at least one upper case letter.";
            }

            if (!CheckIfAtLeastTwoLowerCase(psswd))
            {
                return "Your password must contain at least two lower case letters.";
            }

            if (!CheckIfAtLeastOneSpecialCharacter(psswd))
            {
                return "Your password must contain at least one special character.";
            }

            if (!CheckIfAtLeastOneDigit(psswd))
            {
                return "Your password must contain at least one digit.";
            }

            else
            {
                return "Password Accepted";
            }
        }

        private bool CheckIfAtLeastOneDigit(string psswd)
        {
            int numberOfDigits = 0;

            for (int i = 0; i < psswd.Length; i++)
            {
                if (char.IsDigit(psswd[i])) numberOfDigits++;
            }

            return numberOfDigits >= 1;
        }

        private bool CheckIfAtLeastOneSpecialCharacter(string psswd)
        {
            int numberOfSpecialCharacters = 0;

            for (int i = 0; i < psswd.Length; i++)
            {
                if (!char.IsLetterOrDigit(psswd[i])) numberOfSpecialCharacters++;
            }

            return numberOfSpecialCharacters >= 1;
        }

        private bool CheckIfAtLeastTwoLowerCase(string psswd)
        {
            int numberOfLowerCaseLetters = 0;

            for (int i = 0; i < psswd.Length; i++)
            {
                if (char.IsLower(psswd[i])) numberOfLowerCaseLetters++;
            }

            return numberOfLowerCaseLetters >= 2;
        }

        private bool CheckIfAtLeastOneUpperCase(string psswd)
        {
            int numberOfUpperCaseLetters = 0;

            for (int i = 0; i < psswd.Length; i++)
            {
                if (char.IsUpper(psswd[i])) numberOfUpperCaseLetters++;
            }

            return numberOfUpperCaseLetters >= 1;
        }

        private bool CheckIfAtLeastSixCharacters(string psswd)
        {
            var numberOfCharacters = psswd.Length;
            return numberOfCharacters >= 6;
        }

        private bool CheckIfPreviousPasswordNotUsed(string psswd)
        {
            return !_oldPasswords.Contains(psswd);
        }
    }

    class FileReader
    {
        public List<string> ReadFile(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath).ToList();
            }
            catch (IOException error)
            {
                Console.WriteLine("There was a problem with reading the file");
                Console.WriteLine(error.Message);
                return null;
            }
        }
    }
}