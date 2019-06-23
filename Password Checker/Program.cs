using System;
using System.IO;

namespace PasswordChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var test = new FileReader();
            test.ReadFile();
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
        public void ReadFile()
        {
            try
            {   
                using (StreamReader streamReader = new StreamReader("oldpasswd.txt"))
                {
                    string textLine = streamReader.ReadToEnd();
                    Console.WriteLine(textLine);
                }
            }
            catch (IOException error)
            {
                Console.WriteLine("There was a problem with reading the file");
                Console.WriteLine(error.Message);
            }
        }
    }
}