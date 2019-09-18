namespace MYWEBMVC_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductPicture")]
    public partial class ProductPicture
    {
        public int Id { get; set; }

        public int ProductID { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Picture { get; set; }

        public bool IS_ACTIVE { get; set; }

        public virtual Product Product { get; set; }
    }
}
