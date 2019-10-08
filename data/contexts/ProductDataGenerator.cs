using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CTDI_Food.data.models;

namespace CTDI_Food.data.contexts
{
    public class ProductDataGenerator
    {
        public static void Initialize(IServiceProvider sp)
        {
            using (var context = new productsContext(productsContext.CreateNewContextOptions()))
            {
                if (context.product.Any())
                {
                    return;   // Data was already seeded
                }


                context.product.AddRange(generateProductsDataList());

                context.SaveChanges();
            }
        }
        public static IList<product> generateProductsDataList()
        {



            var products = new List<product>()
            {
            new product
            {
                productId = 1,
                imageName = "3412.png",
                productName = "Pickel",
                productDescription = "its a pickle what more do you need to know?",
                productPrice = new decimal(24.99),
                productDiscount= new List<productDiscount>() {
                        new productDiscount{
                            productDiscountId=1,
                             startDate= DateTime.Parse("9/11/2019"),
                             endDate = DateTime.Parse("9/11/2020"),
                            discount =new discount(){
                                discountId = 1,
                                discount_percent = 50,
                                discount_startDate = DateTime.Parse("9/11/2019"),
                                discount_endDate = DateTime.Parse("9/11/2020"),
                        }
                        }
                    }

        },

               new product
            {
                productId = 3,
                imageName = "3405.png",
                productName = "Grapes",
                productDescription = "You know people say after you these you will feel just grape.",
                productPrice = new decimal(75.99),
                productDiscount= new List<productDiscount>() {
                        new productDiscount{
                            productDiscountId=3,
                             startDate= DateTime.Parse("7/11/2019"),
                             endDate = DateTime.Parse("9/11/2020"),
                            discount=new discount(){
                                discountId = 1,
                                discount_percent = 50,
                                discount_startDate = DateTime.Parse("9/11/2019"),
                                discount_endDate = DateTime.Parse("9/11/2020"),
                        }
                        }
                    }

        },
                            new product
            {
                productId = 3471,
                imageName = "3471.png",
                productName = "Apple",
                productDescription = "You know what they say these guys will do to doctors, let me tell you when they make them go away it is not pretty.",
                productPrice = new decimal(5.99),

            },
                                          new product
            {
                productId = 3478,
                imageName = "3478.png",
                productName = "Egg Plant",
                productDescription = "I suppose if this were an emoji it would mean something else",
                productPrice = new decimal(33.99),

            },
                        new product
            {
                productId = 2,
                imageName = "3457.png",
                productName = "Pear",
                productDescription = "Sometimes there is nothing better than a good pear.  Our pears are awesome",
                productPrice = new decimal(5.99),

            },
                         new product
            {
                productId = 3424,
                imageName = "3424.png",
                productName = "Pineapple",
                productDescription = "They taste real good.  Nothing more needs to be said.",
                productPrice = new decimal(44.99),

            }

            };

            return products;
        }



    }
}
