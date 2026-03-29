using WebBanDongHo.Web.Models;

namespace WebBanDongHo.Web.ViewModels;

public class AdminOrderDetailViewModel
{
    public required AppOrder Order { get; set; }

    public IReadOnlyList<AppOrderItem> Items { get; set; } = [];
}
