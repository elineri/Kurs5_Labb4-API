using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4_Models
{
    public class Website
    {
        [Key]
        public int WebsiteId { get; set; }
        [Required]
        public string LinkDescription { get; set; }
        [Required]
        public string Link { get; set; }
        //public ICollection<PersonInterestLink> PersonInterestLinks { get; set; }
    }
}
