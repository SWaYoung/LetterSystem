using System.IO;

namespace PrintingMailingServicesDepartment
{
    public interface ILetterService
    {
        void CombineTwoLetters(string inputFile1, string inputFile2, string resultFile);
    }

    public class LetterService
    {
        /// <summary>
        /// process letters
        /// </summary>
        /// <param name="folderPath">path of CombinedLetters folder</param>
        /// <param name="date">urrent date, for example "20200125"</param>
        public void ProcessLetters(string folderPath, string date)
        {
            //check path
            if (!Directory.Exists(folderPath))
            {
                throw new Exception("Path does not exist.");
            }

        }


        /// <summary>
        /// combine an admission letter and a scholarshipt letter
        /// </summary>
        /// <param name="inputFile1">path of the admission letter</param>
        /// <param name="inputFile2">path of the scholarship letter, may not exist</param>
        /// <param name="resultFile"></param>
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
                //check if inputFile2(scholarship letter) exists
                if (File.Exists(inputFile2))
                {
                    //read from inputFile2
                    using (StreamReader sr = new StreamReader(inputFile2))
                    {
                        sw.WriteLine(sr.ReadLine());
                    }
                }
            }
        }
    }
}