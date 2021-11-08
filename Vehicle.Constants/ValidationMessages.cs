namespace Vehicle.Constants
{
    public static class ValidationMessages
    {
        public const string StringLengthName = "Name cannot be longer than 50 characters.";
        public const string StringLengthEmail = "Email cannot be longer than 254 characters.";
        public const string RequiredFieldFirstName = "Required";
        public const string RequiredFieldLastName = "Required";
        public const string RequiredFieldPhoneNumber = "Required";
        public const string RequiredFieldEmail = "Required";
        public const string RegexEmailAddress = "Invalid email format.";
        public const string RegexPhoneNumber = "Invalid phone number format. The phone number should be in the following format: +375xxxxxxxxx";
        public const string StringLengthPhoneNumber = "Phone number cannot be longer than 13 characters.";
        public const string SexEnumDataType = "Invalid gender.";

        public const string StringLengthCarBrandName = "Car brand name cannot be longer than 50 characters.";
        public const string RequiredFieldCarBrandName = "Required";
    }
}
