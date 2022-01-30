using System.IO;
using AdmissionsOfficeFinancialAidOffice;

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
        /// <param name="currentDate">current date when the combination process starts, for example "20200125"</param>
        public void ProcessLetters(string folderPath, string currentDate)
        {
            //check path
            if (!Directory.Exists(folderPath))
            {
                throw new Exception("Path does not exist.");
            }

            //combine and get Admission folder and Scholarship folder
            string admissionFolder = Path.Combine(folderPath, "Input", "Admission");
            string scholarshipFolder = Path.Combine(folderPath, "Input", "Scholarship");

            //get a list of date that has not been combined yet
            string[] dateList = Directory.GetDirectories(admissionFolder);

            //check if there are uncombined letters, if there is no uncombined letter, just return
            if (!dateList.Any())
            {
                return;
            }

            //create date folders inside Archive and Output. If already exist, nothing happens.
            //notice the date is the currentDate
            string admissionArchiveFolder = Path.Combine(folderPath, "Archive", currentDate, "Admission");
            string scholarshipArchiveFolder = Path.Combine(folderPath, "Archive", currentDate, "Scholarship");
            string outputFolder = Path.Combine(folderPath, "Output", currentDate);
            Directory.CreateDirectory(admissionArchiveFolder);
            Directory.CreateDirectory(scholarshipArchiveFolder);
            Directory.CreateDirectory(outputFolder);

            //combine the path for report and reportTemp
            //notice the date is the currentDate
            string reportTemp = Path.Combine(folderPath, "Output", currentDate, "report-temp.txt");
            string report = Path.Combine(folderPath, "Output", currentDate, "report.txt");
            //check if an report for currentDate exsits, if not create a reportTemp, if exists rename to reportTemp
            if (!File.Exists(report))
            {
                using (StreamWriter sw = File.CreateText(reportTemp))
                {
                    sw.WriteLine($"{currentDate.Substring(4, 2)}/{currentDate.Substring(6, 2)}/{currentDate.Substring(0, 4)} Report");
                    sw.WriteLine(new string('-', 30));
                    sw.WriteLine("");
                    sw.WriteLine("Number of Combined Letter: 0");
                }
            }
            else
            {
                File.Move(report, reportTemp);
            }
            // get letterCounter from summary line in report
            string summaryLine = null;
            int letterCounter = 0;
            using (StreamReader sr = File.OpenText(reportTemp))
            {
                for (int i = 0; i < 4; i++)
                {
                    summaryLine = sr.ReadLine();
                }
                letterCounter = int.Parse(summaryLine.Substring(26));
            }
            //append report while combining letters
            using (StreamWriter sw = File.AppendText(reportTemp))
            {
                //loop over each date
                foreach (string datePath in dateList)
                {
                    string date = Path.GetFileName(datePath);
                    string[] admissionLetters = Directory.GetFiles(Path.Combine(admissionFolder, date));
                    foreach (string admissionLetter in admissionLetters)
                    {
                        //combine path for scholarship letter and combined letter
                        string studentID = Office.ExtractID(admissionLetter);
                        string scholarshipLetter = Path.Combine(scholarshipFolder, date, $"scholarship-{studentID}.txt");
                        string combinedLetter = Path.Combine(outputFolder, $"combined-{studentID}.txt");

                        // check if there is a corresponding scholarship letter
                        if (File.Exists(scholarshipLetter))
                        {
                            // if exist
                            // combine letters
                            CombineTwoLetters(admissionLetter, scholarshipLetter, combinedLetter);

                            //move admission letter and scholarship letter to Archive folder
                            File.Move(admissionLetter, Path.Combine(admissionArchiveFolder, Path.GetFileName(admissionLetter)));
                            File.Move(scholarshipLetter, Path.Combine(scholarshipArchiveFolder, Path.GetFileName(scholarshipLetter)));
                        }
                        else
                        {
                            //if no corresponding scholarship letter
                            //combine letters by pass scholarship letter as null
                            CombineTwoLetters(admissionLetter, null, combinedLetter);

                            //move admission letter to Archive folder
                            File.Move(admissionLetter, Path.Combine(admissionArchiveFolder, Path.GetFileName(admissionLetter)));
                        }

                        //append report with student ID
                        sw.WriteLine($"\t{studentID}");

                        //increment letterCounter by 1
                        letterCounter++;
                    }

                    //delete this admission folder and corresponding scholarship folder
                    Directory.Delete(Path.Combine(admissionFolder, date));
                    Directory.Delete(Path.Combine(scholarshipFolder, date));
                }
            }

            //create report with reportTemp by updating sumarry line using letterCount
            int lineNumber = 0;
            string line = null;
            using (StreamReader sr = File.OpenText(reportTemp))
            using (StreamWriter sw = File.CreateText(report))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (lineNumber == 3)
                    {
                        sw.WriteLine($"Number of Combined Letter: {letterCounter}");
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    lineNumber++;
                }
            }

            //delete reportTemp
            File.Delete(reportTemp);
        }


        /// <summary>
        /// combine an admission letter and a scholarshipt letter
        /// </summary>
        /// <param name="inputFile1">path of the admission letter</param>
        /// <param name="inputFile2">path of the corresponding scholarship letter, if no corresponding scholarship letter, pass null</param>
        /// <param name="resultFile"></param>
        public void CombineTwoLetters(string inputFile1, string inputFile2, string resultFile)
        {
            //create and write to resultFile
            using (StreamWriter sw = File.CreateText(resultFile))
            {
                //read from inputFile1
                using (StreamReader sr = new StreamReader(inputFile1))
                {
                    sw.WriteLine(sr.ReadLine());
                }

                //check if inputFile2(scholarship letter) is null
                if (inputFile2 != null)
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