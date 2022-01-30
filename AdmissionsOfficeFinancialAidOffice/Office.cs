using System.IO;

namespace AdmissionsOfficeFinancialAidOffice
{
    public class Office
    {
        /// <summary>
        /// Generate letters for admission and scholarship
        /// </summary>
        /// <param name="folderPath">path of CombinedLetters folder</param>
        /// <param name="date">current date, for example "20200125"</param>
        /// <param name="aNumber">number of admission letters</param>
        /// <param name="sNumber">number of scholarship letters</param>
        /// <exception cref="Exception"></exception>
        public void CreateLetters(string folderPath, string date, int aNumber, int sNumber)
        {
            //check path
            if (!Directory.Exists(folderPath))
            {
                throw new Exception("Path does not exist.");
            }
            //combining path for admission folder
            string admissionFolder = Path.Combine(folderPath, "Input", "Admission", date);
            //create folder for current date
            Directory.CreateDirectory(admissionFolder);
            //Instantiate random number generator
            Random random = new Random();
            //create admission letters
            for (int i = 0; i < aNumber; i++)
            {   
                //create random ID
                //combining the path and create file
                string admissionLetter = Path.Combine(admissionFolder, $"admission-{random.Next(100000000).ToString("D8")}.txt");
                using(StreamWriter sw = File.CreateText(admissionLetter))
                {
                    sw.WriteLine(admissionLetter);
                }
            }

            //combining path for Scholarship folder
            string scholarshipFolder = Path.Combine(folderPath,"Input", "Scholarship", date);
            //create folder for current date
            Directory.CreateDirectory(scholarshipFolder);
            //get letter names in admission folder
            string[] admissionLetters = Directory.GetFiles(admissionFolder);
            for (int i=0; i<sNumber; i++)
            {
                // choose a random letter from admission and create scholarship letter
                // extract the student ID
                string studentID = ExtractID(admissionLetters[random.Next(aNumber)]);
                //create schoalrship letter
                string scholarshipLetter = Path.Combine(scholarshipFolder, $"scholarship-{studentID}.txt");
                using(StreamWriter sw = File.CreateText(scholarshipLetter))
                {
                    sw.WriteLine(scholarshipLetter);
                }
                
            }
        }

        /// <summary>
        /// take file path and return the student ID
        /// </summary>
        /// <param name="file_path">path of the file</param>
        /// <returns>return student ID</returns>
        public static string ExtractID(string file_path)
        {
            return file_path.Substring(file_path.Length-12, 8);
        }
    }
}