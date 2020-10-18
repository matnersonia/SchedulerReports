using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    public class Contact
    {
        /*public Contact()
        {
            Name = "unknown contact";
            DeliveryMethod = "email";
            
        }*/

        
        public Contact(string name, string deliveryMethod, string deliveryProgram)
        {
            Name = name;
            DeliveryMethod = deliveryMethod;
            DeliveryProgram = deliveryProgram;
        }

        public Contact(string name, string deliveryMethod, TimeSpan dmin, TimeSpan dmax)
        {
            Name = name;
            DeliveryMethod = deliveryMethod;
            dMin = dmin;
            dMax = dmax;
        }

        public string Name { get; }
        public string DeliveryMethod { get; set; }
        public string DeliveryProgram { get; set; }
        public TimeSpan dMin { get; set; }
        public TimeSpan dMax { get; set; }


        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return Name;
        }
    }
}
