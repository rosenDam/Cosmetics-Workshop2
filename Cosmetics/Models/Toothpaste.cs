using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics.Models
{
    public class Toothpaste : Product, IToothpaste
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private string _ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients) : base(name,brand,price,gender)
        {
            Ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return _ingredients;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Ingredients must not be null!");
                }
                
                _ingredients = value;
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
            ValidationHelper.ValidateNonNegative(price, "Price must not be negative");
        }

        public override string Print()
        {

            string ingredients = String.Join(", ", Ingredients.Split(","));
            StringBuilder result = new StringBuilder(PrintBaseProduct());
            result.AppendLine($"#Ingredients: {ingredients}");
            result.AppendLine(" ===");

            return result.ToString();
        }
    }
}
