namespace Vehicle.BLL.Models
{
    public class UserPhoneNumber
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string PhoneNumber { get; set; }

        public virtual User User { get; set; }
    }
}
