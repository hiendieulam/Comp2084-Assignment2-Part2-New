namespace Book_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int id { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }
        
        public int category_id { get; set; }
        
        public int publisher_id { get; set; }

        [Display(Name = "Publish Date")]
        public DateTime publish_date { get; set; }
        
        public int author_id { get; set; }

        [Display(Name = "Price")]
        [Column(TypeName = "money")]
        public decimal prise { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "URL")]
        public string url { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}
