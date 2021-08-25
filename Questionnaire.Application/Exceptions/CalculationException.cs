using System;

namespace Questionnaire.Application.Exceptions
{
    public class CalculationException : Exception
    {
        public CalculationException(string message) : base(message)
        {
            
        }
    }
}