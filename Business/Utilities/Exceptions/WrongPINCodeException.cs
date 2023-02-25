namespace Business.Utilities.Exceptions;
public class WrongPINCodeException:Exception
{
	public WrongPINCodeException(string message) : base(message) { }
}