﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Muffins.Models
{
    public class MuffinItems
    {
        [Key]
        public int ItemNo { get; set; }
        public string Muffinname { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DscRate { get; set; }
        public double VatRate { get; set; }
    }
}