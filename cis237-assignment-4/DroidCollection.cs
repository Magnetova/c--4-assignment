// Cayden Greer
// CIS 237 - Fall 2022
// 11-04-2022


using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    class DroidCollection : IDroidCollection
    {
        // Private variable to hold the collection of droids
        private IDroid[] droidCollection;
        // Private variable to hold the length of the Collection
        private int lengthOfCollection;


        // Constructor that takes in the size of the collection.
        // It sets the size of the internal array that will be used.
        // It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            // Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];


            // Hard coded droids that are entered into the array for testing purposes
            droidCollection[0] = new UtilityDroid("Carbonite", "Red", true, false, false);
            droidCollection[1] = new ProtocolDroid("Vanadium", "White", 24);
            droidCollection[2] = new ProtocolDroid("Quadranium", "Red", 5);
            droidCollection[3] = new JanitorDroid("Vanadium", "Blue", true, false, false, true, true);
            droidCollection[4] = new UtilityDroid("Quadranium", "White", true, false, false);
            droidCollection[5] = new AstromechDroid("Carbonite", "Green", true, false, false, true, 10);
            droidCollection[6] = new JanitorDroid("Carbonite", "Red", true, false, false, true, false);
            droidCollection[7] = new AstromechDroid("Tears_Of_A_Jedi", "Green", true, false, false, false, 15);
            // calculate length of non null values within the droid array
            lengthOfCollection = GetLength();
        }

        // Gets the length of non null values of the array
        private int GetLength()
        {
            int i = 0;
            while (droidCollection[i] != null)
            {
                i++;
            }

            return i;
            
        }


        // The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Color, int NumberOfLanguages)
        {
            // If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                // Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                // of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Color, NumberOfLanguages);
                // Increase the length of the collection
                lengthOfCollection++;
                // return that it was successful
                return true;
            }
            // Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        // The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        // The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The last method that must be implemented due to implementing the interface.
        // This method iterates through the list of droids and creates a printable string that could
        // be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            // Declare the return string
            string returnString = "";

            // For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                // If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    // Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    // the program will automatically know which version of CalculateTotalCost it needs to call based
                    // on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    // Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            // return the completed string
            return returnString;
        }
        
        // Sorts the droids in order of droid type (astomech, janitor, utility, protocol)
        // It does this by creating an instance of a stack for each droid type by comparing IDroid to a specific droid type
        // and then pushes the droid onto its respective stack.
        // Once all droids have been entered into a stack/there are no more droids left in the array, the foreach loop
        // pops each stack individually until the stack is empty and then moves onto the next stack.
        // After every pop, the returned top value from the stack is enqueued into the generic queue that holds any Droid type.
        // The entire queue is then dequeued until it is empty, inserting each returned value from the queue back into the IDroid array.
        // The droids are now sorted by droid type.
        public void ModifiedBucketSort()
        {
            int i = 0;
            GenericStack<AstromechDroid> astromechStack = new GenericStack<AstromechDroid>();
            GenericStack<JanitorDroid> janitorStack = new GenericStack<JanitorDroid>();
            GenericStack<UtilityDroid> utilityStack = new GenericStack<UtilityDroid>();
            GenericStack<ProtocolDroid> protocolStack = new GenericStack<ProtocolDroid>();

            GenericQueue<Droid> droidQueue = new GenericQueue<Droid>();

            foreach (IDroid droid in droidCollection)
            {
                if (droid is AstromechDroid)
                {
                    AstromechDroid myDroid = (AstromechDroid)droid;

                    astromechStack.Push(myDroid);
                }

                if (droid is JanitorDroid)
                {
                    JanitorDroid myDroid = (JanitorDroid)droid;

                    janitorStack.Push(myDroid);
                }

                if (droid is UtilityDroid && droid is not AstromechDroid && droid is not JanitorDroid)
                {
                    UtilityDroid myDroid = (UtilityDroid)droid;

                    utilityStack.Push(myDroid);
                }

                if (droid is ProtocolDroid)
                {
                    ProtocolDroid myDroid = (ProtocolDroid)droid;

                    protocolStack.Push(myDroid);
                }
            }



            do
            {
                droidQueue.Enqueue(astromechStack.Pop());
            }
            while (astromechStack.IsEmpty == false);

            do
            {
                droidQueue.Enqueue(janitorStack.Pop());
            }
            while (janitorStack.IsEmpty == false);

            do
            {
                droidQueue.Enqueue(utilityStack.Pop());
            }
            while (utilityStack.IsEmpty == false);

            do
            {
                droidQueue.Enqueue(protocolStack.Pop());
            }
            while (protocolStack.IsEmpty == false);



            foreach (IDroid droid in droidCollection)
            {
                while (droidQueue.IsEmpty == false)
                {
                    droidCollection[i] = droidQueue.Dequeue();
                    i++;
                }
            }
        }


        // The method calculates the total cost of every droid in the array so that the total cost values can be
        // stored without having to print the list first.
        // The method resizes the current Droid array to contain no null values.
        // The resized array is then passed into the MergeSort class and sorted within the class.
        // After the sort has completed, it returns the size of the array back to 100 so that additional droids may
        // be added if need be.
        public void MergeDroids()
        {

            MergeSort mergeDroids = new MergeSort();
            foreach(IDroid droid in droidCollection)
            {
                if(droid != null)
                {
                    droid.CalculateTotalCost();
                }
            }

            Array.Resize<IDroid>(ref droidCollection, lengthOfCollection);
            MergeSort.sort(droidCollection);
            Array.Resize<IDroid>(ref droidCollection, 100);
        }

    }
}
