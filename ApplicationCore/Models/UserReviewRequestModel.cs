using System;
namespace ApplicationCore.Models
{
    public class UserReviewRequestModel
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string Review { get; set; }
        public decimal Rating { get; set; }
    }
}
