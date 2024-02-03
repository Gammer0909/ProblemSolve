# ProblemSolve

This repository contains my solution for the problem presented to me by Ameritech Computer Consultants, Inc.

## Problem

This was the problem's full description:

### Statement of Problem
Use Visual Studio 2019 (Community Edition is free!) or newer version to craft a C# Windows Forms App (.NET Framework 4.6.1 or newer version) with a button and a text field.  The button brings up a file selector that allows the user to select a CSV file.  Once the CSV file is selected, the following process is to be performed on it and the results are to be displayed in the text box
Each row in the CSV file represents a different, large number.  Find the final ten digits of the sum of all rows of the CSV file (that is, the ones place, the tens, etc.).  This process should be robust in that it should work with no regard to the size of the numbers (it should work with small numbers as well!)
An example CSV that it should work with: (numbers are delimited by quotes because Excel is stupid)

Besides pure functionality, the following traits should always be kept in mind while writing:
#### Extensibility
a. Could this program later on be written to read from a database instead of a csv file?

i. This should not be made implicitly more complicated by how you design it!
(It is okay not to make it perfectly translatable and to do stuff like box all your functions together, but the steps you take towards the solution should not be taken Away from refactorability – if that makes sense)

b. Does this program allow for many, many large numbers to be processed?
c. Is it easy to use adjust it to (or does it simply work out of the box with) a pure comma separated values file? (aka no single quotes)
#### Readability
a. Comments are not explicitly necessary unless something is confusing or a space between two sections of code takes a significant amount of thought to bridge, but your code should be styled consistently once it becomes concrete
#### Efficiency
a. It is said that “Premature Optimization is the root of all evil” and while there is certainly some truth to it, not being concerned with the efficiency of your program and not building things in such a way as to at least allow space for said efficiency leads to some clunky ass programs that your users end up having to deal with and someone ten years down ∂ßthe line ends up cursing your name (often that person is also you!).

### Thoughts During and Afterwards
1. How could this be made faster?
2. Does it work with negatives? Should it?
3. Is the entire CSV being loaded and thus held immediately into active memory?  How might this cause problems for very large number loads?
4. Does the memory usage of your application grow over time? Could this be prevented?
5. Are we processing unnecessary information?
6. Saving perhaps the most important for last: What kinds of input would destroy your program? Should it not crash? Does it crash gracefully?

## Extra Tools

As the problem states, Excel puts quotations around numbers, even when they should not be stored as strings. To get around this, I supplied a snazzy Python tool to format the files for you.

To use the python tool, simply run the following command in the terminal:

```bash
python formatCSV.py <input_file>
```

The output will be a file called `formatted_<input_file>`.

## Solution

The solution I used was pretty simple. It simply asks for a file (As per the spec), adds all the numbers up, converts the number to a string, reverses it and reads the first 10 characters. This is the final 10 digits of the sum of all the numbers in the file. This then gets displayed to the window.

Note: Due to me using a mac, I was not able to use Windows Forms to make the solution, however I found a workaround using Eto.Forms instead. I hope this is acceptable.

## Installation and Usage

There is a Wpf solution provided, all you have to do is:

```bash
# Pull the repo
git clone https://github.com/Gammer0909/ProblemSolve.git

# Change into the directory
cd ProblemSolve

# Move into `src`
cd src

# Move to the Windows Solution
cd ProblemSolve.Wpf

# Run the solution via `dotnet`
dotnet run
```

Although I suspect this would work the same as the macOS version, errors happen, and I deeply apologize, and you can try contacting me to see if I can fix it, as I am currently not able to test Windows solutions.