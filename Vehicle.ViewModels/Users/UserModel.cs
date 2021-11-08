using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Vehicle.Constants;
using Vehicle.Constants.Enums;
using Vehicle.ViewModels.CarBrands;

namespace Vehicle.ViewModels.Users
{
    public class UserModel
    {
        [StringLength(50, ErrorMessage = ValidationMessages.StringLengthName)]
        [Required(ErrorMessage = ValidationMessages.RequiredFieldFirstName, AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = ValidationMessages.StringLengthName)]
        public string MiddleName { get; set; }

        [StringLength(50, ErrorMessage = ValidationMessages.StringLengthName)]
        [Required(ErrorMessage = ValidationMessages.RequiredFieldLastName, AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = ValidationMessages.RegexEmailAddress)]
        [StringLength(254, ErrorMessage = ValidationMessages.StringLengthEmail)]
        [Required(ErrorMessage = ValidationMessages.RequiredFieldEmail, AllowEmptyStrings = false)]
        public string Email { get; set; }

        public Collection<UserPhoneNumberModel> PhoneNumbers { get; set; }

        [EnumDataType(typeof(SexEnum), ErrorMessage = ValidationMessages.SexEnumDataType)]
        [Required]
        public SexEnum Sex { get; set; }

        //[DataType(typeof(CarBrandModel))]
        public CarBrandModel FavoriteCarBrand { get; set; }
    }
}