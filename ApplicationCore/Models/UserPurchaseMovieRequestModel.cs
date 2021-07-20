using System;
using System.Reflection;
using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
    public class UserPurchaseMovieRequestModel
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public int MovieId { get; set; }
        
    }
}