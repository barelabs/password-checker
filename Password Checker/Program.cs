using System;
using System.IO;

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
                var messageToPrint = passwordChecker.checkPassword(password);
                Console.WriteLine(messageToPrint);
                passwordTest.AddPasswordResult($"{password} - {messageToPrint}");
            }
            //todo: need to output to file
            File.WriteAllLines("passwdout.txt", passwordTest.PasswordResults);
        }
    }
}