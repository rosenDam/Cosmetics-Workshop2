using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Text;

namespace Cosmetics.Models
{
    public abstract class Product : IProduct
    {
        private string _name;
        private string _brand;
        private decimal _price;
        private GenderType _gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            Name = name;
            Brand = brand;  
            Price = price;
            Gender = gender;
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                ValidateName(value);
                _name = value;
            }
        }

        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                ValidateBrand(value);
                _brand = value;

            }
        }

        public decimal Price
        {
            get
            {
                return _price;
            }

            set
            {
                ValidatePrice(value);
                _price = value;
            }
        }


        public GenderType Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }

        public abstract void ValidateName(string name);
        public abstract void ValidateBrand(string brand);
        public abstract void ValidatePrice(decimal price);

        public abstract string Print();
        public string PrintBaseProduct()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"#{Name} {Brand}");
            result.AppendLine($" #Price: {Price}");
            result.AppendLine($" #Gender: {Gender}");
            return result.ToString();
        }
    }
}
