// filepath: /codespaces-blank/Phase 1/CollectionsPractice.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class CollectionsPractice
{
  static int solveMeFirst(int a, int b)
  {
    return a + b;
  }

  public static void CollectionsPracticeMain(String[] args)
  {
    int val1 = Convert.ToInt32(Console.ReadLine());
    int val2 = Convert.ToInt32(Console.ReadLine());
    int sum = solveMeFirst(val1, val2);
    Console.WriteLine(sum);

    // Step 1: Create a list of student names
    List<string> students = new List<string> { "Alice", "Bob", "Charlie" };

    // Step 2: Create a dictionary for student grades
    Dictionary<string, int> grades = new Dictionary<string, int> {
      { "Alice", 85 },
      { "Bob", 92 },
      { "Charlie", 78 }
    };

    // Step 3: Print all students with grades
    Console.WriteLine("Student Grades:");
    foreach (var student in students)
    {
      if (grades.ContainsKey(student))
      {
        Console.WriteLine($"{student}: {grades[student]}");
      }
      else
      {
        Console.WriteLine($"{student}: No grade found");
      }
    }

    // Step 4: Find the highest grade
    int highest = int.MinValue;
    string topStudent = "";
    foreach (var kvp in grades)
    {
      if (kvp.Value > highest)
      {
        highest = kvp.Value;
        topStudent = kvp.Key;
      }
    }
    Console.WriteLine($"\nHighest grade: {topStudent} ({highest})");

    // Step 5: Ask user for a student's grade
    Console.Write("\nEnter a student's name: ");
    string name = Console.ReadLine();
    if (grades.ContainsKey(name))
    {
      Console.WriteLine($"{name}'s grade: {grades[name]}");
    }
    else
    {
      Console.WriteLine("Student not found.");
    }
  }


  public static int CountDig(int n, int d)
  {
    // your code
    List<char> nsquareNums = new List<char>();
    for (int i = 0; i <= n; i++)
    {
      string res = Convert.ToString(i * i);
      Console.WriteLine(res);
      foreach (char digit in res.ToCharArray())
      {
        nsquareNums.Add(digit);
      }
    }
    int digitCount = nsquareNums.Where(x => Char.GetNumericValue(x) == d).Count();
    Console.WriteLine($"digit Count: {digitCount}");
    return digitCount;

    //Best:
    // public static int NbDig(int n, int d) =>
    // Enumerable.Range(0, n + 1)
    //           .Select(i => (i * i).ToString())
    //           .Sum(sq => sq.Count(c => c == (char)(d + '0')));
  }

  //Given a non-empty array of integers, return the result of multiplying the values together in order. 
  public static int Grow(int[] x)
  {
    int res = 1;
    foreach (int num in x)
    {
      res = res * num;
    }
    Console.WriteLine($"The result is : {res}");
    return res;
    //Best: 
    // return x.Aggregate((p, next) => p * next);
  }
}