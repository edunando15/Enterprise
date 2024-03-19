using FluentValidation;
using System.Text.RegularExpressions;

namespace Esame_Enterprise.Application.Extensions
{
    public static class ValidationExtension
    {

        public static void RegEx<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, string regEx, string validationMessage)
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
