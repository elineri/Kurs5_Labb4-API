using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4_Models
{
    public class PersonInterestLink
    {
        [Key]
        public int Id { get; set; }
        public int? PersonId { get; set; }
        public Person Person { get; set; }
        public int? InterestId { get; set; }
        public Interest Interest { get; set; }
        public int? WebsiteId { get; set; }
        public Website Website { get; set; }
    }
}
