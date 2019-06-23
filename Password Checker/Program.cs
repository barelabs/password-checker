using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PasswordChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var passwordChecker = new Passw0rd("");
            var messageToPrint = passwordChecker.checkPassword("Hiddddddd");
            Console.WriteLine(messageToPrint);
        }
    }

    class Passw0rd
    {
        //private string newAttemptedPassword;
        private List<string> oldPasswords;

        public Passw0rd(string password)
        {
            //this.newAttemptedPassword = password;
        }

        public string checkPassword(string psswd)
        {
            var test = new FileReader();
            oldPasswords = test.ReadFile("oldpasswd.txt");

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

            else
            {
                return "Your password change has been successful!";
            }
        }

        private bool CheckIfAtLeastOneUpperCase(string psswd)
        {
            for (int i = 0; i < psswd.Length; i++)
            {
                //This loop exits as soon as one upper case is found,
                //since the requirements state only one upper case letter is required
                if (char.IsUpper(psswd[i])) return true;
            }

            return false;
        }

        private bool CheckIfAtLeastSixCharacters(string psswd)
        {
            var numberOfCharacters = psswd.Length;
            return numberOfCharacters >= 6;
        }

        private bool CheckIfPreviousPasswordNotUsed(string psswd)
        {
            return !oldPasswords.Contains(psswd);
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