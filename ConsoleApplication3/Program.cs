using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        string prefix = "";
        IList<KeyValuePair<string, int>> selectedAlphabets;

        public string Encrypt(string unencryptedString)
        {
            Program obj = new Program();
            string encrytedString = "";

            //Create key value pairs of alphabets and alphabet count (index)
            List<KeyValuePair<string, int>> alphabets = new List<KeyValuePair<string, int>>();
            alphabets.Add(new KeyValuePair<string, int>("a", 1));
            alphabets.Add(new KeyValuePair<string, int>("b", 2));
            alphabets.Add(new KeyValuePair<string, int>("c", 3));
            alphabets.Add(new KeyValuePair<string, int>("d", 4));
            alphabets.Add(new KeyValuePair<string, int>("e", 5));
            alphabets.Add(new KeyValuePair<string, int>("f", 6));
            alphabets.Add(new KeyValuePair<string, int>("g", 7));
            alphabets.Add(new KeyValuePair<string, int>("h", 8));
            alphabets.Add(new KeyValuePair<string, int>("i", 9));
            alphabets.Add(new KeyValuePair<string, int>("j", 10));
            alphabets.Add(new KeyValuePair<string, int>("k", 11));
            alphabets.Add(new KeyValuePair<string, int>("l", 12));
            alphabets.Add(new KeyValuePair<string, int>("m", 13));
            alphabets.Add(new KeyValuePair<string, int>("n", 14));
            alphabets.Add(new KeyValuePair<string, int>("o", 15));
            alphabets.Add(new KeyValuePair<string, int>("p", 16));
            alphabets.Add(new KeyValuePair<string, int>("q", 17));
            alphabets.Add(new KeyValuePair<string, int>("r", 18));
            alphabets.Add(new KeyValuePair<string, int>("s", 19));
            alphabets.Add(new KeyValuePair<string, int>("t", 20));
            alphabets.Add(new KeyValuePair<string, int>("u", 21));
            alphabets.Add(new KeyValuePair<string, int>("v", 22));
            alphabets.Add(new KeyValuePair<string, int>("w", 23));
            alphabets.Add(new KeyValuePair<string, int>("x", 24));
            alphabets.Add(new KeyValuePair<string, int>("y", 25));
            alphabets.Add(new KeyValuePair<string, int>("z", 26));


            ArrayList selectedLetters = new ArrayList();
            List<string> encryptedValues = new List<string>();

            //separate the unencrypted string into constituent lowercase characters
            char[] unencryptedChars = unencryptedString.ToLower().ToCharArray();

            //Iterate each character in unencrypted string
            foreach (var character in unencryptedChars)
            {
                //Select letters in the word from alphabets to get alphabet count (nth index)
                obj.selectedAlphabets = alphabets.Where(val => val.Key == character.ToString()).ToList();

                foreach (var alphabet in obj.selectedAlphabets)
                {
                    //Manipulate alphabet count (nth index) to find hash values
                    if (isOdd(alphabet.Value))
                    {
                        obj.prefix = "o";
                        obj.prefix += alphabet.Value * 3 + 1;
                        encryptedValues.Add(obj.prefix);
                    }
                    else
                    {
                        obj.prefix = "e";
                        obj.prefix += alphabet.Value / 2;
                        encryptedValues.Add(obj.prefix);
                    }
                }
            }

            //Join hash values together to evaluate encrypted string
            foreach (var value in encryptedValues)
            {
                encrytedString += value;
            }
            //encrytedString = performhash(n);
            Console.WriteLine(encrytedString);
            return encrytedString.ToString();
        }

        public string Decrypt(string encryptedString)
        {
            Program obj = new Program();
            string decryptedString = "";
            List<int> nValues = new List<int>();

            //Create key value pairs of alphabets and alphabet count (index)
            List<KeyValuePair<string, int>> alphabets = new List<KeyValuePair<string, int>>();
            alphabets.Add(new KeyValuePair<string, int>("a", 1));
            alphabets.Add(new KeyValuePair<string, int>("b", 2));
            alphabets.Add(new KeyValuePair<string, int>("c", 3));
            alphabets.Add(new KeyValuePair<string, int>("d", 4));
            alphabets.Add(new KeyValuePair<string, int>("e", 5));
            alphabets.Add(new KeyValuePair<string, int>("f", 6));
            alphabets.Add(new KeyValuePair<string, int>("g", 7));
            alphabets.Add(new KeyValuePair<string, int>("h", 8));
            alphabets.Add(new KeyValuePair<string, int>("i", 9));
            alphabets.Add(new KeyValuePair<string, int>("j", 10));
            alphabets.Add(new KeyValuePair<string, int>("k", 11));
            alphabets.Add(new KeyValuePair<string, int>("l", 12));
            alphabets.Add(new KeyValuePair<string, int>("m", 13));
            alphabets.Add(new KeyValuePair<string, int>("n", 14));
            alphabets.Add(new KeyValuePair<string, int>("o", 15));
            alphabets.Add(new KeyValuePair<string, int>("p", 16));
            alphabets.Add(new KeyValuePair<string, int>("q", 17));
            alphabets.Add(new KeyValuePair<string, int>("r", 18));
            alphabets.Add(new KeyValuePair<string, int>("s", 19));
            alphabets.Add(new KeyValuePair<string, int>("t", 20));
            alphabets.Add(new KeyValuePair<string, int>("u", 21));
            alphabets.Add(new KeyValuePair<string, int>("v", 22));
            alphabets.Add(new KeyValuePair<string, int>("w", 23));
            alphabets.Add(new KeyValuePair<string, int>("x", 24));
            alphabets.Add(new KeyValuePair<string, int>("y", 25));
            alphabets.Add(new KeyValuePair<string, int>("z", 26));

            if (!String.IsNullOrEmpty(encryptedString))
            {
                List<int> intList = new List<int>();

                //Divide the string into individual hashes
                string[] individualHash = Regex.Split(encryptedString, @"(?=o|e)").Where(s => s != String.Empty).ToArray<string>();

                foreach (var item in individualHash)
                {
                    if (item.StartsWith("o"))
                    {
                        //Remove prefix of odd indices and calculate nValues
                        string[] temp = item.Split('o');
                        foreach (var val in temp)
                        {
                            if (!String.IsNullOrEmpty(val))
                            {
                                nValues.Add((Int32.Parse(val) - 1) / 3);
                            }
                        }
                    }
                    else if (item.StartsWith("e"))
                    {
                        //Remove prefix even indices and calculate nValues
                        string[] temp = item.Split('e');
                        foreach (var val in temp)
                        {
                            if (!String.IsNullOrEmpty(val))
                            {
                                nValues.Add(int.Parse(val) * 2);
                            }
                        }
                    }
                }

                //Match nValues to actual alphabets 
                foreach (var item in nValues)
                {
                    obj.selectedAlphabets = alphabets.Where(val => val.Value == item).ToList();

                    //Join alphabets to form decrypted string
                    foreach (var alphabet in obj.selectedAlphabets)
                    {
                        decryptedString += alphabet.Key;
                    }
                }
            }
            Console.WriteLine(decryptedString);
            return decryptedString;
        }

        ///Helper method to check for Odd numbers
        ///@return bool
        public static bool isOdd(int num)
        {
            if (num % 2 != 0)
                return true;
            else { return false; }
        }

        public static string performhash(List<string> n)
        {
            string hashedWord = "";

            foreach (var item in n)
            {
                hashedWord += item;
            }
            return hashedWord;
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.Encrypt("timothy");
            obj.Decrypt("e10o28o40o46e10e4o76");
        }
    }
}
