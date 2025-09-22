using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebMVCCource.Attributes
{
    public class AddressVerificationAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string? address = value!.ToString();
            return Regex.IsMatch(address!, "(.+),(.+),(.+)");
        }
    }
}
