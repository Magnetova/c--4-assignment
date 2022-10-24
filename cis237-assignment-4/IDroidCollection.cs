using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    interface IDroidCollection
    {
        // Various overloaded Add methods to add a new droid to the collection
        bool Add(string Material, string Color, int NumberOfLanguages);
        bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm);
        bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum);
        bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips);

        // Method to get the data for a droid into a nicely formated string that can be output.
        string GetPrintString();
    }
}
