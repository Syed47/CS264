using System.Collections.Generic;

namespace svgundoredo
{
    // must be implemented by each command
    public interface ICommand
    {
        void Execute();
        void Undo();
        void Redo();
    }

    public class CommandDesign
    {
        public readonly Stack<ICommand> UndoStack;
        public readonly Stack<ICommand> RedoStack;

        public CommandDesign()
        {
            UndoStack = new Stack<ICommand>(); // for storing undos
            RedoStack = new Stack<ICommand>(); // for storing redos
        }

        public void Execute(ICommand command)
        {
            command.Execute(); // executing the command
            UndoStack.Push(command); // storing in undo so it can be undone
        }

        public bool Undo()
        {
            if (GetAvailableUndo() <= 0) return false;
            UndoStack.Peek().Undo(); // undo the last command
            RedoStack.Push(UndoStack.Peek()); // add to redo stack
            UndoStack.Pop(); // remove from undo stack
            return true;
        }

        public bool Redo()
        {
            if (GetAvailableRedo() <= 0) return false;
            RedoStack.Peek().Redo(); // redo the last command
            UndoStack.Push(RedoStack.Peek()); // add to undo stack
            RedoStack.Pop(); // remove from redo stack
            return true;
        }

        public int GetAvailableUndo()
        {
            return UndoStack.Count; // number of undos that can be performed
        }

        public int GetAvailableRedo()
        {
            return RedoStack.Count; // number of redos that can be performed
        }
    }

    // can be used to undo redo shape on the canvas
    public class AddShapeCommand : ICommand
    {
        private readonly Canvas canvas;
        private readonly BasicShape shape; // for local copy of the shape

        public AddShapeCommand(Canvas canvas, BasicShape shape)
        {
            this.canvas = canvas;
            this.shape = shape;
        }

        public void Execute()
        {
            // shape is added to the canvas
            canvas.shapes.Add(shape);
        }

        public void Redo()
        {
            Execute(); // for re-adding the shape after undo
        }

        public void Undo()
        {
            // shape is removed from the canvas
            canvas.shapes.Remove(shape);
        }
    }
}
