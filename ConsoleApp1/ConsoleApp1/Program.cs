using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> matches = new Dictionary<string, string>();
            string[,] table = new string[26,26];
            List<string> letters = new List<string>();
            //fill letters
            for(int i=65; i <= 90; i++)
            {
                char chr = (char)i;
                letters.Add(Convert.ToString(chr));
            }
            List<string> emojis = new List<string>() {
                ":)",":]",":3",":>","8)",":}","=]","=)","=D","=3",":D","8D","xD","XD",":o",":O",":×",":*",":(",":c",":<",":[",":{","D=",";]",";)"
            };

            //create letter and emoji match
           for(int i = 0; i < 26; i++)
            {
                matches.Add(letters[i], emojis[i]);
            }

            //create 2 table 
           for(int i = 0; i < 26; i++)
            {
                for (int j = i; j < 26+i; j++)
                {
                    if (j > 25)
                    {
                        table[i, j-i] = emojis[j - 26];
                    }
                    else
                    {
                        table[i, j-i] = emojis[j];
                    }
                }
            }

           //print table

            Console.Write("     ");

            for (int k = 0; k < 26; k++)
            {
                Console.Write(emojis[k] + " ");

            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");

            for (int i = 0; i < 26; i++)
            {
                Console.Write(emojis[i] + " | ");
                for (int j = 0; j < 26; j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            //Main Functions

            Console.WriteLine("Please enter plain text");
            string plainText = Console.ReadLine();
            string filteredPlainText="";
            Console.WriteLine("Please enter key");
            string key;
            string filteredKey = "";
            key = Console.ReadLine();
            while (key.Length > plainText.Length)
            {
                Console.WriteLine("length of key must be smaller than plaintext, type again");
                key = Console.ReadLine();
            }

            //filter plainText and key from non-letter characters and make uppercase
            foreach (char item in plainText)
            {
                if (char.IsLetter(item))
                {
                    filteredPlainText += item;
                }
            }
            plainText = filteredPlainText.ToUpper();
            foreach (char item in key)
            {
                if (char.IsLetter(item))
                {
                    filteredKey += item;
                }
            }
            key = filteredKey.ToUpper();

            //make plainText and key length equal (with extending key)
            for (int i = 0; i < plainText.Length / key.Length; i++)
            {
                key += key;
            }

            if(plainText.Length % key.Length != 0)
            {
                for (int i = 0; i < plainText.Length % key.Length; i++)
                {
                    key += key[i];
                }
            }

            //finding matching emojis of plaintText and key. Then, finding their interception point in table and print emoji text
            string plainTextMatch;
            string keyMatch;
            string emojiAnswer = "";
            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextMatch = matches[Convert.ToString(plainText[i])];
                keyMatch = matches[Convert.ToString(key[i])];
                emojiAnswer += table[emojis.IndexOf(plainTextMatch), emojis.IndexOf(keyMatch)];
            }
            Console.WriteLine();
            Console.WriteLine("Encrypted text: " + emojiAnswer);
        }
    }
}
