﻿using System;
using System.Security.Principal;

namespace NodebookApp.SharedVM
{
    // Kullanıcı yönetim modeli
    public class UserManager
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
