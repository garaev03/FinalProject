﻿namespace Business.Utilities.Exceptions;
public class LimitExceededException:Exception
{
    public LimitExceededException(string message) : base(message) { }
}