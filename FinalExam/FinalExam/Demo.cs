using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam
{
    public class Demo
    {
        /* 1. Add the following to the class
         * Empty Constructor that sets the data to your choice
         * A Constructor that takes data to fill all fields
         * A Public field called Stuff that can hold words
         * A Public Property called SomeProperty that can hold numbers
         * A method called Print that returns a string containing
         * Stuff and SomeProperty
         * 20pts
         */
        public Demo()
        {
            string type = "demo";
            int amount = 100;
            this.Stuff = "Yep";
            this.SomeProperty = 400;

        }
        public Demo(string t, int a)
        {
            string type = t;
            int amount = a;

        }
        public string Stuff;
        public int SomeProperty { get; set; }

        public virtual string Print()
        {
            return Stuff + SomeProperty;
        }
    }
}
