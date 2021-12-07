using System;
using System.IO;

/*
this class is responsible for handling user input and output.
It provides are menu that the user can use to add shapes, undo, redo print and save.
 */

namespace svgundoredo
{
    public class CLI : BasicIO
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
                Println("--[ Main Menu ]--");
                Println("A | Add shape");
                Println("U | Undo (" + canvas.GetAvailableUndo() + ") available");
                Println("R | Redo (" + canvas.GetAvailableRedo() + ") available");
                Println("P | Print Canvas to Console");
                Println("S | Save to File (canvas.svg)");
                Println("Q | Save & Exit (canvas.svg)");
                Print(": ");
                string cmd = ReadString().ToUpper();
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
                        SaveToFile(fileName, canvas.GetFileContent().ToArray());
                        break;
                    case "P":
                        Println(canvas.ToString());
                        break;
                    case "Q":
                        quit = true;
                        break;
                    default:
                        Println("");
                        Println("Invalid Command");
                        Println("Available commands [ A, U, R, G, S, P, Q ]");
                        Println("");
                        break;
                }
            }
        }

        // provide CLI for adding a new shape to the canvas
        private void AddShapeCLI()
        {
            BasicShape shape = null;
            bool done = false; while (!done)
            {
                Println("Enter one of the following");
                Println("[ CIRCLE, RECT, ELLIPSE, LINE, POLYLINE, POLYGON, PATH ]");
                Print("Shape: ");
                string type = ReadString().ToUpper();
                switch (type)
                {
                    case "CIRCLE":
                        shape = new Circle();
                        break;
                    case "RECT":
                        shape = new Rectangle();
                        break;
                    case "ELLIPSE":
                        shape = new Ellipse();
                        break;
                    case "LINE":
                        shape = new Line();
                        break;
                    case "POLYLINE":
                        shape = new PolyLine();
                        break;
                    case "POLYGON":
                        shape = new Polygon();
                        break;
                    case "PATH":
                        shape = new Path();
                        break;
                    default:
                        Println("Unsupported Shape.");
                        break;
                }
                if (shape != null)
                {
                    shape.ReadUserDefinedProps();
                    shape.ReadUserDefineStyles();
                    string tag = canvas.AddShape(shape);
                    Println("[Shape Added] "+tag);
                    done = true;
                }
            }
            Println("");
        }

        public void UndoCLI()
        {
            if (!canvas.Undo())
            {
                Println("Cannot UNDO. NO previous state found.");
            }
        }

        public void RedoCLI()
        {
            if (!canvas.Redo())
            {
                Println("Cannot REDO. Latest state already exist.");
            }
        }
    }
}
