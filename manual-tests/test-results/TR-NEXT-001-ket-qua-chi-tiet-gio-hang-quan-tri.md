# TR-NEXT-001 - Kết quả kiểm thử chi tiết, giỏ hàng, quản trị

## Tham chiếu test case
- TC-NEXT-001 - Chi tiết sản phẩm, giỏ hàng và quản trị

## Môi trường kiểm thử
- OS: Windows
- Framework: ASP.NET Core MVC .NET 10
- Database: SQL Server LocalDB
- URL: http://localhost:5033
- Thời gian test: 2026-03-29

## Kết quả thực tế
1. Trang chủ hiển thị danh sách sản phẩm và nút "Xem chi tiết": PASS.
2. Trang chi tiết sản phẩm hiển thị đúng thông tin kỹ thuật và mô tả: PASS.
3. Thêm sản phẩm từ trang chi tiết vào giỏ hàng thành công: PASS.
4. Trang giỏ hàng hiển thị đúng các sản phẩm trong session: PASS.
5. Cập nhật số lượng sản phẩm trong giỏ hàng thành công; tạm tính đổi từ 24,100,000 đ sang 42,600,000 đ: PASS.
6. Trang quản trị hiển thị danh sách sản phẩm hiện tại: PASS.
7. Thêm mới sản phẩm CIT-TSU-001 thành công: PASS.
8. Cập nhật tồn kho sản phẩm CIT-TSU-001 từ 6 lên 7 thành công: PASS.
9. Ẩn mềm sản phẩm CIT-TSU-001 thành công, sản phẩm biến mất khỏi danh sách quản trị: PASS.

## Trạng thái
PASS

## Lỗi phát hiện
Không ghi nhận lỗi chức năng trong phạm vi kiểm thử.

## Ảnh chụp màn hình
- manual-tests/test-results/screenshots/TC-NEXT-001-home-list-and-detail-entry.png
- manual-tests/test-results/screenshots/TC-NEXT-001-product-detail.png
- manual-tests/test-results/screenshots/TC-NEXT-002-cart-session.png
- manual-tests/test-results/screenshots/TC-NEXT-002-cart-update-quantity.png
- manual-tests/test-results/screenshots/TC-NEXT-003-admin-watch-crud.png
