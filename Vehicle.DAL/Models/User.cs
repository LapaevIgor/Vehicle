using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        
        public string Login { get; set; }
                
        public string EmailAddress { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public bool IsActive { get; set; }
    }
}
