using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Collections.Generic;
using System.Text;

namespace Cosmetics.Models
{
    public class Shampoo : Product, IShampoo
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private int _mililitres;
        private UsageType _usageType;

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage) : base(name, brand, price, gender)
        {
            Millilitres = millilitres;
            Usage = usage;
        }

        public int Millilitres
        {
            get
            {
                return _mililitres;
            }
            set
            {
                ValidationHelper.ValidateNonNegative(value, "Mililiters must not be negative!");
                _mililitres = value;
            }
        }

        public UsageType Usage
        {
            get 
            {
                return _usageType;
            }
            set
            {
                _usageType = value;
            }
        }

        public override void ValidateBrand(string brand)
        {
            ValidationHelper.ValidateStringLength(brand, BrandMinLength, BrandMaxLength);
        }

        public override void ValidateName(string name)
        {
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength);
        }

        public override void ValidatePrice(decimal price)
        {
            ValidationHelper.ValidateNonNegative(price, "Price must not be negative!");
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder(PrintBaseProduct());
            result.AppendLine($" #Milliliters: {_mililitres}");
            result.AppendLine($" #Usage: {_usageType}");
            result.AppendLine(" ===");

            return result.ToString();
        }
    }
}
