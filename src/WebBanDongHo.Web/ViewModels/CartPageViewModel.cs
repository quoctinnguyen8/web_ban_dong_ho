namespace WebBanDongHo.Web.ViewModels;

public class CartPageViewModel
{
    public IReadOnlyList<CartItemViewModel> Items { get; set; } = [];

    public CheckoutOrderViewModel Checkout { get; set; } = new();

    public string? CreatedOrderCode { get; set; }

    public decimal Subtotal => Items.Sum(x => x.LineTotal);
}
