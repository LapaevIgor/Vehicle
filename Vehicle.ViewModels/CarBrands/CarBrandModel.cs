using System.ComponentModel.DataAnnotations;
using Vehicle.Constants;

namespace Vehicle.ViewModels.CarBrands
{
    public class CarBrandModel
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = ValidationMessages.StringLengthCarBrandName)]
        [Required(ErrorMessage = ValidationMessages.RequiredFieldCarBrandName, AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
