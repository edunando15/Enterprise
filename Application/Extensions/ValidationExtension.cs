using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Esame_Enterprise.Application.Extensions
{
    public static class ValidationExtension
    {

        public static void RegExt<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, string regEx, string validationMessage)
        {
            ruleBuilder.Custom((value, context) =>
            {
                var regex = new Regex(regEx);
                if(!regex.IsMatch(value.ToString()))
                {
                    context.AddFailure(validationMessage);
                }
            });
        }

    }
}
