﻿using System;
using System.IO;
using System.Collections;

/// <summary>
/// FileReader is a class with one function. The function takes in an string containing the location of the file to be read. 
/// The function returns an String array with each read line.
/// For my own conveience the path i using is just put into class Programs Main.
/// This will ned to be change for testing other files or for other people trying the program.
/// The function ReadFile reads the entire file and than split each line into an seperate string in the array.
/// </summary>
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
                // Read the stream as a string.
                String full_Text = "";
                full_Text =sr.ReadToEnd();
                //Split String
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
    /// <summary>
    /// Function that takes in a string and finds all numbers in it, than combines the first found number and last found number into a 2 diget number. 
    /// returns the value of the 2 diget number.
    /// </summary>
    /// <param name="line"><String to look for numbers in>
    /// <returns><2 diget number made by the first and the last found number i line>
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

    /// <summary>
    /// Function that takes in a string and finds all numbers in it( now also with spelled numbers like "One"), 
    /// than combines the first found number and last found number into a 2 diget number. 
    /// returns the value of the 2 diget number.
    /// </summary>
    /// <param name="line"><String to look for numbers in>
    /// <returns><2 diget number made by the first and the last found number i line>
      public int FindNumberAdvansed(String line)
    {
        int number = 0;
        List<string> foundNumbers = new List<string>();
        int startpos = 0;   //posision in line for start of substring
        foreach (char c in line)
        {
            //First check for number.
            if(char.IsDigit(c))
            {
                foundNumbers.Add(Char.ToString(c));
                
            }else if("o" == c.ToString() & (line.Length -startpos) >=3) //Check for substring "one"
            {
                if(line.Substring(startpos, 3) == "one")
                {
                    foundNumbers.Add("1");
                }
            }else if("t" == c.ToString()) //Check for substring "two" and "three"
            {
                if((line.Length -startpos) >=3)
                {
                    if(line.Substring(startpos, 3) == "two")
                    {
                      foundNumbers.Add("2");
                    }
                }
                if((line.Length -startpos) >=5)
                {
                    if(line.Substring(startpos, 5) == "three")
                    {
                        foundNumbers.Add("3");
                    }
                }
            }else if("f" == c.ToString()) //Check for substring "four" and "five"
            {
                if((line.Length -startpos) >=4)
                {
                    if(line.Substring(startpos, 4) == "four")
                    {
                        foundNumbers.Add("4");
                    }
                }
                if((line.Length -startpos) >=4)
                {
                    if(line.Substring(startpos, 4) == "five")
                    {
                        foundNumbers.Add("5");
                    }
                }
            }else if("s" == c.ToString()) //Check for substring "six" and "seven"
            {
                if((line.Length -startpos) >=3)
                {
                    if(line.Substring(startpos, 3) == "six")
                    {
                        foundNumbers.Add("6");
                    }
                }
                if((line.Length -startpos) >=5)
                {
                    if(line.Substring(startpos, 5) == "seven")
                    {
                        foundNumbers.Add("7");
                    }
                }
            }else if("e" == c.ToString() & (line.Length -startpos) >=5) //Check for substring "eight"
            {
                if(line.Substring(startpos, 5) == "eight")
                {
                    foundNumbers.Add("8");
                }
            }else if("n" == c.ToString() & (line.Length -startpos) >=4) //Check for substring "nine"
            {
                if(line.Substring(startpos, 4) == "nine")
                {
                    foundNumbers.Add("9");
                }
            }
            
            startpos += 1;
        }
        String tempNumber = "Failed";
        if(foundNumbers.Count>=1) //Combine first and last number found
        {
            tempNumber = string.Concat(foundNumbers[0], foundNumbers[foundNumbers.Count-1]);
            Int32.TryParse(tempNumber, out number);
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
        Console.WriteLine("Start of Part1");
        foreach (string item in input)
        {
            int rightNumber = p.FindNumber(item);
            sum += rightNumber;
        }
        Console.WriteLine(sum);
        sum = 0;
        Console.WriteLine("Start of Part2");
        foreach (string item in input)
        {
            int rightNumber = p.FindNumberAdvansed(item);
            sum += rightNumber;
        }
        Console.WriteLine(sum);
    }


}