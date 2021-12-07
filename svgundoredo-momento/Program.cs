using System;

/*
Assignment 3

Created with Visual Studio for Mac (not VS Code)
Using Mono C# 4.0 and .NET 5.0

I have implemented everything asked for in the assignment.
Some features from extra credit is also implemented.

All the code is my own but i took some help on Momento Design pattern
from Derek Banas youtube channel. https://www.youtube.com/watch?v=jOnxYT8Iaoo

For the UNDO-REDO part, i have implemented the functionality
using Momento Design Pattern. My implementation provides a linear undo-redo
functionality, means everytime a new shapes is added, the current list of
shapes becomes a new state and is stored.
User can choose to go all the way back to the intial empty canvas with no
shapes by typing U (undo) or R (for redo) to go to the next state
until the last state of the canvas. The main menu will tell you how many
undo and redo you can do at any point in program runtime.

Contents are stored in canvas.svg file.
*/

namespace svgundoredo
{
    class Program
    {
        static void Main(string[] args)
        {
            // running a new CLI instance
            new CLI().Run();
        }
    }
}