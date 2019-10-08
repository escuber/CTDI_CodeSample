namespace CTDI_Food.data.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class catalog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public catalog()
        {
            
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productId { get; set; }

        [StringLength(50)]
        public string productName { get; set; }

        [StringLength(500)]
        public string productDescription { get; set; }

        [Column(TypeName = "money")]
        public decimal productPrice { get; set; }

        [StringLength(20)]
        public string imageName { get; set; }
           
        public decimal discountPercent{get;set ;}

        
        public decimal finalPrice { get; set; }

    }
}
