/*

Assignment 4

For this assignment I decided to use Command design pattern for implementing
Undo-Redo functionalilty. No major changes are added to the existing code,
except the AddShape method is slightly changed in the Canvas class. Instead of
Canvas inheriting the MomentoDesign class, this time the Canvas inherits the
CommandDesign class, which implements the command design pattern. This class has
two Stacks of type ICommand. One stack is used for undos and the other for redos.

Since we only need to Add shapes to the canvas, I have created only one command,
implemented in the AddShapeCommand class. It takes a reference to the Canvas and a
BasicShape that needs to be added. This command can be undo-redo.

The Canvas class extends the CommandDesign class, basically getting access
to all the functionality needed for undo-redo. The AddShape method in the
Canvas class wraps the shape that is passed to it in an AddShapeCommand
constuctor (so that the shape can be added or removed later) and is then
added to the list of all shapes on the canvas.

The total number of Undo-Redo that the user can perform at any point when
the program is running is displayed in the menu.

Output is can be printed or saved to svg file (canvas.svg).

Note: the program won't generate any default shapes, instead the user will
tell it what shapes to produce.
 
*/

namespace svgundoredo
{
    class Program
    {
        static void Main(string[] args)
        {
            CLI program = new(new Canvas(), "canvas.svg");
            program.Run();
        }
    }
}