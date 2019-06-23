using System.Collections.Generic;

namespace PasswordChecker
{
    class Passw0rd
    {
        //List of old passwords to test against, to ensure user cannot use same password within last 6 times
        //This list comes from a file called oldpasswd.txt below.  This file is hardcoded in this class
        //to mimic the idea that a user cannot provide a list of old passwords.  In a production implementation,
        //the old passwords would be hashed and come from a database.
        private List<string> _oldPasswords;

        public Passw0rd()
        {
            this._oldPasswords = ImportOldPasswords();
        }

        public string checkPassword(string psswd)
        {

            if (!CheckIfPreviousPasswordNotUsed(psswd))
            {
                return "Your password has been used within the last six password changes.  " +
                       "Please select a new password.";
            }

            if (!CheckIfAtLeastSixCharacters(psswd))
            {
                return "Password should be at least 6 characters strong.";
            }

            if (!CheckIfAtLeastOneUpperCase(psswd))
            {
                return "Password should contain at least one upper case letter.";
            }

            if (!CheckIfAtLeastTwoLowerCase(psswd))
            {
                return "Password should contain at least TWO lower case letters.";
            }

            if (!CheckIfAtLeastOneSpecialCharacter(psswd))
            {
                return "Password should have at least one special character.";
            }

            if (!CheckIfAtLeastOneDigit(psswd))
            {
                return "Password should contain at least one digit.";
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

        private List<string> ImportOldPasswords()
        {
            var test = new FileReader();
            return test.ReadFile("oldpasswd.txt");
        }
    }
}