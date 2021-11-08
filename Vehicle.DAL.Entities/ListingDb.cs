using System;

namespace Vehicle.DAL.Entities
{
    public class ListingDb
    {
        public int Id { get; set; }

        public CarBrandDb CarBrandID { get; set; }

        public string CarModel { get; set; }

        public int CarYear { get; set; } //TODO type of int or DateTime 

        public string Description { get; set; }

        public decimal Price { get; set; }

        public UserDb CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedBy { get; set; }
    }
}
