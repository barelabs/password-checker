using System;
using System.IO;

namespace PasswordChecker
{
    class Program
    {
        //by Timothy Lang
        //June 23rd, 2019
        //ISEC 640
        //Dr. Ajoy Kumar
        static void Main()
        {
            //creates PasswordTest instance which provides set of passwords to test
            var passwordTest = new PasswordTest("passwdin.txt");

            //creates Passw0rd instance which is responsible for checking valid passwords
            //old passwords are also checked with this Passw0rd class
            var passwordChecker = new Passw0rd();

            foreach (string password in passwordTest.InputPasswords)
            {
                //writes returned messages to console
                var messageToPrint = passwordChecker.checkPassword(password);
                Console.WriteLine(messageToPrint);
                
                //stores password results in PasswordTest class
                passwordTest.AddPasswordResult($"{password} - {messageToPrint}");
            }

            //writes out password results to file
            File.WriteAllLines("passwdout.txt", passwordTest.PasswordResults);
        }
    }
}