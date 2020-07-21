using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;

namespace AnagramSolver.BusinessLogic
{
    [Serializable]
    public class Anagram
    {
        public string Word { get; set; }
        public string PartOfSpeech { get; set; }

        public override string ToString()
        {
            return "\n" + $"{Word}, {PartOfSpeech}";
        }


    }

    public class AnagramRepository
    {
        const string path = @"./zodynas.txt";

        // Input zodzio sortinimas pagal abeceles tvarka

        public static string SortByAlphabet(string inputWord)
        {
            char[] convertedToChar = inputWord.ToCharArray();
            Array.Sort(convertedToChar);

            return new string(convertedToChar);
        }

        // Zodziu rodymas 
        public static List<Anagram> GetWords()
        {

            // Dictionary inicializacija

            var dictionary = new Dictionary<string, string>();


            // Failo skaitymas
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string word = line.Split('\t').First();
                    string PartOfSpeech = line.Split('\t').ElementAt(1);

                    if (!dictionary.ContainsKey(word))
                    {
                        dictionary.Add(word, PartOfSpeech);
                    }
                }
;            }


            List<Anagram> myList = new List<Anagram>();

            foreach(var keyValuePair in dictionary)
            {
                //Console.WriteLine(keyValuePair.Key);
                //Console.WriteLine(keyValuePair.Value);
                myList.Add(new Anagram { Word = keyValuePair.Key, PartOfSpeech = keyValuePair.Value });
            }


            var pattern = string.Join(",", myList.Select(cff => cff.ToString()));
            Console.WriteLine(pattern);

            return myList;

        }


        // Zodyno metodas

        public static Dictionary<string, string> MakeDictionary()
        {
            var dictionary = new Dictionary<string, string>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string word = line.Split('\t').First();
                    string value;

                    string sortedWord = SortByAlphabet(word);
                    //Console.WriteLine("SORTED" + sortedWord);

                    if (dictionary.TryGetValue(sortedWord, out value))
                    {
                        dictionary[sortedWord] = word;
                    }
                    else
                    {
                        dictionary.Add(sortedWord, word);
                    }
                }
            }

            return dictionary;
        }

        public static void ReturnAnagram(Dictionary<string, string> dictionary, string inputWord)
        {
            string value;
            string sortedInputWord = SortByAlphabet(inputWord);

            if (dictionary.TryGetValue(sortedInputWord, out value))
            {
                Console.WriteLine("Anagram is found: " + "\n" + value);
            }
            else
            {
                Console.WriteLine("Word do not exist in dictionary, please try another one.");
                //Console.ReadLine();
            }

            //while(!dictionary.TryGetValue(sortedInputWord, out value))
            //{
                //Console.WriteLine("Word do not exist in dictionary, please try another one.");
                //Console.ReadLine();
            //}

            //Console.WriteLine("Anagram is found: " + "\n" + value);

        }

        public static void GetAnagrams(List<Anagram> list, string inputWord)
        {
            string sortedInputWord = SortByAlphabet(inputWord);
            var dictionary = list.ToDictionary(x => x, x => x);



        }


    }

    public class AnagramSolver
    {
        public static List<string> GetAnagrams(string myWords)
        {
            List<string> list = new List<string>();
            return list;
        }
    }

    public interface IAnagramSolver
    {
        IList<string> GetAnagrams(string myWords);
    }
}
