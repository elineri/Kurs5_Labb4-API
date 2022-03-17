using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4_Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        [Required]
        public string InterestName { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<PersonInterestLink> PersonInterestLinks { get; set; }
    }
}
