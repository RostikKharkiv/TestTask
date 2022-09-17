using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal static class WordCounter
    {
        private static string[] _text;
        public static Dictionary<string, int> Words = new Dictionary<string, int>();

        private static void ReadFile()
        {
            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\text.txt"))
            {
                string text = sr.ReadToEnd();
                _text = text.Split(new char[] { ' ', ',', '.', ':', ';', '?', '!'});
            }
        }

        public static void CheckWords()
        {
            ReadFile();

            foreach (string word in _text)
            {
                if (!Words.ContainsKey(word))
                {
                    Words.Add(word, 1);
                }
                else if (Words.ContainsKey(word))
                {
                    Words[word] = Words[word] + 1;
                }
            }
        }

        public static void WriteWordsToFile()
        {
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\result.txt"))
            {
                foreach (var word in Words.OrderByDescending(word => word.Value))
                {
                    sw.WriteLine($"{word.Key, -30} {word.Value}");
                }
            }
        }
    }
}
