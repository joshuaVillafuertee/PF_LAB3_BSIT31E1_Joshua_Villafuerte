﻿using System.ComponentModel.DataAnnotations;

namespace PF_LAB3_BSIT31E1_Joshua_Villafuerte.Models
{
    public class LoginModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
