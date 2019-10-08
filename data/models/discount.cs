namespace CTDI_Food.data.models
//rdr.p
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   // using System.Data.Entity.Spatial;

    public partial class discount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public discount()
        {
            productDiscount = new HashSet<productDiscount>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int discountId { get; set; }

        [Column(TypeName = "date")]
        public DateTime discount_startDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime discount_endDate { get; set; }

        public int discount_percent { get; set; }

    //  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       public virtual ICollection<productDiscount> productDiscount { get; set; }
    }
}
