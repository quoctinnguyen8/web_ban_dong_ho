namespace WebBanDongHo.Web.ViewModels;

public class CartItemViewModel
{
    public int WatchId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Sku { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public int AvailableStock { get; set; }

    public decimal LineTotal => UnitPrice * Quantity;
}
