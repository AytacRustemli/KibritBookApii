﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int UserId { get; set; }
        public string? UserEmail { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
    }
}
