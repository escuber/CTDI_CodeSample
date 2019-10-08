namespace CTDI_Food.data.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            productDiscount = new HashSet<productDiscount>();
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

      
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productDiscount> productDiscount { get; set; }
    }
}
