# TC-AUTH-001 - Chức năng tài khoản và bảo vệ phần admin

## Mục tiêu
Xác minh hệ thống tài khoản hoạt động và khu vực admin được bảo vệ bằng đăng nhập/phân quyền.

## Tiền điều kiện
- Ứng dụng chạy tại http://localhost:5033.
- Database đã áp dụng migration AddAppAccountAndAuth.
- Có tài khoản mặc định admin / Admin@123.

## Bước thực hiện
1. Truy cập trực tiếp /Admin khi chưa đăng nhập.
2. Kiểm tra hệ thống chuyển hướng về trang đăng nhập với ReturnUrl.
3. Đăng nhập bằng tài khoản admin mặc định.
4. Kiểm tra vào được /Admin và truy cập được /Admin/Accounts.
5. Tạo mới một tài khoản nhân viên.
6. Khóa tài khoản nhân viên vừa tạo.
7. Thử khóa tài khoản admin mặc định.
8. Đăng xuất khỏi hệ thống.
9. Truy cập lại /Admin sau khi đăng xuất.

## Kết quả mong đợi
- /Admin bị chặn khi chưa đăng nhập.
- Đăng nhập admin thành công và vào được khu vực quản trị.
- Quản lý tài khoản hoạt động: tạo mới và khóa/mở được tài khoản thường.
- Không cho phép khóa tài khoản admin mặc định.
- Sau đăng xuất, truy cập /Admin tiếp tục bị chặn và chuyển về đăng nhập.
