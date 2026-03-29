# TC-INIT-001 - Trang chủ hiển thị sản phẩm mẫu

## Mục tiêu
Xác minh trang chủ hiển thị danh sách đồng hồ từ cơ sở dữ liệu sau khi khởi tạo migration ban đầu.

## Tiền điều kiện
- Đã chạy migration InitialCreate.
- Ứng dụng đang chạy tại http://localhost:5033.

## Bước thực hiện
1. Mở trình duyệt và truy cập http://localhost:5033.
2. Quan sát tiêu đề khu vực sản phẩm trên trang chủ.
3. Kiểm tra số lượng thẻ sản phẩm đang hiển thị.
4. Kiểm tra thông tin cơ bản của từng sản phẩm: mã SKU, tên, mô tả ngắn, giá, tồn kho.

## Kết quả mong đợi
- Hiển thị tiêu đề "Bộ sưu tập đồng hồ".
- Có 3 sản phẩm mẫu được hiển thị.
- Mỗi sản phẩm có đủ SKU, tên, mô tả, giá và tồn kho.
- Không xuất hiện lỗi runtime hoặc trang trắng.
