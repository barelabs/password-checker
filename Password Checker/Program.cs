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
            Console.WriteLine("Hello World!");
            var test = new FileReader();
            test.ReadFile("oldpasswd.txt");
        }
    }

    class Passw0rd
    {
        private readonly string password;

        public Passw0rd(string password)
        {
            this.password = password;
        }

        public string checkPassword(string psswd)
        {
            return null;
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