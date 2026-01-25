namespace TetPee.Repository;

public class Class1
{
    // ORM: Object-Relational Mapping
    
    // Code First và Database First
    
    //Thông thường để mà ở trên code mà để có thể làm việc với database
        // thì mình cần ánh xạ (mapping ) các table từ database lên code để để quản lý và làm việc
    
    // Database First
    // - Làm việc với database có sẵn, setup 1 database
    // - Vô tạo Create Table, Create Database, Setup Field, setup các Relationship
    // - Sau đó, ở trên code xử dụng các Driver hoặc ORM để kết nối xuống Database
    // - Thằng này sử dụng khi nào: KHi mình có Database có sẵn và đã sử dụng trong rất nhiều năm rồi, những dự án Maintain
    
    // Code First: 
    // - Mình sẽ ko setup database thủ công bằng các query 
    // - Ko vô tạo Create Table, Create Database, Setup Field, setup các Relationship
    // - Mình design database bằng những class trên code luôn, trên code setup các Entity, các Field, các Relationship
    // - Sau đó, ánh xạ từ các class xuống các table trong Database
    // Vậy làm sao để ánh xạ được, từ các class trên code xuống Database: ORM: Object-Relational Mapping
    // Thằng này sử dụng khi: Dự án mới, hiện đại, nhiều công cụ hỗ trợ
    
    //Tuyệt đỉnh ORM của .NET: Entity Framework. Ko biết sử dụng và thành thục thằng  này thì mất 90% sức mạnh .NET
    
}