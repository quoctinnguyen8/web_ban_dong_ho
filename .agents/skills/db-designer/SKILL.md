---
name: db-designer
description: Kỹ năng thiết kế cơ sở dữ liệu theo tiêu chuẩn của dự án.
---

## Quy tắc thiết kế cơ sở dữ liệu:
1. Mỗi bảng phải có một tiền tố rõ ràng để phân biệt, các loại tiền tố của dự án bao gồm:
   - `App`: Dùng cho bảng chính của ứng dụng, chứa dữ liệu cốt lõi.
   - `Mst`: Dùng cho bảng master, chứa dữ liệu tham chiếu và cấu hình.
   - `Tmp`: Dùng cho bảng tạm, phục vụ cho các thao tác trung gian hoặc lưu trữ tạm thời.
2. Tên bảng phải được đặt theo quy tắc PascalCase, bắt đầu bằng tiền tố và theo sau là tên mô tả rõ ràng về nội dung của bảng.
3. Mỗi bảng `App` phải có các cột sau:
    - `Id`: Kiểu dữ liệu `int`, là khóa chính, tự động tăng.
    - `CreatedDate`: Kiểu dữ liệu `datetime`, lưu trữ ngày tạo bản ghi.
    - `LastModifiedDate`: Kiểu dữ liệu `datetime`, lưu trữ ngày sửa đổi bản ghi gần nhất.
    - `DeletedDate`: Kiểu dữ liệu `datetime`, lưu trữ ngày bản ghi bị xóa (mềm).
    - `CreatedBy`: Kiểu dữ liệu `int`, lưu trữ ID người tạo bản ghi.
    - `ModifiedBy`: Kiểu dữ liệu `int`, lưu trữ ID người sửa đổi bản ghi.
4. Mỗi bảng `Mst` phải có các cột sau:
    - `Id`: Kiểu dữ liệu `int`, là khóa chính, tự động tăng.
    - `CreatedDate`: Kiểu dữ liệu `datetime`, lưu trữ ngày tạo bản ghi.
    - `DeletedDate`: Kiểu dữ liệu `datetime`, lưu trữ ngày bản ghi bị xóa (mềm).
5. Bảng `Tmp` có thể có cấu trúc linh hoạt tùy thuộc vào mục đích sử dụng, nhưng nên tuân thủ các quy tắc đặt tên và kiểu dữ liệu phù hợp với dự án.