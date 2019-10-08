
using CTDI_Food.data.contexts;


namespace CTDI_Food.data.bo
{
    using System;
    using System.Collections.Generic;    
    using CTDI_Food.data.models;

    using System.Linq;
    
    //
    // this is the business object for the CTDI catalog its main purpose
    // is to return the products from the database with the discount amount
    // if there is one.  It also calculates the discounted price.
    // it returns these as a queryable list of catalog entities.
    //
    //
    public partial class catalogbo
    {
        private readonly productsContext _db;

       // public catalogbo()
       // {
       // }

        public catalogbo(productsContext context)
        {
            _db = context;
        }

        public IEnumerable<catalog> get_productsWithDiscountsFilteredByDate()
        {
            if (!_db.product.Any())
            {

                _db.product.AddRange(ProductDataGenerator.generateProductsDataList());
                _db.SaveChanges();
            }
            // here we are going to generate the output query twice because it gets 
            // really ugly and hard to read otherwise
            // the first time we are setting the discountpercent and the second time we 
            // we are using the value to set the price.

            //  the good thing is that is only happens once because of the query it is writting

            var return_products = _db.product.Select(p => new catalog
            {
                productName = p.productName,
                productDescription = p.productDescription,
                productId = p.productId,
                productPrice = p.productPrice,
                imageName = p.imageName,
                discountPercent =
                 p.productDiscount.Any(pd => pd.startDate <= DateTime.Now && pd.endDate > DateTime.Now)
                 ?
               Convert.ToDecimal(
                   p.productDiscount.Where(pd => pd.startDate <= DateTime.Now && pd.endDate > DateTime.Now).OrderBy(pd => pd.discount.discount_percent).FirstOrDefault().discount.discount_percent) * new decimal(.01)
                 : 0,

            }).AsQueryable();

            return return_products.Select(p => new catalog
            {
                productName = p.productName,
                productDescription = p.productDescription,
                productId = p.productId,
                productPrice = p.productPrice,
                imageName = p.imageName,
                discountPercent = p.discountPercent,
                finalPrice = p.productPrice - Math.Round(p.discountPercent * p.productPrice, 2)
            }).AsQueryable();
        }

    }
}
