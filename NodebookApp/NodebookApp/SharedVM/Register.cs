﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NodebookApp.SharedVM
{
    // Yeni kullanıcı kaydı modeli
    public class Register
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
    }
}
