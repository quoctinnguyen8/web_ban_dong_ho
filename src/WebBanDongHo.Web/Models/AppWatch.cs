namespace WebBanDongHo.Web.Models;

public class AppWatch
{
    public int Id { get; set; }

    public string Brand { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Sku { get; set; } = string.Empty;

    public string? ShortDescription { get; set; }

    public string? LongDescription { get; set; }

    public string MovementType { get; set; } = string.Empty;

    public decimal CaseSizeMm { get; set; }

    public int WaterResistanceM { get; set; }

    public string? ImageUrl { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int CreatedBy { get; set; }

    public int ModifiedBy { get; set; }
}
