# TC-NEXT-001 - Chi tiết sản phẩm, giỏ hàng và quản trị

## Mục tiêu
Xác minh các tính năng giai đoạn tiếp theo hoạt động đầy đủ:
- Trang chi tiết sản phẩm.
- Giỏ hàng cơ bản bằng session (thêm, cập nhật số lượng, tính tổng).
- Quản trị sản phẩm (xem danh sách, thêm, sửa, ẩn mềm).

## Tiền điều kiện
- Ứng dụng chạy tại http://localhost:5033.
- Database đã áp dụng migration mới nhất.

## Bước thực hiện
1. Truy cập trang chủ và xác minh có nút "Xem chi tiết" cho từng sản phẩm.
2. Bấm "Xem chi tiết" của một sản phẩm, kiểm tra thông tin kỹ thuật và mô tả dài hiển thị đúng.
3. Tại trang chi tiết, thêm sản phẩm vào giỏ hàng.
4. Mở trang Giỏ hàng, kiểm tra sản phẩm vừa thêm xuất hiện đúng giá và số lượng.
5. Cập nhật số lượng của một dòng trong giỏ hàng, xác minh thành tiền và tạm tính thay đổi đúng.
6. Vào trang Quản trị, xác minh danh sách sản phẩm hiển thị.
7. Thêm một sản phẩm mới bằng form quản trị.
8. Sửa sản phẩm vừa thêm (ví dụ thay đổi tồn kho), xác minh dữ liệu được cập nhật.
9. Thực hiện ẩn mềm sản phẩm từ danh sách quản trị, xác minh sản phẩm không còn hiển thị trong danh sách.

## Kết quả mong đợi
- Route chi tiết hoạt động: /san-pham/{id}.
- Giỏ hàng lưu theo session và tính toán đúng.
- Quản trị thao tác thêm/sửa/ẩn thành công, có thông báo phản hồi phù hợp.
- Không xuất hiện lỗi runtime trong quá trình thao tác.
