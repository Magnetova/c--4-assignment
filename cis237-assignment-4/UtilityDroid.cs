using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    class UtilityDroid : Droid
    {
        // A constant that can be used in this class or any child classes
        protected const decimal COST_PER_OPTION = 35.00m;

        // Class level variables that can be used in this class, or any children of this class
        protected bool hasToolbox;
        protected bool hasComputerConnection;
        protected bool hasScanner;

        // Constructor that takes the standard parameters, and ones specific to this droid.
        // Calls the base constructor to do some of the work already written in the droid class.
        public UtilityDroid(string Material, string Color, bool HasToolbox, bool HasComputerConnection, bool HasScanner) :
            base(Material, Color)
        {
            // Set the Droid Cost
            MODEL_COST = 130.00m;
            // Assign the values that the base constructor is not taking care of.
            this.hasToolbox = HasToolbox;
            this.hasComputerConnection = HasComputerConnection;
            this.hasScanner = HasScanner;
        }

        // Virtual method to calculate the cost of the options. This method can be overridden in child classes
        // to calculate the cost of options
        protected virtual decimal CalculateCostOfOptions()
        {
            decimal optionsCost = 0;

            if (hasToolbox)
            {
                optionsCost += COST_PER_OPTION;
            }

            if (hasComputerConnection)
            {
                optionsCost += COST_PER_OPTION;
            }

            if (hasScanner)
            {
                optionsCost += COST_PER_OPTION;
            }

            return optionsCost;
        }

        // Overridden method to calculate the total cost. This method uses the base cost from the parent droid class,
        // and the cost of the options of this class to create the total cost.
        public override void CalculateTotalCost()
        {
            this.CalculateBaseCost();

            this.totalCost = this.baseCost + MODEL_COST + this.CalculateCostOfOptions();
        }

        protected virtual string GetModelName()
        {
            return "Utility";
        }

        // Overridden ToString method to output the information for this droid.
        // uses the base ToString method and appends more information to it.
        public override string ToString()
        {
            return
                "Model: " + GetModelName() + Environment.NewLine +
                base.ToString() +
                "Has Tool Box: " + this.hasToolbox + Environment.NewLine +
                "Has Computer Connection: " + this.hasComputerConnection + Environment.NewLine +
                "Has Scanner: " + this.hasScanner + Environment.NewLine;
        }
    }
}
