﻿using System.ComponentModel.DataAnnotations;

namespace ErnestSongsAlbumsShop_L00174807.Pages.PageViewModels
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)] public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
