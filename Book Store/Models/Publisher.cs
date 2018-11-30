namespace Book_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Publisher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Publisher")]
        public string publish_name { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Company")]
        public string company_name { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Postal Code")]
        public string postal_code { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Country")]
        public string country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
