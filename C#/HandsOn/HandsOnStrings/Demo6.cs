using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnStrings
{
    class Demo6
    {
        static void Main()
        {
            //Join
            string[] str = { "I", "Love", "My", "Country" };
            string s = String.Join("_", str);
            string s1 = String.Join(" ", "Good Morning", "Students");
            Console.WriteLine(s1);

            //ToCharArray();
            string s2 = "Sachin Tendulkar";
            char[] ch = s2.ToCharArray(); //convets string into char array.

            //Replace()
            string s3 = "Rahul Dravid";
            s3 = s3.Replace('a', 'A');
            Console.WriteLine(s3);
            string s4 = "Good Morning";
            s4=s4.Replace("Morning", "Evening");

            //Remove()
            string s5 = "Good Morning";
           string s55 = s5.Remove(4);
            Console.WriteLine(s55);
            s5 = s5.Remove(4, 2); //remove onlys 2 chars from index 4
            Console.WriteLine(s5);

            //Substring()
            string s6 = "Good Evening";
          // s6 = s6.Substring(5); //Evening
           // Console.WriteLine(s6);
             s6=s6.Substring(5, 4); //Good
            Console.WriteLine(s6);
            Console.WriteLine(s6);
        }
    }
}
