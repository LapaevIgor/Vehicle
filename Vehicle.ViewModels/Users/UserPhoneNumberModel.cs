using System.ComponentModel.DataAnnotations;
using Vehicle.Constants;

namespace Vehicle.ViewModels.Users
{
    public class UserPhoneNumberModel
    {
        public int? UserId { get; set; }

        [StringLength(13, ErrorMessage = ValidationMessages.StringLengthPhoneNumber)]
        [Required(ErrorMessage = ValidationMessages.RequiredFieldPhoneNumber, AllowEmptyStrings = false)]
        [RegularExpression(@"^\+375[0-9]{9}$", ErrorMessage = ValidationMessages.RegexPhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
