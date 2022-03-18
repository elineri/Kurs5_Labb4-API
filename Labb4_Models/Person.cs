using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4_Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        //public ICollection<PersonInterestLink> PersonInterestLinks { get; set; }
    }
}
