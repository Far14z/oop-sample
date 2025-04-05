namespace ACME.OOP.Shared.Domain.model.ValueObjects;

public record Money // Es inmutable
{
    public decimal Amount { get; init; }
    public string Currency { get; init; }

    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
        {
            throw new ArgumentException("Currency must be 3 character long ISO currency code.", nameof(currency));
        }
        
        Amount = amount;
        Currency = currency;
    }
}