using System;

namespace cis237_assignment_4
{
    /// <summary>
    /// You must ensure that your droids are implementing this interface.
    /// You must also make sure that you do NOT change any of the code in this interface.
    /// You must use this interface as-is, which means that your code may need to be written
    /// in a way that you are not expecting.
    /// Note: CalculateTotalCost returns a void, meaning that access to the Total Cost value
    /// must be done by use of the property TotalCost once the CalculateTotalCost method has been called.
    /// </summary>
    interface IDroid : IComparable
    {
        // Method to calculate the total cost of a droid
        void CalculateTotalCost();

        // Property to get the total cost of a droid
        decimal TotalCost { get; set; }
    }
}
