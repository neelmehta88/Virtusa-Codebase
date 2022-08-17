using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace HandsOnEFCodeFirst.Entities
{
    internal class StudentDBContext:DbContext
    {
        public StudentDBContext():base("name=StudentDBConnection")
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
