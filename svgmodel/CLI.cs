using System;
using System.IO;

namespace svgmodel
{
    public class CLI
    {

        public Canvas canvas { get; private set; }

        public CLI(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void Run()
        {
            bool quit = false; while (!quit)
            {
                Println("--[ Main Menu ]--");
                Println("A | Add shape");
                Println("U | Update shape");
                Println("R | Remove shape");
                Println("N | New Canvas");
                Println("S | Save");
                Println("P | Save default shapes");
                Println("Q | Save & Exit");
                Print(": ");
                string cmd = ReadString().ToUpper();
                switch (cmd)
                {
                    case "A":
                        AddShapeCLI();
                        break;
                    case "U":
                        UpdateShapeCLI();
                        break;
                    case "R":
                        RemoveShapeCLI();
                        break;
                    case "N":
                        CanvasResetCLI();
                        break;
                    case "S":
                        Save();
                        break;
                    case "P":
                        ProduceDefaultShapes();
                        break;
                    case "Q":
                        quit = true;
                        break;
                    default:
                        Println("Commands [ A, U, R, N, S, P, Q ]");
                        Println("");
                        break;
                }
            }
        }

        public void Save()
        {
            File.WriteAllLines("canvas.svg", canvas.GetFileContent().ToArray());
            Println("File Saved");
            Println("");
        }

        private void CanvasResetCLI()
        {
            Print("\nCanvas Width: ");
            int width = ReadInt();
            Print("\nCanvas Width: ");
            int height = ReadInt();
            canvas = new(width, height);
            Println("");
        }

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
                    shape.SetProps();
                    shape.SetStyle();
                    canvas.shapes.Add(shape);
                    Println("Shape Added");
                    done = true;
                }
            }
            Println("");
        }

        private void UpdateShapeCLI()
        {
            Println("Enter # of the shape you want to update");
            int i = 0; foreach (BasicShape s in canvas.shapes)
            {
                Print("# [" + (i+1)+ "] "); Println("| " + s.ToString());
                Println("");
                i++;
            }
            Print(": "); ;
            int n = ReadInt();
            if (n <= canvas.shapes.Count)
            {
                BasicShape shape = canvas.shapes[n-1];
                shape.SetProps();
                shape.SetStyle();
                canvas.shapes[n - 1] = shape;
                Println("Shape Updated");
            }
            else
            {
                Println("Invalid shape selected");
            }
            Println("");
        }

        private void RemoveShapeCLI()
        {
            Println("Enter # of the shape you want to remove");
            int i = 0; foreach (BasicShape s in canvas.shapes)
            {
                Print("# [" + i + "] "); Println("| " + s.ToString());
                Println("");
                i++;
            }
            Print(": "); ;
            int n = ReadInt();
            if (n < canvas.shapes.Count)
            {
                canvas.shapes.RemoveAt(n);
                Println("Shape removed");
            }
            else
            {
                Println("Invalid shape selected");
            }
            Println("");
        }


        private void ProduceDefaultShapes()
        {
            BasicShape circle = new Circle(25,100,100);
            circle.SetStyle(0, "", "red", "8", "gray");
            BasicShape ellipse = new Ellipse(300, 100, 100, 70);
            ellipse.SetStyle(0, "", "orange", "16", "yellow");
            BasicShape rect = new Rectangle(200, 200, 40, 200);
            rect.SetStyle(5, "", "purple", "4", "none");
            BasicShape square = new Rectangle(100,150,150,150);
            square.SetStyle(2, "", "", "4", "cyan");
            BasicShape line = new Line(0,0, 500, 500);
            line.SetStyle(6, "", "blue", "10", "none");
            BasicShape polyline = new PolyLine("400,200 300,10 230,100, 40,20 50,400 300,400 400,400");
            polyline.SetStyle(4, "", "green", "4", "none");
            BasicShape polygon = new Polygon("300,200, 0,100 350,300, 400,20");
            polygon.SetStyle(1, "", "orange", "4", "brown");

            canvas.shapes.Clear();
            canvas.shapes.Add(circle);
            canvas.shapes.Add(ellipse);
            canvas.shapes.Add(rect);
            canvas.shapes.Add(square);
            canvas.shapes.Add(line);
            canvas.shapes.Add(polyline);
            canvas.shapes.Add(polygon);

            Save();
        }

        private string ReadString()
        {
            return Console.ReadLine();
        }

        private int ReadInt()
        {
            return int.Parse(Console.ReadLine());
        }

        private void Print(string s)
        {
            Console.Write(s);
        }

        private void Println(string s)
        {
            Console.WriteLine(s);
        }

    }
}
