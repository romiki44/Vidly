using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Meno je povinné")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscriberToNewsletter { get; set; }

        //[Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}