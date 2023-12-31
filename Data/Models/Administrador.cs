﻿using System;
using System.Collections.Generic;

namespace claimbased.Data.Models
{
    public partial class Administrador
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Pwd { get; set; } = null!;
        public string AdminType { get; set; } = null!;
        public DateTime RegDate { get; set; }
    }
}
