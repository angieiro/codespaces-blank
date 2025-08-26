using System;

public class ReverseString
{
  public static void ReverseStringMain(String[] args)
  {
    Console.WriteLine("Enter a string to reverse:");
    string input = Console.ReadLine();
    char[] charArray = input.ToCharArray();
    Array.Reverse(charArray);
    string reversed = new string(charArray);
    Console.WriteLine($"Reversed string: {reversed}");
  }
}