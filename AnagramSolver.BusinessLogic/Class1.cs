using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramSolver.BusinessLogic
{
    [Serializable]
    public class Anagram
    {
        public string Word { get; set; }
        public string PartOfSpeech { get; set; }

        public static void Deserialize(string path, List<Anagram> list)
        {
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                list = (List<Anagram>)binaryFormatter.Deserialize(stream);
            }
        }


    }

    public class AnagramRepository
    {
        const string path = @"zodynas.txt";
        //string currentDirectory = Directory.GetCurrentDirectory();
        public static void ViewWords()
        {

            // Hashset inicializacija
            HashSet<string> myhash1 = new HashSet<string>();

            // Failo skaitymas, paimamas pirmas stulpelis
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                //string[] strArray;
                while ((line = reader.ReadLine()) != null)
                {
                    string lines = line.Split('\t').First();
                    myhash1.Add(lines);
                }
            }

            // Konvertavimas is hashset i list
            List<string> hList = myhash1.ToList();
            var distinctList = hList.Distinct();

            // Print zodziu be pasikartojimu
            foreach(string val in distinctList)
            {
                Console.WriteLine(val);
            }

        }
    }
}
