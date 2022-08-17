using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnEFCodeFirst.Entities;
namespace HandsOnEFCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student()
            {
                StudentId = "S0001",
                StudentName = "Kavaya",
                Age = 10
            };
            using(StudentDBContext db=new StudentDBContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
    }
}
