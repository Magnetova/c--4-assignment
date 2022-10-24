using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    class ProtocolDroid : Droid
    {
        // Constant for cost per language
        protected const decimal COST_PER_LANGUAGE = 25.00m;
        // Private variables unique to this class
        protected int numberOfLanguages;

        // Constructor that takes in the standard parameters, and the number of languages it knows.
        // The base constructor is called to do the work of assigning the standard parameters
        public ProtocolDroid(string Material, string Color, int NumberOfLanguages) : base(Material, Color)
        {
            // Set the Droid Cost
            MODEL_COST = 120.00m;
            // Assign the values that the base constructor is not taking care of.
            this.numberOfLanguages = NumberOfLanguages;
        }

        // Overriden abstract method from the droid class.
        // It calculates the total cost using the baseCost method.
        public override void CalculateTotalCost()
        {
            // Calculate the base cost
            this.CalculateBaseCost();
            // Calculate the total cost using the result of the base cost
            this.totalCost = this.baseCost + MODEL_COST + (numberOfLanguages * COST_PER_LANGUAGE);
        }

        // Override the ToString method to use the base ToString, and append new information to it.
        public override string ToString()
        {
            return
                "Model: Protocol" + Environment.NewLine +
                base.ToString() +
                "Number Of Languages: " + this.numberOfLanguages + Environment.NewLine;
        }
    }
}
