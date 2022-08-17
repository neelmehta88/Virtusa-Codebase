using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace HandsOnEFCodeFirst.Entities
{
    [Table("Students")]
    internal class Student
    {
        [Key]
        [StringLength(10)]
        public string StudentId { get; set; }
        [StringLength(50)]
        [Required]
        public string StudentName { get; set; }
        public int? Age { get; set; }
    }
}
