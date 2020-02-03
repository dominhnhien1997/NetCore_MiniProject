using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validator
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder.NotEmpty()
                                     .MinimumLength(6)
                                     .WithMessage("Password must be at least 6 characters")
                                     .Matches("[A-Z]")
                                     .WithMessage("Password must conatins 1 uppercase letter")
                                     .Matches("[0-9]").WithMessage("Password must conatins 1 number")
                                     .Matches("[a-z]").WithMessage("Password must conatins 1 lowrcase")
                                     .Matches("[^a-zA-Z0-9]").WithMessage("Password must contains non alphanumeric");
            return options;
        }
    }
}
