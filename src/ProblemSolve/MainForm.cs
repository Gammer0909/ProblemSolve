using Eto.Forms;
using Eto.Drawing;
using System.Numerics;
using System;
using System.IO;
using System.Text;


namespace ProblemSolve
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			Title = "ProblemSolve";

			// Set window size
			ClientSize = new Size(400, 350);

			// Create a new button
			var button = new Button { Text = "Click Me!" };

			// Create a new label
			var label = new Label { Text = "No File currently selected" };

			// Add a click event to the button
			button.Click += (sender, e) => ButtonClick(sender, e);

			// Add these things to the form
			Content = new StackLayout
			{
				Items = { label, button },
				Orientation = Orientation.Vertical,
				HorizontalContentAlignment = HorizontalAlignment.Center,
				VerticalContentAlignment = VerticalAlignment.Center
			};

		}

		
		private static void ButtonClick(object sender, System.EventArgs e) {
			// Run a select file dialog
			var dialog = new OpenFileDialog();

			// Show the dialog
			var result = dialog.ShowDialog(Application.Instance.MainForm);

			// If the user did not click OK
			if (result != DialogResult.Ok)
				return;

			// Get the file path
			var path = dialog.FileName;

			// Get the string
			var number = GetNumberFromFile(path);

			// Show the number in a label
			
			string labelText = $"The first 10 digits of the sum of the numbers in the file are: {number}";
			
			// Center the label
			var label = new Label { Text = labelText, VerticalAlignment = VerticalAlignment.Center, TextAlignment = TextAlignment.Center};
			Application.Instance.MainForm.Content = label;

		}

		private static string GetNumberFromFile(string path) {

			// Double check that the File is a .csv
			if (Path.GetExtension(path) != ".csv") {
				throw new Exception("File is not a .csv");
			}

			// Because the numbers in the file are very large, we'll use a BigInteger
			BigInteger number = 0;

			// Loop through the file, holding one integer at a time, adding them into `number`
			foreach (var line in File.ReadAllLines(path)) {
				try {
					// Parse the line into a BigInteger
					var bigInt = BigInteger.TryParse(line, out _) ? BigInteger.Parse(line) : BigInteger.Parse(line.Replace("\'", ""));
					// Add the number to the total
					number += bigInt;
				} catch (Exception e) {
					// If there's an error, print the error and continue
					Console.WriteLine("An error occured");
					continue;
				}
			}

			// Get the first 10 digits of the number (ones place to the billions place)
			// Because we read numbers right to left, we have to reverse the string
			var numberString = number.ToString();

			// Reverse the string
			var reversedString = ReverseString(numberString);

			// Get the first 10 digits
			var firstTenDigits = reversedString.Substring(0, 10);

			// Now just return the string!
			return firstTenDigits;

		} 

		private static void Reformat(string path) {

			// The lines could be very long, so we're gonna have to go line by line

			// make a stream reader
			using (var reader = new StreamReader(path)) {
				// make a stream writer
				using (var writer = new StreamWriter("formatted.csv")) {
					// loop through the file
					while (!reader.EndOfStream) {
						// read the line
						var line = reader.ReadLine();
						// remove the quotes
						line = line.Replace("\'", "");
						// write the line
						writer.WriteLine(line);
					}
				}
			}

		}

		private static string ReverseString(string s) {
			var charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

	}
}