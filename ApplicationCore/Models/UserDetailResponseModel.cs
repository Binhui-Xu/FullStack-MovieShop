using System;
using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
    public class UserDetailResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<UserRole> userRoles { get; set; }
    }
}