using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Company.Application.UseCase.AddUnitCompany
{
    public class AddUnitCompanyCommandValidator : AbstractValidator<AddUnitCompanyCommand>
    {
        Regex regex = new("([^0-9]{2})\\w+");
        public AddUnitCompanyCommandValidator() 
        { 
            RuleFor(company => company.Name)
                .NotEmpty();
            RuleFor(company => company.Isin)
                .NotEmpty()
                .Must(value => regex.IsMatch(value));
            RuleFor(company => company.Ticker)
                .NotEmpty();
            RuleFor(company => company.Exchange)
                .NotEmpty();
        }
    }
}
