using System.ComponentModel.DataAnnotations;

namespace WebBanDongHo.Web.ViewModels;

public class WatchFormViewModel
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập thương hiệu.")]
    [StringLength(100)]
    public string Brand { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập mã SKU.")]
    [StringLength(50)]
    public string Sku { get; set; } = string.Empty;

    [StringLength(400)]
    public string? ShortDescription { get; set; }

    [StringLength(2000)]
    public string? LongDescription { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập loại máy.")]
    [StringLength(100)]
    public string MovementType { get; set; } = string.Empty;

    [Range(20, 60, ErrorMessage = "Kích thước mặt phải trong khoảng 20-60 mm.")]
    public decimal CaseSizeMm { get; set; }

    [Range(0, 1000, ErrorMessage = "Khả năng chống nước không hợp lệ.")]
    public int WaterResistanceM { get; set; }

    [StringLength(500)]
    public string? ImageUrl { get; set; }

    [Range(1000, 1000000000, ErrorMessage = "Giá bán không hợp lệ.")]
    public decimal Price { get; set; }

    [Range(0, 100000, ErrorMessage = "Tồn kho không hợp lệ.")]
    public int Stock { get; set; }
}
