using System;
namespace ApplicationCore.Models
{
    public class UserFavoriteResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
