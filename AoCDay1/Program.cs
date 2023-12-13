using System;
using System.IO;
using System.Collections;

public class FileReader
{
    public string[] ReadFile(String path)
    {
        string[] fileInput = new string[0];
        try
        {
            
            // Open the text file using a stream reader.
            using (var sr = new StreamReader(path))
            {
                // Read the stream as a string, and write the string to the console.
                String full_Text = "";
                full_Text =sr.ReadToEnd();
                fileInput = full_Text.Split("\r\n");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        return fileInput;
    }
}
class Program
{
      public int FindNumber(String line)
    {
        int number = 0;
        List<string> foundNumbers = new List<string>();
        foreach (char c in line)
        {
            if(char.IsDigit(c)){
                foundNumbers.Add(Char.ToString(c));
                
            }
        }
        String tempNumber = "Failed";
        if(foundNumbers.Count>=1){
            tempNumber = string.Concat(foundNumbers[0], foundNumbers[foundNumbers.Count-1]);
            Int32.TryParse(tempNumber, out number);
            //Console.WriteLine(tempNumber);
        }
        return number;

    }
      
    public static void Main()
    {
         Program p = new Program();
        string path = @"D:\.NetCode\Advent of Code\AoCDay1\AoCDay1\input.txt";
        FileReader inputText = new FileReader();
        string[]input = inputText.ReadFile(path);
        long sum = 0;
        foreach (string item in input)
        {
            int rightNumber = p.FindNumber(item);
            //Console.WriteLine(rightNumber);
            sum += rightNumber;
        }
        Console.WriteLine(sum);
    }


}