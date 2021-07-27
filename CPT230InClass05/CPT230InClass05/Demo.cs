using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT230InClass05
{
    class Demo
    {
        //public and private
        //Class Variables
        private int prInt;
        public bool puBool;

        //Properties
        public string PuString
        {
            set;
            get;
        }

        //Constructors
        public Demo()
        {
            this.prInt = 5;
            this.puBool = true;
            this.PuString = "Some String";
        }
        public Demo(int prInt, bool puBool, string PuString)
        {
            this.prInt = prInt;
            this.puBool = puBool;
            this.PuString = PuString;
        }

        //Class Methods
        public void SomeMethod()
        {
            //do stuff here
            prInt += prInt;
        }

    }
}
