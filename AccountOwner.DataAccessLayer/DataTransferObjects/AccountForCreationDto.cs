using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountOwner.DataAccessLayer.DataTransferObjects
{
    public class AccountForCreationDto
    {
        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        [StringLength(50, ErrorMessage = "Account type cannot be loner then 50 characters")]
        public string AccountType { get; set; }
    }
}
