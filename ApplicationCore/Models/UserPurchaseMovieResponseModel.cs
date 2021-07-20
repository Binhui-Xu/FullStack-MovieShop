using System;

namespace ApplicationCore.Models
{
    public class UserPurchaseMovieResponseModel
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }
    }
}