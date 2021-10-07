using System;
using Vehicle.Constants.Enums;

namespace Vehicle.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public SexEnum Sex { get; set; }

        public int FavoriteCarBrand { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public bool IsActive { get; set; }
    }
}
