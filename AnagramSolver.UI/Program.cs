using AnagramSolver.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramSolver.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Displaying file content: ");
            //BusinessLogic.AnagramRepository.GetWords();
            List<Anagram> wordsList = AnagramRepository.GetWords();
            //Console.WriteLine(wordsList);

            // Userio ivedimas
            //Console.Write("Input your word: ");
            //string inputWord = Console.ReadLine();

            // Issortiname pagal abecele
            //string sorted = BusinessLogic.AnagramRepository.SortByAlphabet(inputWord);
            //Console.Write("Sorted input: " + "\n" + sorted);

            // 2as bandymas
            var dictionary = BusinessLogic.AnagramRepository.MakeDictionary();
            Console.WriteLine("Input your word for solution: ");
            string solution = Console.ReadLine();

            BusinessLogic.AnagramRepository.ReturnAnagram(dictionary, solution);

        }
    }
}
