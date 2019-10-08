namespace CTDI_Food.data.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  //  using System.Data.Entity.Spatial;

    [Table("productDiscount")]
    public partial class productDiscount
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
         public int productDiscountId { get; set; }

        //  [Key]
       
        public int productId { get; set; }

        public int discountId { get; set; }

        [Column(TypeName = "date")]
        public DateTime startDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime endDate { get; set; }

   

        public virtual discount discount { get; set; }

        public virtual product product { get; set; }
    }
}
