using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Vehicle.Constants;
using Vehicle.Constants.Enums;

namespace Vehicle.ViewModels.Users
{
    public class UserModel
    {
        [StringLength(50, ErrorMessage = ValidationMessages.StringLengthName)]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = ValidationMessages.StringLengthName)]
        public string MiddleName { get; set; }

        [StringLength(50, ErrorMessage = ValidationMessages.StringLengthName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredFieldEmail, AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = ValidationMessages.RegexEmailAddress)]
        [StringLength(254, ErrorMessage = ValidationMessages.StringLengthEmail)]
        public string Email { get; set; }

        public Collection<UserPhoneNumberModel> PhoneNumbers { get; set; }

        public SexEnum Sex { get; set; }
    }
}
