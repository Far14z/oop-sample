using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.model.ValueObjects;

namespace ACME.OOP.Procurement.Domain.Model.Aggregates;

/// <summary>
/// This class represents a purchase order aggregate root for the procurement bounded context.
/// </summary>
/// <param name="orderNumber">The unique identifier for the purchase order</param>
/// <param name="supplierId">The unique identifier for the supplier. See <see cref="SupplierId"/></param>
/// <param name="orderDate">The date and the time of the order</param>
/// <param name="currency"></param>
public class PurchaseOrder(string orderNumber, SupplierId supplierId, DateTime orderDate, string currency)
{
    private readonly List<PurchaseOrderItem> _items = [];
    public string OrderNumber { get; } = orderNumber ?? throw new ArgumentNullException(nameof(orderNumber));
    public SupplierId SupplierId { get; } = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    public DateTime OrderDate { get; } = orderDate;

    public string Currency { get; } = string.IsNullOrWhiteSpace(currency) || currency.Length != 3
        ? throw new ArgumentException("Currency must be a 3-letter ISO code", nameof(Currency)) : currency;
    
    public IReadOnlyList<PurchaseOrderItem> Items => _items.AsReadOnly();

    /// <summary>
    /// This constructor is used to create a new purchase order with the current date and time.
    /// </summary>
    /// <remarks>
    /// This constructor initializes the order date to the current date and time.
    /// </remarks>
    /// <param name="orderNumber"></param>
    /// <param name="supplierId"></param>
    /// <param name="currency"></param>
    public PurchaseOrder(string orderNumber, SupplierId supplierId, string currency)
        : this(orderNumber, supplierId, DateTime.UtcNow, currency)
    {
        
    }

    /// <summary>
    /// Adds an item to the purchase order.
    /// </summary>
    /// <param name="productId">The unique identifier for the product</param>
    /// <param name="quantity"></param>
    /// <param name="unitPriceAmount"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void AddItem(ProductId productId, int quantity, decimal unitPriceAmount)
    {
        ArgumentNullException.ThrowIfNull(productId, nameof(productId));
        
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        
        if (unitPriceAmount <= 0)
            throw new ArgumentOutOfRangeException(nameof(unitPriceAmount), "UnitPriceAmount must be greater than zero.");

        var unitPrice = new Money(unitPriceAmount, Currency);
        var item = new PurchaseOrderItem(productId, quantity, unitPrice);
        _items.Add(item);
    }

    /// <summary>
    /// Calculates the total amount of the purchase order by summing the subtotals of all items.
    /// </summary>
    /// <returns>A <see cref="Money"/>> </returns>
    public Money CalculateTotal()
    {
        var total = _items.Sum(item => item.CalculateSubTotal.Amount);
        return new Money(total, Currency);
    }
}