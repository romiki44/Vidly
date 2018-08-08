﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Driving Licence")]
        public string DrivingLicense { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
    }
}