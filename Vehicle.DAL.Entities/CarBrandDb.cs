using System.Collections.Generic;

namespace Vehicle.DAL.Entities
{
    public class CarBrandDb
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<UserDb> User { get; set; }
    }
}