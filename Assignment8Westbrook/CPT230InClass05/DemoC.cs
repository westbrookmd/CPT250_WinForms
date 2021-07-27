using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT230InClass05
{
    class DemoC : DemoB
    {
        private bool b;

        public DemoC() : base()
        {
            this.b = true;
    }
        public override string Display()
        {
            return base.Display() + " " + this.b.ToString();
        }
    }

}
