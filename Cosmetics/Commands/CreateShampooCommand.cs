using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateShampooCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 6;
        
        public CreateShampooCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            string name = CommandParameters[0];
            string brand = CommandParameters[1];
            decimal price = ParseDecimalParameter(CommandParameters[2], "price");
            GenderType gender = ParseGenderType(CommandParameters[3]);
            int millilitres = ParseIntParameter(CommandParameters[4], "millilitres");
            UsageType usageType = ParseUsageType(CommandParameters[5]);

            if (Repository.ProductExists(name))
            {
                throw new ArgumentException("Shampoo already exists.");
            } 
            Repository.CreateShampoo(name, brand, price, gender, millilitres, usageType);

            return $"Shampoo with name {name} was created!";
        }


    }
}
