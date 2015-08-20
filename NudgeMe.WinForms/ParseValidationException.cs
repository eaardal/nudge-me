using System;

namespace NudgeMe.WinForms
{
    internal class ParseValidationException : Exception
    {
        public ParseValidationException(string message) : base($"Could not parse or validate {message}")
        {
            
        }
    }
}