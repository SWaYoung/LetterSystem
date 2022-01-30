using System.IO;

namespace PrintingMailingServicesDepartment
{
    public interface ILetterService
    {
        void CombineTwoLetters(string inputFile1, string inputFile2, string resultFile);
    }

    public class LetterService
    {
        public void CombineTwoLetters(string inputFile1, string inputFile2, string resultFile)
        {   
            //create and write to resultFile
            using(StreamWriter sw = File.CreateText(resultFile))
            {   
                //read from inputFile1
                using(StreamReader sr = new StreamReader(inputFile1))
                {
                    sw.WriteLine(sr.ReadLine());
                }
                //read from inputFile2
                using(StreamReader sr = new StreamReader(inputFile2))
                {
                    sw.WriteLine(sr.ReadLine());
                }
            }
        }
    }
}