﻿using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Collections.Generic;

namespace Cosmetics.Core.Contracts
{
    public interface IRepository
    {
        IShoppingCart ShoppingCart { get; }

        IList<ICategory> Categories { get; }

        IList<IProduct> Products { get; }

        IProduct FindProductByName(string productName);

        ICategory FindCategoryByName(string categoryName);

        void CreateCategory(string categoryToAdd);

        IShampoo CreateShampoo(string name, string brand, decimal price, GenderType genderType, int millilitres, UsageType usageType);

        IToothpaste CreateToothpaste(string name, string brand, decimal price, GenderType genderType, string ingredients);

        ICream CreateCream(string name, string brand, decimal price, GenderType genderType, ScentType scentType);

        bool CategoryExists(string categoryName);

        bool ProductExists(string productName);
    }
}
