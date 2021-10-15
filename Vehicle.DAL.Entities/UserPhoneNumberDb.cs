namespace Vehicle.DAL.Entities
{
    public class UserPhoneNumberDb
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string PhoneNumber { get; set; }

        public virtual UserDb User { get; set; }
    }
}