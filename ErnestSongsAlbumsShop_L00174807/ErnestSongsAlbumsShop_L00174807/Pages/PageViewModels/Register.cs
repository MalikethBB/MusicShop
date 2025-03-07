﻿using System.ComponentModel.DataAnnotations;

namespace ErnestSongsAlbumsShop_L00174807.Pages.PageViewModels
{
    public class Register
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]

        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)] public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
