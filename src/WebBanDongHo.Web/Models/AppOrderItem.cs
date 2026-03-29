namespace WebBanDongHo.Web.Models;

public class AppOrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int WatchId { get; set; }

    public string WatchName { get; set; } = string.Empty;

    public string WatchSku { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public decimal LineTotal { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int CreatedBy { get; set; }

    public int ModifiedBy { get; set; }

    public AppOrder? Order { get; set; }
}
