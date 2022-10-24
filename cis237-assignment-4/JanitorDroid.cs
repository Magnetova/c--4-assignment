using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    class JanitorDroid : UtilityDroid
    {
        // Some protected variables that can be accessed in derived classes
        protected bool hasBroom;
        protected bool hasVacuum;

        // Constuctor that takes lots of parameters to create the droid. The base constructor is used to do some of the work
        public JanitorDroid(string Material, string Color,
            bool HasToolbox, bool HasComputerConnection, bool HasScanner, bool HasBroom, bool HasVacuum) :
            base(Material, Color, HasToolbox, HasComputerConnection, HasScanner)
        {
            // Set the Droid Cost
            MODEL_COST = 160.00m;
            // Assign the values that the base constructor is not taking care of.
            this.hasBroom = HasBroom;
            this.hasVacuum = HasVacuum;
        }

        // Override the CalculateCostOfOptions method.
        // Use the base class implementation of the method, and tack on the cost of the new options
        protected override decimal CalculateCostOfOptions()
        {
            decimal optionsCost = 0;

            optionsCost += base.CalculateCostOfOptions();

            if (hasBroom)
            {
                optionsCost += COST_PER_OPTION;
            }

            if (hasVacuum)
            {
                optionsCost += COST_PER_OPTION;
            }

            return optionsCost;
        }

        protected override string GetModelName()
        {
            return "Janitor";
        }

        // Overridden ToString that uses the base ToString method, and appends the missing information.
        public override string ToString()
        {
            return
                base.ToString() +
                "Has Broom: " + this.hasBroom + Environment.NewLine +
                "Has Vacuum: " + this.hasVacuum + Environment.NewLine;
        }
    }
}
