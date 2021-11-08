using System;
using System.Collections.Generic;
using Vehicle.Constants.Enums;

namespace Vehicle.BLL.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<UserPhoneNumber> UserPhoneNumbers { get; set; }

        public SexEnum Sex { get; set; }

        public virtual CarBrand FavoriteCarBrand { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public bool IsActive { get; set; }
    }
}
