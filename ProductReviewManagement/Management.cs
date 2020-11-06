using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagement
{
    class Management
    {
        public readonly DataTable dataTable = new DataTable();

        //UC2
        public void TopRecords(List<ProductReview> productReviewsList)
        {
            var recordedData = (from productReview in productReviewsList
                                orderby productReview.Rating descending
                                select productReview).Take(3);


            Console.WriteLine("Top Reviews");

            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, UserId : {list.UserId}, Rating: {list.Rating}, Review : {list.Review}, IsLike : {list.IsLike}");
            }

        }

        // UC3
        public void SelectRecords(List<ProductReview> productReviewsList)
        {
            var recordedData = (from productReview in productReviewsList
                                where ((productReview.ProductId == 1 && productReview.Rating > 3) || (productReview.ProductId == 4 && productReview.Rating > 3) || (productReview.ProductId == 9 && productReview.Rating > 3))
                                select productReview);


            Console.WriteLine("Records with review greater than 3 in (1,4,9)");

            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, UserId : {list.UserId}, Rating: {list.Rating}, Review : {list.Review}, IsLike : {list.IsLike}");
            }

        }


        // UC4
        public void CountOfReviews(List<ProductReview> productReviewsList)
        {
            var recordedData = productReviewsList.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });

            Console.WriteLine("Records Id's with Review count ");

            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, Count : {list.Count}"); 
            }

        }


        //UC5 & 7

        public void ProductIdwithReviews(List<ProductReview> productReviewsList)
        {
            var recordedData = (from productReview in productReviewsList                     
                                select new { productId = productReview.ProductId, Review = productReview.Review } );
            Console.WriteLine("Records Id's with Review");

            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductId: {list.productId}, Review: {list.Review}");
            }

        }

        // UC6

        public void SkipTop5Records(List<ProductReview> productReviews)
        {
            var records = (from productReview in productReviews select productReview).Skip(5);

            Console.WriteLine("Records after skipping first 5");

            foreach (var list in records)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, UserId : {list.UserId}, Rating: {list.Rating}, Review : {list.Review}, IsLike : {list.IsLike}");
            }


        }

        // UC 9
        public void LikedProducts(List<ProductReview> productReviewsList)
        {
            var records = from product in productReviewsList
                          where product.IsLike == true
                          select product;

            Console.WriteLine("Liked Products are");

            foreach (var list in records)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, UserId : {list.UserId}, Rating: {list.Rating}, Review : {list.Review}, IsLike : {list.IsLike}");
            }

        }

        // UC10 Proucts with their Avarage Rating
        public void ProductAvarageRating(List<ProductReview> productReviews)
        {
            var records = productReviews.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Average = x.Average() });

            Console.WriteLine("Liked Products are");

            foreach (var list in records)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, Count : {list.Average}");
            }
        }

        }

    }
}
