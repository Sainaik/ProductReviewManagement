using System;
using System.Collections.Generic;

namespace ProductReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Product Review problem");

            List<ProductReview> productReviewsList = new List<ProductReview>()
            {

                new ProductReview(){ProductId = 1, UserId = 1, Rating = 5, Review = "cool", IsLike = true},

                new ProductReview(){ProductId = 2, UserId = 9, Rating = 4, Review = "Not Bad", IsLike = true},

                new ProductReview(){ProductId = 3, UserId = 2, Rating = 4, Review = "good", IsLike = true },

                new ProductReview(){ProductId = 4, UserId = 3, Rating = 3, Review = "avarage", IsLike = true},

                new ProductReview(){ProductId = 5, UserId = 4, Rating = 2, Review = "bad", IsLike = false },

                new ProductReview(){ProductId = 6, UserId = 5, Rating = 5, Review = "cool", IsLike = true},

                new ProductReview(){ProductId = 7, UserId = 6, Rating = 4, Review = "good", IsLike = true },

                new ProductReview(){ProductId = 8, UserId = 7, Rating = 3, Review = "avarage", IsLike = true},

                new ProductReview(){ProductId = 9, UserId = 8, Rating = 2, Review = "bad", IsLike = false },

                new ProductReview(){ProductId = 10, UserId = 3, Rating = 1, Review = "bad", IsLike = false },
            };

            foreach(var list in productReviewsList)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, UserId : {list.UserId}, Rating: {list.Rating}, Review : {list.Review}, IsLike : {list.IsLike}");
            }


            Management management = new Management();
            //management.TopRecords(productReviewsList);
            //management.SelectRecords(productReviewsList);
            //management.CountOfReviews(productReviewsList);
            //management.ProductIdwithReviews(productReviewsList);
            //management.SkipTop5Records(productReviewsList);
            //management.LikedProducts(productReviewsList);
            management.ProductAvarageRating(productReviewsList);
        }
    }
}
