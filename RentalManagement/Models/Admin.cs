﻿using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(50, MinimumLength = 8, ErrorMessage = "Username characters must be <br/> more than 8 and maximum of 50 characters.")]
        public string Admin_UserName { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&/,.-])[A-Za-z\d@$!%*?&/,.-]{8,30}$", ErrorMessage = "Password must have: <br/> * 8 minimum char long <br/> * Atleast 1 Uppercase Character <br/> * Atleast 1 Special Character <br/> * Atleast 1 Numerical Character")]
        public string Admin_Password { get; set; }

    }
}
