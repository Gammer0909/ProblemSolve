using System;

namespace Gammer0909.ProblemSolution;

/// <summary>
/// Represents the entry point of the program.
/// </summary>
public class Driver {

    public static void Usage() {
        Console.WriteLine("Usage: dotnet run <filename>");
    }

    /// <summary>
    /// The main method of the program.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args) {

        if (args.Length == 0) {
            Driver.Usage();
            return;
        }

        string filename = args[0];

        // Make sure the file is a CSV and that it exists
        if (!filename.EndsWith(".csv") || !System.IO.File.Exists(filename)) {
            Console.WriteLine("The file must be a CSV file and it must exist.");
            return;
        }

    }

}