﻿namespace TestAuto.Application.Exeptions
{
    public class PaymentFailedException : Exception
    {
        public PaymentFailedException(string message) 
            : base(message) { }
    }
}
