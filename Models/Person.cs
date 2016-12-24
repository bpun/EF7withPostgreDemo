using System;
using System.ComponentModel.DataAnnotations;

namespace EF7withPostgreDemo.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public String Name { get; set; }

        public String Address { get; set; }

        [Phone]
        public String Phone { get; set; }
    }
}
