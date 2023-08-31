﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Plese fill the category area")]
        public string CategoryName { get; set; }
    }
}
