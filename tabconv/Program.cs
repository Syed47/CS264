
// Name: Syed Baryalay
// Student No: 19719431

// Developed on MacOS X
// C# version 5.0.401
// Visual Studio for Mac version 8.10

// all the code is my own
// help only taken from official C# documentation
// https://docs.microsoft.com/en-us/dotnet/csharp/


// run the program with "dotnet run"
// enter the command (e.g "tabconv -v -i -h data.csv -o copy.csv")
// program created with visual studio for macos (not vs code)
// program has been tested with data files packed in the zip file
// converts between four formats
// if calling default constructors, appropriate Setters need to be called too
// most of the code is self explanatory but commented where needed


using System;

namespace tabconv
{
    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();
            //Helper helper = new(command);
            //Converter converter = new();
            //converter.SetHelper(helper);
            // OR
            Converter converter = new(new Helper(command));
            // enable the flags to work if passed to the program
            converter.GetHelper().EnableHelp();
            converter.GetHelper().EnableInfo();
            converter.GetHelper().EnableListFormats();
            converter.GetHelper().EnableOutputFile();
            // data conversion
            converter.Convert();
        }
    }
}
