using System;

namespace AnagramSolver.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Displaying file content: ");
            BusinessLogic.AnagramRepository.ViewWords();

        }
    }
}
