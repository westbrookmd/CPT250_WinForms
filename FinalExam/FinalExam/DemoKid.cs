using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FinalExam
{
    /* 4. Make DemoKid inherit from Demo
     * Add another property that can store a decimal place
     * Create a empty constuctor that will populate the data (your choice again)
     * Create a second construcor that will take appropriate data to populate
     * all the fields and properties.  Call the base constuctor here.
     * Override the Print method to return all the data from the 
     * Demo class and the DemoKid class as a string
     * 20pts
     */
    /*
     * 5. Make the DemoKid class impliment the IComparable interface.
     * You choose how to decide how the two class objects compair.
     * 20pts
     */
    public class DemoKid : Demo, IComparable<Demo>
    {
        public decimal MyDecimal { get; set; }
        public DemoKid()
        {
            string type = "Roses";
            int amount = 300;
            this.Stuff = "Blah";
            this.SomeProperty = 32;
            this.MyDecimal = 400.22m;
        }
        public DemoKid( string stuff, int someProperty, decimal myDeci) : base()
        {
            this.Stuff = stuff;
            this.SomeProperty = someProperty;
            this.MyDecimal = myDeci;
        }
        public override string Print()
        {
            return Stuff + SomeProperty + MyDecimal;
        }

        public int CompareTo( Demo other)
        {
            if (this.Stuff == "Roses")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
