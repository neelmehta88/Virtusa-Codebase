using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnArray
{
    class Demo5
    {
        static void Main()
        { 
            //jagged array
            int[][] jg = new int[3][]; //3 is the no of elements store in the array
            jg[0] = new int[] { 23, 34, 45, 56 };
            jg[1] = new int[] { 45, 56, 67, 75 ,90};
            jg[2] = new int[] { 12, 23, 34 };
            //access values from jagged array
            Console.WriteLine("Size of 1st array: " + jg[0].Length);
            for (int i = 0; i < jg.Length; i++)
            {
                foreach (int k in jg[i])
                {
                    Console.Write(k+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
