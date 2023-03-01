namespace Business.Utilities.Validations.CustomValidation
{
    public  class EmailValidation
    {
        public bool isEmail(string? email)
        {
            if (email is not null)
            {
                Regex rx = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (rx.IsMatch(email))
                    return true;
            }
            return false;
        }
    }
}
