using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WizKidsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Console.WriteLine(isStringPalindrome("baaab"));
            //Console.WriteLine(isStringPalindrome("bbaab"));
            //fooBarGame();
            fixEmail("Christian has the email address christian+123@gmail.com. Christian's friend, John Cave-Brown, has the email address john.cave-brown@gmail.com. John's daughter Kira studies at Oxford University and has the email adress Kira123@oxford.co.uk. Her Twitter handle is @kira.cavebrown.");
            damerauLevenshtein("test");
            Console.ReadKey();

        }

        public static void damerauLevenshtein(String input)
        {
            string alph = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < input.Length + 1; i++)
            {

                string todel = input;
                if (i < input.Length)
                {
                    todel = input.Remove(i, 1);
                    Console.WriteLine(todel);
                    if (i > 0)
                    {
                        char a = input[i], b = input[i - 1];
                        char[] ch1 = input.ToCharArray();
                        ch1[i] = b;
                        ch1[i - 1] = a;
                        string chx = new string(ch1);
                        Console.WriteLine(chx);
                    }
                }

                for (int j = 0; j < alph.Length; j++)
                {
                    string ch = input;
                    ch = ch.Insert(i, alph[j] + "");
                    if (i < input.Length)
                    {
                        char[] ch1 = input.ToCharArray();
                        ch1[i] = alph[j];
                        string chx = new string(ch1);
                        Console.WriteLine(chx);
                    }

                    Console.WriteLine(ch);
                }
            }
            long deledChar = input.Length;
            long inseredChars = alph.Length * (deledChar + 1);
            long switchedChars = deledChar - 1;
            long replacedChar = alph.Length * deledChar;

            long sum =  deledChar + inseredChars + switchedChars + replacedChar;
            Console.WriteLine("alternatives number from {0} is {1}", input, sum);
        }

        public static String fixEmail(String input)
        {
            String[] inputWords = input.Split(' ');
            foreach (var word in inputWords)
            {
                if (word.Contains('@'))
                {
                    try
                    {
                        var mailAddress = new MailAddress(word);
                        Console.WriteLine("the adress {0} is valid", mailAddress);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return "";
        }

        public static void fooBarGame()
        {
            for (int i = 1; i < 100; i++)
            {
                if ((i % 3 == 0) && (i % 5 == 0))
                {
                    Console.WriteLine("FooBar");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Foo");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Bar");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static bool isStringPalindrome(String input)
        {
            char[] inputArray = input.ToCharArray();
            Array.Reverse(inputArray);
            var reversed = new string(inputArray);
            return String.Compare(input, reversed, true) == 0;
        }
    }
}
