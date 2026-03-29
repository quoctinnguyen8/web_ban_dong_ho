# TR-ORDER-UI-001 - Kết quả kiểm thử quản lý đơn hàng và giao diện admin

## Tham chiếu test case
- TC-ORDER-UI-001 - Quản lý đơn hàng và giao diện admin

## Môi trường kiểm thử
- OS: Windows
- Framework: ASP.NET Core MVC .NET 10
- Database: SQL Server LocalDB
- URL: http://localhost:5033
- Thời gian test: 2026-03-29

## Kết quả thực tế
1. Thêm sản phẩm vào giỏ hàng thành công: PASS.
2. Đặt hàng từ giỏ hàng thành công, hệ thống sinh mã đơn DH-20260329-0001: PASS.
3. Admin xem được danh sách đơn hàng tại /Admin/Orders: PASS.
4. Admin xem được chi tiết đơn, gồm thông tin khách và danh sách sản phẩm: PASS.
5. Cập nhật trạng thái đơn từ Pending sang Confirmed thành công: PASS.
6. Giao diện admin trang Sản phẩm và Đơn hàng hiển thị tốt, layout card + table rõ ràng: PASS.

## Trạng thái
PASS

## Lỗi phát hiện
Không ghi nhận lỗi chức năng trong phạm vi kiểm thử.

## Ảnh chụp màn hình
- manual-tests/test-results/screenshots/TC-ORDER-001-admin-orders-list.png
- manual-tests/test-results/screenshots/TC-ORDER-002-order-detail-status-update.png
- manual-tests/test-results/screenshots/TC-ORDER-003-order-status-confirmed.png
- manual-tests/test-results/screenshots/TC-UI-ADMIN-001-watch-dashboard.png
