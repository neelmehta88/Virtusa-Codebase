
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnArray
{
    class Demo4
    {
        static void Main()
        {
            //2-dimensional array
            int[,] n = new int[3, 2]; //here 3 is the rowsize and 2 is columnsize
            //assign values
            n[0, 0] = 99;
            n[0, 1] = 45;
            n[1, 0] = 66;
            n[1, 1] = 33;
            n[2, 0] = 77;
            n[2, 1] = 32;
            int row = n.GetUpperBound(0) - n.GetLowerBound(1) + 1;
            int col = n.GetUpperBound(1) - n.GetLowerBound(0) + 1;
            Console.WriteLine("Row Size:" + row);
            Console.WriteLine("Col Size:" + col);
            //access value
            Console.WriteLine("value at 1st row and 2nd column:{0}", n[0, 1]); //45
            foreach (int k in n)
                Console.WriteLine(k);
            //print values in matrix format
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<2;j++)
                {
                    Console.Write(n[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
