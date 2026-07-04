namespace BookingBackendWebApp.Services.Pos;

using BookingBackendWebApp.Models;

public class MockPosService : IPosService
{
    private readonly List<PosMenuItem> _menuItems = new()
    {
        new() { Id = 1, Name = "Nyama Choma Plate", Category = PosCategory.Food, Price = 1500, IsAvailable = true },
        new() { Id = 2, Name = "Fish & Chips", Category = PosCategory.Food, Price = 1200, IsAvailable = true },
        new() { Id = 3, Name = "Vegetable Curry", Category = PosCategory.Food, Price = 1000, IsAvailable = true },
        new() { Id = 4, Name = "Beer - Tusker", Category = PosCategory.Beverage, Price = 400, IsAvailable = true },
        new() { Id = 5, Name = "Soda", Category = PosCategory.Beverage, Price = 200, IsAvailable = true },
        new() { Id = 6, Name = "Fresh Juice", Category = PosCategory.Beverage, Price = 500, IsAvailable = true },
        new() { Id = 7, Name = "Safari Hat", Category = PosCategory.Gift, Price = 2500, IsAvailable = true },
        new() { Id = 8, Name = "T-Shirt", Category = PosCategory.Gift, Price = 3000, IsAvailable = false }
    };

    private readonly List<PosOrder> _orders = new()
    {
        new() { Id = 1, TableNumber = 5, Items = new() { new() { Id = 1, MenuItemId = 1, Quantity = 2, UnitPrice = 1500, TotalPrice = 3000 }, new() { Id = 2, MenuItemId = 4, Quantity = 2, UnitPrice = 400, TotalPrice = 800 } }, TotalAmount = 3800, Status = PosOrderStatus.Paid, CreatedAt = DateTime.Today.AddHours(-3) },
        new() { Id = 2, TableNumber = 3, Items = new() { new() { Id = 3, MenuItemId = 3, Quantity = 1, UnitPrice = 1000, TotalPrice = 1000 }, new() { Id = 4, MenuItemId = 6, Quantity = 2, UnitPrice = 500, TotalPrice = 1000 } }, TotalAmount = 2000, Status = PosOrderStatus.Open, CreatedAt = DateTime.Today.AddHours(-1) }
    };

    private readonly List<PosEndOfDay> _endOfDays = new()
    {
        new() { Id = 1, Date = DateTime.Today.AddDays(-1), TotalSales = 35000, CashTotal = 15000, CardTotal = 20000, PaymentCount = 24 }
    };

    private int _nextMenuItemId = 9;
    private int _nextOrderId = 3;
    private int _nextOrderItemId = 5;
    private int _nextEodId = 2;

    public Task<List<PosMenuItem>> GetMenuItemsAsync() => Task.FromResult(_menuItems.ToList());
    public Task<PosMenuItem> CreateMenuItemAsync(PosMenuItem item) { item.Id = _nextMenuItemId++; _menuItems.Add(item); return Task.FromResult(item); }
    public Task<PosMenuItem> UpdateMenuItemAsync(PosMenuItem item)
    {
        var i = _menuItems.FindIndex(x => x.Id == item.Id);
        if (i >= 0) _menuItems[i] = item;
        return Task.FromResult(item);
    }
    public Task<bool> ToggleMenuItemAvailabilityAsync(int id)
    {
        var item = _menuItems.FirstOrDefault(x => x.Id == id);
        if (item is null) return Task.FromResult(false);
        item.IsAvailable = !item.IsAvailable;
        return Task.FromResult(true);
    }
    public Task<List<PosOrder>> GetOrdersAsync() => Task.FromResult(_orders.ToList());
    public Task<PosOrder?> GetOrderAsync(int id) => Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));

    public Task<PosOrder> CreateOrderAsync(PosOrder order)
    {
        order.Id = _nextOrderId++;
        order.CreatedAt = DateTime.Now;
        order.Status = PosOrderStatus.Open;
        _orders.Add(order);
        return Task.FromResult(order);
    }

    public Task<PosOrder> AddOrderItemAsync(int orderId, PosOrderItem item)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order is null) return Task.FromResult(new PosOrder());
        item.Id = _nextOrderItemId++;
        order.Items.Add(item);
        order.TotalAmount = order.Items.Sum(i => i.TotalPrice);
        return Task.FromResult(order);
    }

    public Task<bool> ProcessPaymentAsync(int orderId, decimal amount)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order is null) return Task.FromResult(false);
        order.Status = PosOrderStatus.Paid;
        return Task.FromResult(true);
    }

    public Task<PosEndOfDay> GetEndOfDayAsync(DateTime date) =>
        Task.FromResult(_endOfDays.FirstOrDefault(e => e.Date.Date == date.Date) ?? new PosEndOfDay { Date = date });

    public Task<PosEndOfDay> CloseDayAsync(PosEndOfDay eod)
    {
        eod.Id = _nextEodId++;
        _endOfDays.Add(eod);
        return Task.FromResult(eod);
    }
}
