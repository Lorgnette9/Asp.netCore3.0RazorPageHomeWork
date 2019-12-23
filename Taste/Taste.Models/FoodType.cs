using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Taste.Models
{
    public class FoodType
    {
        [Key]
        public int Id  { get; set; }
        public string  Name  { get; set; }  

    }
}
