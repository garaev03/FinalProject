namespace Business.Utilities.Validations.AppUserValidations;
public class NumberValidation
{
    public bool IsAzerbaijanNumber(string? number)
    {
        if (number != null)
            if (number.StartsWith("70") || number.StartsWith("77") || number.StartsWith("50") || number.StartsWith("51") || number.StartsWith("55"))
                return true;
        return false;
    }
    public bool IsNumber(string? number)
    {
        if (number != null)
        {
            number = number.Trim().Replace(" ", "");
            if (number.Length != 9)
                return false;
            foreach (char c in number)
            {
                if (c < '0' || c > '9')
                    return false;
            }
        }
        return true;
    }
}