using Microsoft.EntityFrameworkCore;
using TetPee.Repository.Entity;

namespace TetPee.Repository;

public class AppDbContext : DbContext
{
    public static Guid UserId1 = Guid.NewGuid(); // Seller
    public static Guid UserId2 = Guid.NewGuid(); // User

    public static List<User> users;
    public static List<Seller> sellers;
    public static List<Cart> carts;
    public static List<Product> products;
    public static List<Inventory> inventories;
    public static List<Order> orders;
    public static List<OrderDetail> orderDetails;
    public static List<Storage> storages;
    public static List<ProductStorage> productStorages;
    public static List<Category> categories;
    public static List<ProductCategory> productCategories;

    // public static List<Guid> CategoryParentId;

    public static Guid SellerId1 = Guid.NewGuid();

    public static Guid CategoryParentId1 = Guid.NewGuid();
    public static Guid CategoryParentId2 = Guid.NewGuid();

    public static Guid ProductId1 = Guid.NewGuid();
    public static Guid ProductId2 = Guid.NewGuid();
    public static Guid ProductId3 = Guid.NewGuid();
    public static Guid ProductId4 = Guid.NewGuid();

    public static Guid OrderId1 = Guid.NewGuid();
    public static Guid OrderId2 = Guid.NewGuid();
    
    public static Guid StorageId1 = Guid.NewGuid();
    public static Guid StorageId2 = Guid.NewGuid();
    

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductStorage> ProductStorages { get; set; }
    public DbSet<Storage> Storages { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ==================== User Configuration ====================
        modelBuilder.Entity<User>(builder =>
        {
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            // LastName - required, max 100 characters
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            // builder.Property(u => u.VerifyCode)
            //     .IsRequired();

            // ImageUrl - nullable, max 500 characters (URL)
            builder.Property(u => u.ImageUrl)
                .HasMaxLength(500);

            // PhoneNumber - nullable, max 20 characters
            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            // HashedPassword - required, max 500 characters
            builder.Property(u => u.HashedPassword)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValue("User");

            // Relationship: User has one Seller (one-to-one)
            builder.HasOne(u => u.Seller)
                .WithOne(s => s.User)
                .HasForeignKey<Seller>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // DeleteBehavior.Cascade: Khi một User bị xóa, thì Seller liên quan cũng sẽ bị xóa theo.
            // DeleteBehavior.Restrict: Ngăn chặn việc xóa một User nếu có Seller liên quan tồn tại.
            //(Tham chiếu tới PK tồn tại)
            // 1 Project còn Task thì không xoá được
            // DeleteBehavior.NoAction: Không thực hiện hành động gì đặc biệt khi User bị xóa. ( Gàn giống Restrict, xử lí ở DB)
            // DeleteBehavior.SetNull: Khi một User bị xóa, thì trường UserId trong bảng Seller sẽ được đặt thành NULL.
            //(Áp dụng khi trường FK cho phép NULL)
            
            users = new List<User>()
            {
                new()
                {
                    Id = UserId1,
                    Email = "tan182205@gmail.com",
                    FirstName = "Tan",
                    LastName = "Tran",
                    HashedPassword = "hashed_password_1",
                },
                new()
                {
                    Id = UserId2,
                    Email = "tan182206@gmail.com",
                    FirstName = "Tan",
                    LastName = "Tran",
                    HashedPassword = "hashed_password_1",
                },
                new()
                {
                    Id = new Guid("89a01d1e-11da-427b-b600-c0d9a2c03ca6"),
                    Email = "tan182207@gmail.com",
                    FirstName = "Tan",
                    LastName = "Tran",
                    HashedPassword = "hashed_password_1",
                },
            };

            for (int i = 0; i < 1000; i++)
            {
                var newUser = new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "tan" + i + "@gmail.com",
                    FirstName = "Tan" + i,
                    LastName = "Tran" + i,
                    HashedPassword = "hashed_password_" + i,
                };
                users.Add(newUser);
            }

            builder.HasData(users);
        });

        modelBuilder.Entity<Seller>(builder =>
        {
            builder.Property(s => s.TaxCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.CompanyName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.CompanyAddress)
                .IsRequired()
                .HasMaxLength(500);

            sellers = new List<Seller>();
            // {
            //     new()
            //     {
            //         Id = SellerId1,
            //         TaxCode = "TAXCODE123",
            //         CompanyName = "ABC Company",
            //         CompanyAddress = "123 Main St, Cityville",
            //         // UserId = 
            //         UserId = UserId1
            //     },
            //     new()
            //     {
            //         Id = Guid.NewGuid(),
            //         TaxCode = "TAXCODE123",
            //         CompanyName = "ABC Company",
            //         CompanyAddress = "123 Main St, Cityville",
            //         UserId = new Guid("89a01d1e-11da-427b-b600-c0d9a2c03ca6"),
            //     },
            // };
            
            for (int i = 0; i < users.Count; i++)
            {
                var newSeller = new Seller()
                {
                    Id = Guid.NewGuid(),
                    TaxCode = "TAXCODE" + i,
                    CompanyName = "ABC Company " + i,
                    CompanyAddress = "123 Main St",
                    UserId = users[i].Id
                };
                sellers.Add(newSeller);
            }
            builder.HasData(sellers);
        });

        modelBuilder.Entity<Category>(builder =>
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
        
            categories = new List<Category>()
            {
                new()
                {
                    Id = CategoryParentId1,
                    Name = "Áo",
                },
                new()
                {
                    Id = CategoryParentId2,
                    Name = "Quẩn",
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Áo thể thao",
                    ParentId = CategoryParentId1
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Áo ba lỗ",
                    ParentId = CategoryParentId1
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Quần Jeans",
                    ParentId = CategoryParentId2
                }
            };
            
            for (int i = 0; i < 1000; i++)
            {
                var newCategory = new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Quần Jeans" + i,
                    ParentId = CategoryParentId1
                };
                categories.Add(newCategory);
            }
        
            builder.HasData(categories);
        });
        
        modelBuilder.Entity<Product>(builder =>
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);
        
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);
        
            builder.Property(p => p.UrlImage)
                .IsRequired()
                .HasMaxLength(500);
        
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        
        
            products = new List<Product>();
            // {
            //     new Product()
            //     {
            //         Id = ProductId1,
            //         Name = "Áo Thun Nam",
            //         Description =
            //             "Áo thun nam chất liệu cotton cao cấp, thoáng mát, phù hợp cho mọi hoạt động hàng ngày.",
            //         UrlImage = "https://example.com/images/ao_thun_nam.jpg",
            //         Price = 199000m,
            //         SellerId = SellerId1
            //     },
            //     new Product()
            //     {
            //         Id = ProductId2,
            //         Name = "Quần Jeans Nữ",
            //         Description = "Quần jeans nữ dáng ôm, tôn dáng, chất liệu denim co giãn, phù hợp cho mọi dịp.",
            //         UrlImage = "https://example.com/images/quan_jeans_nu.jpg",
            //         Price = 399000m,
            //         SellerId = SellerId1
            //     },
            //     new Product()
            //     {
            //         Id = ProductId3,
            //         Name = "Áo Sơ Mi Nam",
            //         Description = "Áo sơ mi nam công sở, thiết kế hiện đại, chất liệu vải cao cấp, thoáng mát.",
            //         UrlImage = "https://example.com/images/ao_so_mi_nam.jpg",
            //         Price = 299000m,
            //         SellerId = SellerId1
            //     },
            //     new Product()
            //     {
            //         Id = ProductId4,
            //         Name = "Chân Váy Nữ",
            //         Description = "Chân váy nữ xòe, thiết kế trẻ trung, chất liệu vải mềm mại, phù hợp cho mọi dịp.",
            //         UrlImage = "https://example.com/images/chan_vay_nu.jpg",
            //         Price = 249000m,
            //         SellerId = SellerId1
            //     }
            // };
        
            for (int i = 0; i < 1000; i++)
            {
                var newProduct = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Quần Jeans Nữ" + i,
                    Description = "Quần jeans nữ dáng ôm, tôn dáng, chất liệu denim co giãn, phù hợp cho mọi dịp." + i,
                    UrlImage = "https://example.com/images/quan_jeans_nu.jpg",
                    Price = 399000m,
                    SellerId = sellers[i].Id
                };
                products.Add(newProduct);
            }
            builder.HasData(products);
        });
        
        modelBuilder.Entity<Order>(builder =>
        {
            orders = new List<Order>() { };
            // {
            //     new()
            //     {
            //         Id = OrderId1,
            //         UserId = UserId2,
            //         Address = "Bien Hoa, Dong Nai",
            //         TotalAmount = 100000m,
            //         Status = "Completed",
            //     },
            //     new()
            //     {
            //         Id = OrderId2,
            //         UserId = UserId2,
            //         Address = "Bien Hoa, Dong Nai",
            //         TotalAmount = 100000m,
            //         Status = "Completed",
            //     }
            // };
            for (int i = 0; i < 1000; i++)
            {
                var newOrder = new Order()
                {
                    Id = Guid.NewGuid(),
                    UserId = users[i].Id,
                    Address = "Bien Hoa, Dong Nai" + i,
                    TotalAmount = 100000m,
                    Status = "Completed",
                };
                orders.Add(newOrder);
            }
            
            builder.HasData(orders);
        });
        //
        modelBuilder.Entity<OrderDetail>(builder =>
        {
            orderDetails = new List<OrderDetail>() { };
            // {
            //     new OrderDetail()
            //     {
            //         Id = Guid.NewGuid(),
            //         OrderId = OrderId1,
            //         ProductId = ProductId1,
            //         Quantity = 2,
            //         UnitPrice = 199000m
            //     },
            //     new OrderDetail()
            //     {
            //         Id = Guid.NewGuid(),
            //         OrderId = OrderId1,
            //         ProductId = ProductId2,
            //         Quantity = 1,
            //         UnitPrice = 399000m
            //     },
            //     new OrderDetail()
            //     {
            //         Id = Guid.NewGuid(),
            //         OrderId = OrderId2,
            //         ProductId = ProductId3,
            //         Quantity = 1,
            //         UnitPrice = 299000m
            //     }
            // };
            for (int i = 0; i < 1000; i++)
            {
                var newOrderDetail = new OrderDetail()
                {
                    Id = Guid.NewGuid(),
                    OrderId = orders[i].Id,
                    ProductId = products[i].Id,
                    Quantity = i,
                    UnitPrice = 299000m + i,
                };
                orderDetails.Add(newOrderDetail);
            }
            
            builder.HasData(orderDetails);
        });
        
        modelBuilder.Entity<ProductCategory>(builder =>
        {
            productCategories = new List<ProductCategory>() { };
            // {
            //     new ProductCategory()
            //     {
            //         Id = Guid.NewGuid(),
            //         CategoryId = CategoryParentId1,
            //         ProductId = ProductId1,
            //     },
            //     new ProductCategory()
            //     {
            //         Id = Guid.NewGuid(),
            //         CategoryId = CategoryParentId2,
            //         ProductId = ProductId2,
            //     }
            // };
            for (int i = 0; i < 1000; i++)
            {
                var newProductCategory = new ProductCategory()
                {
                    Id = Guid.NewGuid(),
                    CategoryId = CategoryParentId2,
                    ProductId = products[i].Id,
                };
                productCategories.Add(newProductCategory);
            }
            builder.HasData(productCategories);
        });
        
        modelBuilder.Entity<Storage>(builder =>
        {
            storages = new List<Storage>()
            {
                new Storage()
                {
                    Id = StorageId1,
                    Price = 99999,
                    Type = "Export"
                },
                new Storage()
                {
                    Id = StorageId2,
                    Price = 3000,
                    Type = "Import"
                }
            };
            for (int i = 0; i < 1000; i++)
            {
                var newStorage = new Storage()
                {
                    Id = Guid.NewGuid(),
                    Price = 3000 + i,
                    Type = "Import" + i,
                };
                storages.Add(newStorage);
            }
            
            builder.HasData(storages);
        });
        
        modelBuilder.Entity<ProductStorage>(builder =>
        {
            productStorages = new List<ProductStorage>() { };
            // {
            //     new ProductStorage()
            //     {
            //         Id = Guid.NewGuid(),
            //         StorageId = StorageId1,
            //         ProductId = ProductId1,
            //     },
            //     new ProductStorage()
            //     {
            //         Id = Guid.NewGuid(),
            //         StorageId = StorageId2,
            //         ProductId = ProductId2,
            //     }
            // };
            for (int i = 0; i < 1000; i++)
            {
                var newProductStorage = new ProductStorage()
                {
                    Id = Guid.NewGuid(),
                    StorageId = storages[i].Id,
                    ProductId = products[i].Id,
                };
                productStorages.Add(newProductStorage);
            }
            builder.HasData(productStorages);
        });
        
        modelBuilder.Entity<Inventory>(builder =>
        {
            inventories = new List<Inventory>() { };
            // {
            //     new Inventory()
            //     {
            //         Id = Guid.NewGuid(),
            //         ProductId = ProductId1,
            //         TotalInStock = 12,
            //         TotalSell = 123
            //     },
            //     new Inventory()
            //     {
            //         Id = Guid.NewGuid(),
            //         ProductId = ProductId2,
            //         TotalInStock = 12,
            //         TotalSell = 123
            //     }
            // };
            for (int i = 0; i < products.Count; i++)
            {
                var newInventory = new Inventory()
                {
                    Id = Guid.NewGuid(),
                    ProductId = products[i].Id,
                    TotalInStock = i,
                    TotalSell = i
                };
                inventories.Add(newInventory);
            }
            builder.HasData(inventories);
        });
        
        modelBuilder.Entity<Cart>(builder =>
        {
            carts = new List<Cart>();
            // {
            //     new Cart()
            //     {
            //         Id = Guid.NewGuid(),
            //         UserId = UserId1,
            //     },
            //     new Cart()
            //     {
            //         Id = Guid.NewGuid(),
            //         UserId = UserId2,
            //     }
            // };


            for (int i = 0; i < users.Count; i++)
            {
                var newCart = new Cart()
                {
                    Id = Guid.NewGuid(),
                    UserId = users[i].Id,
                };
                carts.Add(newCart);
            }
            
            builder.HasData(carts);
        });
    }
}