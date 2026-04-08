Tạo Entity 
Setup mối quan hệ giữa các Entity
- 1 là để .NET tự generate ra
- 2 là config trong DbContext
Tạo file DbContext
Tạo Migration và Update

Tạo Interface cho mỗi Service
Định nghĩa các Request đầu vào sẽ cần gì
Định nghĩa các Response trả ra như thế nào
Tạo những method bên trong interface đó
Tạo class Service để impleng menhu74 metho đã định nghĩa trong API
Đi lên file Program.cs trong API để đăng ký các Service vào Dependency Inject

Tạo Controller cho Service đã tạo
Định nghãi các endpoint controller
Định nghĩa request đầu vào cần gì
- Có body hay không
- Có query hay không
- Có path | route parameter hay không
Endpoint này có cần Authen hay Author không
