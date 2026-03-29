# TR-AUTH-001 - Kết quả kiểm thử tài khoản và bảo vệ admin

## Tham chiếu test case
- TC-AUTH-001 - Chức năng tài khoản và bảo vệ phần admin

## Môi trường kiểm thử
- OS: Windows
- Framework: ASP.NET Core MVC .NET 10
- Database: SQL Server LocalDB
- URL: http://localhost:5033
- Thời gian test: 2026-03-29

## Kết quả thực tế
1. Truy cập /Admin khi chưa đăng nhập bị chuyển về /tai-khoan/dang-nhap?ReturnUrl=%2FAdmin: PASS.
2. Đăng nhập admin / Admin@123 thành công và truy cập được khu vực Admin: PASS.
3. Truy cập trang quản lý tài khoản /Admin/Accounts thành công: PASS.
4. Tạo tài khoản nhanvien1 thành công: PASS.
5. Khóa tài khoản nhanvien1 thành công: PASS.
6. Thử khóa tài khoản admin mặc định bị chặn và hiển thị thông báo phù hợp: PASS.
7. Đăng xuất thành công, truy cập lại /Admin bị chuyển về trang đăng nhập: PASS.

## Trạng thái
PASS

## Lỗi phát hiện
Không ghi nhận lỗi chức năng trong phạm vi kiểm thử.

## Ảnh chụp màn hình
- manual-tests/test-results/screenshots/TC-AUTH-001-admin-redirect-login.png
- manual-tests/test-results/screenshots/TC-AUTH-002-admin-accounts-list.png
- manual-tests/test-results/screenshots/TC-AUTH-003-admin-lock-protection.png
