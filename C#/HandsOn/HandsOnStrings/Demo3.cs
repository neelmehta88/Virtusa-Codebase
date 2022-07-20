using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnStrings
{
    class Demo3
    {
        static void Main()
        {
         
            string s1 = "rahul";
            string s2 = "Rahul";
            if(s1==s2)
            {
                Console.WriteLine("strings are equql sat 1");
            }
            if(String.Compare(s1,s2)==0)
            {
                Console.WriteLine("strings are equql 2 ");
            }
            if (String.Compare(s1, s2,true) == 0) //ignore case
            {
                Console.WriteLine("strings are equql 3");
            }
            if (s1.Equals(s2))
            {
                Console.WriteLine("strings are equql 4");
            }
            if (s1.Equals(s2,StringComparison.OrdinalIgnoreCase)) //ignore case
            {
                Console.WriteLine("strings are equql 5");
            }
        }
    }
}
