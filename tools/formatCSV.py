import os
import sys

def formatCSV(filename):
    temp_filename = filename
    # If there's a prefaced folder, strip it
    if '/' in filename:
        temp_filename = filename.split('/')[-1]
    # If there's a prefaced folder, strip it
    if '\\' in filename:
        temp_filename = filename.split('\\')[-1]
    

    # The numbers might be BIIGGGG, so we're gonna load it one at a time ...
    with open(filename, "r") as f:
        # Create a new file to save the formatted data
        with open("formatted_" + temp_filename, "w") as f2:
            # Loop through each line in the file
            for line in f:
                # Remove the quotes from the line
                line = line.replace('\'', '')
                # Copy the line to the new file
                f2.write(line)
    print("Formatted file saved as formatted_" + filename)


def main():
    # get the filename from the command line
    if len(sys.argv) != 2:
        print("Usage: python formatCSV.py <filename>")
        sys.exit(1)
    filename = sys.argv[1]
    # check if the file exists
    if not os.path.isfile(filename):
        print("File does not exist")
        sys.exit(1)

    # format the file
    formatCSV(filename)


if __name__ == "__main__":
    main()