﻿using Microsoft.EntityFrameworkCore;

namespace EF_Day_4.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        public DateTime ManufactureDate { get; set; }
    }
}