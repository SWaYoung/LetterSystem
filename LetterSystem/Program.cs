using AdmissionsOfficeFinancialAidOffice;
using System.IO;

//Console.WriteLine("Enter path");
////var path1 = @"D:\Projects\LetterSystem\CombinedLetters";
//var path = @"" + Console.ReadLine();
////bool result = path1.Equals(path);
////Console.WriteLine(result);
////Console.WriteLine(path1);
////Console.WriteLine(path);
//var office = new Office();
//office.createFile(path);

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
    office.createFile("./CombinedLetters", 20220125.ToString(), 10, 5);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}