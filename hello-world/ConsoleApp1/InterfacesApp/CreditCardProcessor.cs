using System;

namespace InterfacesApp;

public class CreditCardProcessor : IPaymentProcesser
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount}");
        // Implement credit card payment logic
    }
}
public class PaypalProcessor : IPaymentProcesser
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing paypal payment of {amount}");
        // Implement paypal payment logic
    }
}

public class PaymentService
{
    private readonly IPaymentProcesser _processor;

    public PaymentService(IPaymentProcesser proccesor)
    {
        _processor = proccesor;
    }

    public void ProcessOrderPayment(decimal amount)
    {
        _processor.ProcessPayment(amount);
    }
}
