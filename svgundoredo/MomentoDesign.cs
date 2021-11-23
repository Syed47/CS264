using System;
using System.Collections.Generic;

/*
A generic implementation of Momento pattern that encapsulates the three
classes that are usually seen in Momento Design pattern.

I'm using this abstract class for updating and undo-redo action on action,
but it can also be used for other object since it's generic.
*/

namespace svgundoredo
{
    public abstract class MomentoDesign<T> : List<T>
    {
        private int StateIndex;
        private CareTaker<T> caretaker;
        private Originator<T> originator;
        private List<T> states;

        public MomentoDesign()
        {
            caretaker = new CareTaker<T>();
            originator = new Originator<T>();
            states = new List<T>();
            originator.Set(states); // setting the new states
            caretaker.AddMomento(originator.SaveToMomento()); // storing to momento
            StateIndex = 0;
        }

        public string AddState(T state)
        {
            states.Add(state); // adding new state to the next states
            originator.Set(states); // setting the next state to be to be current
            caretaker.AddMomento(originator.SaveToMomento()); // saving to momento
            StateIndex++;
            return state.ToString();
        }

        public bool Undo()
        {
            if ((StateIndex - 1) >= 0) // if not already at the intial state
            {
                StateIndex--; // go to previous state index
                Reset();
                // restoreing from the previous state (Momento)
                AddRange(originator.RestoreFromMomento(caretaker.GetMomento(StateIndex)));
                return true;
            }
            return false;
        }

        public bool Redo()
        {
            if ((StateIndex + 1) < caretaker.TotalStates()) // if not already at lastest state
            {
                StateIndex++; // go to the next available momento
                Reset();
                // restoring from the next state
                AddRange(originator.RestoreFromMomento(caretaker.GetMomento(StateIndex)));
                return true;
            }
            return false;
        }

        public int GetAvailableRedo()
        {
            return caretaker.TotalStates() - (StateIndex + 1);
        }

        public int GetAvailableUndo()
        {
            return StateIndex;
        }

        public List<T> GetStates()
        {
            return states;
        }

        public void Reset()
        {
            Clear();
        }
    }

    public class CareTaker<T>
    {
        // all the states are stored in this list
        private List<Momento<T>> savedStates;

        public CareTaker()
        {
            savedStates = new List<Momento<T>>();
        }

        public void AddMomento(Momento<T> momento)
        {
            savedStates.Add(momento);
        }

        public Momento<T> GetMomento(int index)
        {
            return savedStates[index];
        }

        public int TotalStates()
        {
            return savedStates.Count;
        }

    }

    public class Originator<T>
    {
        private List<T> state;

        public void Set(List<T> newState)
        {
            state = newState;
        }

        public Momento<T> SaveToMomento()
        {
            return new Momento<T>(state);
        }
        // returns a copy of the provided momento
        public List<T> RestoreFromMomento(Momento<T> momento)
        {
            //state = momento.GetSavedState();
            state.Clear();
            foreach (T shape in momento.GetSavedState())
            {
                state.Add(shape);
            }

            return state;
        }
    }


    public class Momento<T>
    {
        private readonly List<T> state;

        public Momento(List<T> state)
        { // storing a copy of the provided state argument
            this.state = new List<T>();
            foreach (T shape in state)
            {
                this.state.Add(shape);
            }
        }

        public List<T> GetSavedState()
        {
            return state;
        }
    }

}
