﻿using ACME.OOP.Procurement.Domain.Model.Aggregates;
using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.SCM.Domain.Model.Aggregates;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.model.ValueObjects;

// Create a new Supplier object
var supplierAddress = new Address("Main street", "123", "New York", "New York", "NY", "USA");
var supplier = new Supplier("SUP001", "Microsoft, Inc.", supplierAddress);

// Create a PurchaseOrder object
var purchaseOrder = new PurchaseOrder("PO001", new SupplierId(supplier.Identifier), "USD");
purchaseOrder.AddItem(ProductId.New(), 10, 25.99m);
purchaseOrder.AddItem(ProductId.New(), 5, 15.99m);

// Display the purchase order details
Console.WriteLine($"Purchase Order ID: {purchaseOrder.OrderNumber} created on {purchaseOrder.OrderDate}" +
                  $"for supplier {supplier.Name}");
foreach (var item in purchaseOrder.Items)
{
    Console.WriteLine($"Item Subtotal: {item.CalculateSubTotal.Amount} {item.CalculateSubTotal.Currency}");
}

var total = purchaseOrder.CalculateTotal();
Console.WriteLine($"Total: {total.AsString()} ");
