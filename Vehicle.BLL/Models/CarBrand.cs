using System.Collections.Generic;

namespace Vehicle.BLL.Models
{
    public class CarBrand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
    }
}
