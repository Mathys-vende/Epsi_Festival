using System;
using System.Collections.Generic;

namespace Epsi_Festival.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
    }
}
