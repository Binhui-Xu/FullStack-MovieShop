using System;
namespace ApplicationCore.Models
{
    public class UserReviewResponseModel
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string Review { get; set; }
        public decimal Rating { get; set; }
    }
}
