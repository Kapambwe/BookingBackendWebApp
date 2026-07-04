namespace BookingBackendWebApp.Models;

public enum PosCategory
{
    Food,
    Beverage,
    Gift,
    Curio
}

public enum PosOrderStatus
{
    Open,
    Paid,
    Cancelled
}

public class PosMenuItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PosCategory Category { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
}

public class PosOrder
{
    public int Id { get; set; }
    public int TableNumber { get; set; }
    public List<PosOrderItem> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
    public PosOrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class PosOrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int MenuItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}

public class PosEndOfDay
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalSales { get; set; }
    public decimal CashTotal { get; set; }
    public decimal CardTotal { get; set; }
    public int PaymentCount { get; set; }
}
