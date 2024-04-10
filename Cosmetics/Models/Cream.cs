using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Text;

namespace Cosmetics.Models
{

    internal class Cream : Product, ICream
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 15;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 15;

        private ScentType _scent;
        public Cream(string name, string brand, decimal price, GenderType gender, ScentType scent) : base(name,brand,price,gender)
        {
            Scent = scent;
        }

        public ScentType Scent
        {
            get
            {
                return _scent;
            }
            set
            {
                _scent = value;
            }
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder(PrintBaseProduct());
            result.AppendLine($" #Scent: {_scent}");
            return result.ToString();
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

    }
}
