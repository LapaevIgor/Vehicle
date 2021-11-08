using System;

namespace Vehicle.BLL.Exceptions
{
    public class CarBrandException : Exception
    {
        public CarBrandException(string message) : base(message)
        {

        }
    }
}