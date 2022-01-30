using AdmissionsOfficeFinancialAidOffice;
using PrintingMailingServicesDepartment;
using System.IO;

namespace LetterSystem
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Simulator started!");
            Console.WriteLine("Please enter path of CombinedLetters folder, for example '..\\CombinedLetters'");
            string folderPath = Console.ReadLine();
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("CombinedLetters folder does not exist, press any button to exit");
                Console.ReadLine();
                return;
            }
            while (true)
            {
                Console.WriteLine("Please choose your action:");
                Console.WriteLine("Create Letters (A) | Combine letters (P) | Clean up (C) | End simulator and clean up (E) | End simulator without cleaning up (R)");
                string action = Console.ReadLine();
                if (action == "A")
                {
                    Console.WriteLine("Please enter current date, YYYYMMDD");
                    string currentDate = Console.ReadLine();
                    Console.WriteLine("Please enter number of admission letter");
                    int aNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter number of scholarship letter, note that number of scholarship letters must be less than the number of admission");
                    int sNumber = int.Parse(Console.ReadLine());
                    try
                    {
                        var office = new Office();
                        office.CreateLetters(folderPath, currentDate, aNumber, sNumber);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == "P")
                {
                    Console.WriteLine("Please enter current date, YYYYMMDD");
                    string currentDate = Console.ReadLine();
                    try
                    {
                        var letterService = new LetterService();
                        letterService.ProcessLetters(folderPath, currentDate);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == "C")
                {
                    CleanUp(folderPath);
                }
                else if (action == "E")
                {
                    CleanUp(folderPath);
                    return;
                }
                else if (action == "R")
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Clean up newly added files and directories.
        /// </summary>
        /// <param name="folderPath">path to CombinedLetters folder</param>
        public static void CleanUp(string folderPath)
        {
            string archiveFolder = Path.Combine(folderPath, "Archive");
            string[] archiveSubFolders = Directory.GetDirectories(archiveFolder);
            foreach (string subFolder in archiveSubFolders)
            {
                Directory.Delete(subFolder, true);
            }

            string outputFolder = Path.Combine(folderPath, "Output");
            string[] outputSubFolders = Directory.GetDirectories(outputFolder);
            foreach (string subFolder in outputSubFolders)
            {
                Directory.Delete(subFolder, true);
            }

            string inputAdmissionFolder = Path.Combine(folderPath, "Input", "Admission");
            string inputScholarshipFolder = Path.Combine(folderPath, "Input", "Scholarship");
            string[] inputAdmissionSubFolders = Directory.GetDirectories(inputAdmissionFolder);
            string[] inputScholarshipSubFolders = Directory.GetDirectories(inputScholarshipFolder);
            foreach (string subFolder in inputAdmissionSubFolders)
            {
                Directory.Delete(subFolder, true);
            }
            foreach (string subFolder in inputScholarshipSubFolders)
            {
                Directory.Delete(subFolder, true);
            }
        }
    }
}
























//class TryFinallyTest
//{
//    static void ProcessString(string s)
//    {
//        if (s != null)
//        {
//            throw new ArgumentNullException(paramName: nameof(s), message: "parameter can't be null.");
//        }
//        Console.WriteLine("I'm here");
//    }

//    public static void Main()
//    {
//        string s = "5"; // For demonstration purposes.

//        try
//        {
//            ProcessString(s);
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine("{0} Exception caught.", e);
//        }
//    }
//}

//string[] fileEntries = Directory.GetFiles(".vs");
//Random random = new Random();
//foreach (string entry in fileEntries)
//{
//    int randID = random.Next(100000000);
//    string file = Path.Combine("dsfdasdfsfsaf", $"admission-{randID.ToString("D8")}.txt");
//    Console.WriteLine(file);
//    Console.WriteLine(file.Substring(file.Length - 12, 8));
//}

//try
//{
//    var office = new Office();
//    office.CreateLetters(".\\CombinedLetters", 20220125.ToString(), 10, 5);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    var letterService = new LetterService();
//    letterService.ProcessLetters(".\\CombinedLetters", 20220126.ToString());
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//string file1 = "admission-19531219.txt";
//string file2 = "scholarship-19531219.txt";
//string file1path = Path.Combine("./CombinedLetters/Input/Admission/20220125", file1);
//string file2path = Path.Combine("./CombinedLetters/Input/Scholarship/20220125", file2);
//string resultfile = "combined-19531219.txt";

//var letterService = new LetterService();
//letterService.CombineTwoLetters(file1path, file2path, resultfile);


//Directory.CreateDirectory("./Test");

//string date = "20200125";
//string cdate = $"{date.Substring(4, 2)}/{date.Substring(6, 2)}/{date.Substring(0, 4)}Report";
//Console.WriteLine(cdate);
//Console.WriteLine(new string('-', 30));

//string currentDate = "20200125";
//using (StreamWriter sw = File.CreateText("test.txt"))
//{
//    sw.WriteLine($"{currentDate.Substring(4, 2)}/{currentDate.Substring(6, 2)}/{currentDate.Substring(0, 4)} Report");
//    sw.WriteLine(new string('-', 30));
//    sw.WriteLine("");
//    sw.WriteLine($"Number of Combined Letter: 0");
//}
//string lineToWrite = null;
//using (StreamReader sr = File.OpenText("test.txt"))
//{
//    for (int i = 0; i < 4; i++)
//    {
//        lineToWrite = sr.ReadLine();
//    }
//}
//Console.WriteLine(lineToWrite);
//Console.WriteLine(int.Parse(lineToWrite.Substring(lineToWrite.Length - 1)));
