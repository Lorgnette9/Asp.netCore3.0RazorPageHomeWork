using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Taste.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }

        public int Id { get; set; }

        public int MenuItemId { get; set; }
        
        [NotMapped]
        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItemm { get; set; }


        public string  ApplicationUserId { get; set; }
        
        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUserr { get; set; }


        [Range(1,100,ErrorMessage="1-100 arası seçim yapınız")]
        public int Count { get; set; }
    }
}
