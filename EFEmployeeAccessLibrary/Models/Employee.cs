using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEmployeeAccessLibrary.Models
{
    public sealed  class Employee
    {

        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }


        [Required]
        public DateTime DateOfBirth { get; set; }


        [Required]
        [MaxLength(100)]
        public string Position { get; set; }


        [Required]
        public int Salary { get; set; }


        [Required]
        [MaxLength(500)]
        public string Address { get; set; }


        [Required]
        [MaxLength(150)]
        public string Department { get; set; }   
    }
}
