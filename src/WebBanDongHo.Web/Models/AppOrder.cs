namespace WebBanDongHo.Web.Models;

public class AppOrder
{
    public int Id { get; set; }

    public string OrderCode { get; set; } = string.Empty;

    public string CustomerName { get; set; } = string.Empty;

    public string CustomerPhone { get; set; } = string.Empty;

    public string CustomerAddress { get; set; } = string.Empty;

    public string? Note { get; set; }

    public string Status { get; set; } = "Pending";

    public decimal TotalAmount { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int CreatedBy { get; set; }

    public int ModifiedBy { get; set; }

    public ICollection<AppOrderItem> OrderItems { get; set; } = [];
}
