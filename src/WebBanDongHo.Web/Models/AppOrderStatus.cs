namespace WebBanDongHo.Web.Models;

public static class AppOrderStatus
{
    public const string Pending = "Pending";
    public const string Confirmed = "Confirmed";
    public const string Shipping = "Shipping";
    public const string Completed = "Completed";
    public const string Cancelled = "Cancelled";

    public static readonly IReadOnlyList<string> All =
    [
        Pending,
        Confirmed,
        Shipping,
        Completed,
        Cancelled
    ];
}
