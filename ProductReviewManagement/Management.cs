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

        //UC2 Get Top 3 highest rated products

        public void TopRecords(List<ProductReview> productReviewsList)
        {
            var recordedData = (from productReview in productReviewsList
                                orderby productReview.Rating descending
                                select productReview).Take(3);


            Console.WriteLine("\nTop Reviews\n");

            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, UserId : {list.UserId}, Rating: {list.Rating}, Review : {list.Review}, IsLike : {list.IsLike}");
            }

            Console.WriteLine();

        }


        // UC3 Get records with review greater than 3 among (1,4,9)\n");

        public void SelectRecords(List<ProductReview> productReviewsList)
        {
            var recordedData = (from productReview in productReviewsList
                                where ((productReview.ProductId == 1 && productReview.Rating > 3) || (productReview.ProductId == 4 && productReview.Rating > 3) || (productReview.ProductId == 9 && productReview.Rating > 3))
                                select productReview);


            Console.WriteLine("Records with review greater than 3 in (1,4,9)\n");

            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, UserId : {list.UserId}, Rating: {list.Rating}, Review : {list.Review}, IsLike : {list.IsLike}");
            }
            Console.WriteLine();

        }


        // UC4 Get records Id's along with the number of reviews 
        public void CountOfReviews(List<ProductReview> productReviewsList)
        {
            var recordedData = productReviewsList.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });

            Console.WriteLine("Records Id's with Review count \n");

            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, Count : {list.Count}"); 
            }
            Console.WriteLine();

        }


        //UC5 & 7 Records Id's with their Review

        public void ProductIdwithReviews(List<ProductReview> productReviewsList)
        {
            var recordedData = (from productReview in productReviewsList                     
                                select new { productId = productReview.ProductId, Review = productReview.Review } );
            Console.WriteLine("Records Id's with Review\n");

            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductId: {list.productId}, Review: {list.Review}");
            }
            Console.WriteLine();
        }

        // UC6  Get Records after skipping first 5 records

        public void SkipTop5Records(List<ProductReview> productReviews)
        {
            var records = (from productReview in productReviews select productReview).Skip(5);

            Console.WriteLine("Records after skipping first 5\n");

            foreach (var list in records)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, UserId : {list.UserId}, Rating: {list.Rating}, Review : {list.Review}, IsLike : {list.IsLike}");
            }
            Console.WriteLine();

        }

        // UC 9 Get Liked Products 
        public void LikedProducts(List<ProductReview> productReviewsList)
        {
            var records = from product in productReviewsList
                          where product.IsLike == true
                          select product;

            Console.WriteLine("Liked Products are\n");

            foreach (var list in records)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, UserId : {list.UserId}, Rating: {list.Rating}, Review : {list.Review}, IsLike : {list.IsLike}");
            }
            Console.WriteLine();

        }

        // UC10 Proucts with their Avarage Rating
        public void ProductAvarageRating(List<ProductReview> productReviews)
        {
            //var records = productReviews.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Average() });
            
            var records  = from productReview in productReviews
                           group productReview by productReview.ProductId into productAvarageRating
                           select new
                           {
                               productId = productAvarageRating.Key,
                               AverageRating = productAvarageRating.Average(x => x.Rating),
                           };


            Console.WriteLine("Avarage Rating of Products are\n");

            foreach (var list in records)
            {
                Console.WriteLine($"ProductId: {list.productId}, Count : {list.AverageRating}");
            }

            Console.WriteLine();
        }




        // UC11 Proucts with nice in their review
        public void NiceReviewedProducts(List<ProductReview> productReviews)
        {
            var records = from product in productReviews
                          where product.Review.Equals("nice")
                          select product;



            Console.WriteLine("Proucts with 'nice' in their review\n");

            foreach (var list in records)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, UserId : {list.UserId}, Rating: {list.Rating}, Review : {list.Review}, IsLike : {list.IsLike}");

            }
        }


        // UC12 producs reviewed by user ID 10 rated in Ascending order
        public void ProductReviewedByUserId10(List<ProductReview> productReviews)
        {          
            var records = from product in productReviews
                          orderby product.Rating
                          where product.UserId == 10
                          select product;

            Console.WriteLine("\nProducs reviewed by user ID 10 rated in Ascending order\n");

            foreach (var list in records)
            {
                Console.WriteLine($"ProductId: {list.ProductId}, UserId : {list.UserId}, Rating: {list.Rating}, Review : {list.Review}, IsLike : {list.IsLike}");

            }
        }

    }

}

