using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT230InClass05
{
    class DemoB : Demo
    {
        private float f;

        //constructor
        public DemoB() : base()
        {
            this.f = 3.14f;
        }

        //override a method
        public override string Display()
        {
            return prInt.ToString() + " " + this.f.ToString();
        }

    }
}
