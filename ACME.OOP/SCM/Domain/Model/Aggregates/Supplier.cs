using ACME.OOP.Shared.Domain.model.ValueObjects;

namespace ACME.OOP.SCM.Domain.Model.Aggregates;

/// <summary>
/// This class represents a supplier aggregate in the bounded context of the Supply Chain Managment
/// </summary>
/// <param name="identifier">The unique Identifier for the supplier</param>
/// <param name="name">The name of the supplier</param>
/// <param name="address">The address of the supplier. See <see cref="Address"/>> </param>
/// 
public class Supplier(string identifier, string name, Address address)
{
    
    public string Identifier { get; } = identifier ?? throw new ArgumentNullException(nameof(identifier));
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    public Address Address { get; } = address ?? throw new ArgumentNullException(nameof(address));
}

