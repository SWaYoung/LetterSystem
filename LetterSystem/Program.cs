using AdmissionsOfficeFinancialAidOffice;
using PrintingMailingServicesDepartment;
using System.IO;

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

try
{
    var office = new Office();
    office.CreateLetters(".\\CombinedLetters", 20220125.ToString(), 10, 5);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    var letterService = new LetterService();
    letterService.ProcessLetters(".\\CombinedLetters", 20220126.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

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
