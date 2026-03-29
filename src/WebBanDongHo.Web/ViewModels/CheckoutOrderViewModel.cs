using System.ComponentModel.DataAnnotations;

namespace WebBanDongHo.Web.ViewModels;

public class CheckoutOrderViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập họ tên người nhận.")]
    [StringLength(120)]
    [Display(Name = "Họ tên người nhận")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
    [StringLength(20)]
    [Display(Name = "Số điện thoại")]
    public string CustomerPhone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập địa chỉ nhận hàng.")]
    [StringLength(250)]
    [Display(Name = "Địa chỉ nhận hàng")]
    public string CustomerAddress { get; set; } = string.Empty;

    [StringLength(500)]
    [Display(Name = "Ghi chú")]
    public string? Note { get; set; }
}
