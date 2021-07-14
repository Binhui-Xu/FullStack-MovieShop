using System;
using System.Collections.Generic;
using System.Reflection;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public string PhoneNumber { get; set; }
        public Boolean TwoFactorEnabled { get; set; }
        public DateTime LockOutEndDate { get; set; }
        public DateTime LastLoginDateTime { get; set; }
        public Boolean IsLocked { get; set; }
        public int AccessFailedCount { get; set; }

        //Navigation
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<UserRole> userRoles { get; set; }
    }
}