# TC-ORDER-UI-001 - Quản lý đơn hàng và giao diện admin

## Mục tiêu
Xác minh chức năng đặt hàng từ giỏ hàng, quản trị đơn hàng trong admin và giao diện admin mới bằng Bootstrap 5.

## Tiền điều kiện
- Ứng dụng chạy tại http://localhost:5033.
- Đăng nhập admin thành công.

## Bước thực hiện
1. Thêm sản phẩm vào giỏ hàng từ trang chủ.
2. Mở trang giỏ hàng, nhập thông tin nhận hàng và bấm "Đặt hàng ngay".
3. Kiểm tra thông báo đặt hàng thành công và mã đơn được tạo.
4. Vào admin, mở trang /Admin/Orders để xem danh sách đơn.
5. Mở chi tiết đơn vừa tạo và kiểm tra thông tin khách hàng + danh sách sản phẩm.
6. Cập nhật trạng thái đơn từ Pending sang Confirmed.
7. Mở trang quản trị sản phẩm và quản trị tài khoản để đánh giá giao diện admin mới.

## Kết quả mong đợi
- Đơn hàng được tạo thành công từ giỏ hàng.
- Đơn hiển thị trong danh sách admin với đầy đủ thông tin và tổng tiền.
- Cập nhật trạng thái đơn thành công.
- Giao diện admin thống nhất, hiện đại, dễ thao tác trên Bootstrap 5.
