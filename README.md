# LakesideProject
## Ứng dụng angular sử dụng api .net core 6.0

Ứng dụng có các chức năng 
- [x] Quản lý phòng khách sạn
- [x] Quản lý loại phòng
- [x] Quản lý đơn đặt phòng
- [x] Hoá đơn đặt phòng
- [x] Kiểm tra các phòng chưa được đặt trong khoảng thời gian
- [x] Thống kê, tổng doanh thu phòng, số lần đặt 
- [x] Cho phép khách hàng đặt phòng khách sạn
- [x] Cho phép khách hàng tìm kiếm phòng với thông tin phù hợp
- [x] Cho phép khách hàng xem thông tin chi tiết phòng
- [x] Tra cứu đặt phòng theo số điện thoại
- [ ] Tích hợp thanh toán trực tuyến

----
## Hướng dẫn sử dụng
### Back-end API

- Sửa chuỗi kết nối tới csdl trong file appsettings.json
- Mở trong visual studio -> Tools -> Package Manager Console
- Chạy lệnh `update-database` để migration cơ sở dữ liệu

Chạy ứng dụng trong lakesideAPI bằng chức năng debug với cổng localhost://7000

### Client Angular

- Trong ứng dụng angular mở teminal của project
- Chạy lệnh `npm install` để cài đặt các package của ứng dụng
- Chạy lệnh `ng serve -open` hoặc sử dụng `npm start` để chạy chương trình với cổng localhost://4200
