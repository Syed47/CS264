using System;
using System.IO;

/*
this class is responsible for handling user input and output.
It provides are menu that the user can use to add shapes, undo, redo print and save.
 */

namespace svgundoredo
{
    public class CLI
    {
        public string fileName;
        public Canvas canvas { get; private set; }
        // default constructor
        public CLI() : this(new Canvas(), "canvas.svg") { }
        // general constructor
        public CLI(Canvas canvas, string fileName)
        {
            this.fileName = fileName;
            this.canvas = canvas;
        }

        // provides the main menu interface to the user.
        public void Run()
        {
            bool quit = false; while (!quit)
            {
                IO.Println("--[ Main Menu ]--");
                IO.Println("A | Add shape");
                IO.Println("U | Undo (" + canvas.GetAvailableUndo() + ") available");
                IO.Println("R | Redo (" + canvas.GetAvailableRedo() + ") available");
                IO.Println("P | Print Canvas to Console");
                IO.Println("S | Save to File (canvas.svg)");
                IO.Println("Q | Save & Exit (canvas.svg)");
                IO.Print(": ");
                string cmd = IO.ReadString().ToUpper();
                switch (cmd)
                {
                    case "A":
                        AddShapeCLI();
                        break;
                    case "U":
                        UndoCLI();
                        break;
                    case "R":
                        RedoCLI();
                        break;
                    case "S":
                        IO.SaveToFile(fileName, canvas.GetFileContent().ToArray());
                        break;
                    case "P":
                        IO.Println(canvas.ToString());
                        break;
                    case "Q":
                        quit = true;
                        break;
                    default:
                        IO.Println("");
                        IO.Println("Invalid Command");
                        IO.Println("Available commands [ A, U, R, G, S, P, Q ]");
                        IO.Println("");
                        break;
                }
            }
        }

        // provides CLI for adding a new shape to the canvas
        private void AddShapeCLI()
        {
            for (bool done = false; !done;)
            {
                IO.Println("Enter one of the following");
                IO.Println("[ CIRCLE, RECT, ELLIPSE, LINE, POLYLINE, POLYGON, PATH ]");
                IO.Print("Shape: ");
                string type = IO.ReadString().ToUpper();
                BasicShape shape = ShapeFactory.GetShape(type);
                if (shape != null)
                {
                    shape.ReadUserDefinedProps();
                    shape.ReadUserDefineStyles();
                    canvas.AddShape(shape);
                    IO.Println("[Shape Added] " + shape.ToString());
                    done = true;
                }
            }
            IO.Println("");
        }

        public void UndoCLI()
        {
            if (canvas.Undo())
            {
                IO.Println("Executing Redo Action.");
                return;
            }
            IO.Println("Cannot UNDO. NO previous state found.");
        }

        public void RedoCLI()
        {
            if (canvas.Redo())
            {
                IO.Println("Executing Redo Action.");
                return;
            }
            IO.Println("Cannot REDO. Latest state already exist.");
        }
    }
}
