using Microsoft.EntityFrameworkCore;
using TetPee.Repository.Entity;

namespace TetPee.Repository;

public class AppDbContext : DbContext
{
    public static Guid UserId1 = Guid.NewGuid();
    public static Guid UserId2 = Guid.NewGuid();
    public static Guid CategoryParentId1 = Guid.NewGuid();
    public static Guid CategoryParentId2 = Guid.NewGuid();
    
    public static Guid SellerId1 = Guid.NewGuid();  
    public static Guid SellerId2 = Guid.NewGuid();  

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
        
            List<User> users = new List<User>()
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
                }
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
        
        // ==================== Seller Configuration ====================
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
        
            var sellers = new List<Seller>()
            {
                new()
                {
                    Id = SellerId1,
                    TaxCode = "TAXCODE123",
                    CompanyName = "ABC Company",
                    CompanyAddress = "123 Main St, Cityville",
                    UserId = UserId1
                },
                new()
                {
                    Id = SellerId2,
                    TaxCode = "TAXCODE123",
                    CompanyName = "ABC Company",
                    CompanyAddress = "123 Main St, Cityville2",
                    UserId = UserId2
                },
            };
            
            builder.HasData(sellers);
        });
        
        // ==================== Category Configuration ====================
        modelBuilder.Entity<Category>(builder =>
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            var categories = new List<Category>()
            {
                new()
                {
                    Id = CategoryParentId1,
                    Name = "Áo",
                },
                new()
                {
                    Id = CategoryParentId2,
                    Name = "Quần",
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
                },
            };
        
            for (int i = 0; i < 1000; i++)
            {
                if (i % 2 == 0)
                {
                    var newCategory = new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Áo" + i,
                        ParentId = CategoryParentId1
                    };
                    categories.Add(newCategory);
                }
                else
                {
                    var newCategory = new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Quần" + i,
                        ParentId = CategoryParentId2
                    };
                    categories.Add(newCategory);
                }
            }
        
            builder.HasData(categories);
            // // IsVerify - default false
            // builder.Property(u => u.IsVerify)
            //     .HasDefaultValue(false);
            //
            // // VerifyCode
            // builder.Property(u => u.VerifyCode)
            //     .IsRequired();
            //
            // // DateOfBirth - nullable, max 20 characters
            // builder.Property(u => u.DateOfBirth)
            //     .HasMaxLength(20);
            //
            // // IsDeleted (Soft Delete) - default false
            // builder.Property(u => u.IsDeleted)
            //     .HasDefaultValue(false);
            //
            // // CreatedAt - required
            // builder.Property(u => u.CreatedAt)
            //     .IsRequired();
            
            // // CreatedAt - required
            // builder.Property(u => u.CreatedAt)
            //     .IsRequired();
            //
            // // UpdatedAt - nullable
            // builder.Property(u => u.UpdatedAt);
            //
            // // Relationship: User has one Seller (one-to-one)
            //  builder.HasOne(u => u.Seller)
            //                 .WithOne(s => s.User)
            //                 .HasForeignKey<Seller>(s => s.UserId)
            //                 .OnDelete(DeleteBehavior.Cascade);
            //
            // // DeleteBehavior.Cascade: Khi một User bị xóa, thì Seller liên quan cũng sẽ bị xóa theo.
            // // DeleteBehavior.Restrict: Ngăn chặn việc xóa User nếu có Seller liên quan tồn tại. (Thường dùng PK tồn tại)
            // // DeleteBehavior.NoAction: Không thực hiện hành động gì đặc biệt khi User bị xóa. (Gần giống Restrict, xử lý ở DB)
            // // DeleteBehavior.SetNull: Khi User bị xóa, thì UserId trong bảng Seller sẽ được đặt thành NULL.
            // // (Áp dụng khi trường FK cho phép NULL)
            //
            //
            // // Relationship: User has many Orders (one-to-many)
            // builder.HasMany(u => u.Orders)
            //                 .WithOne(o => o.User)
            //                 .HasForeignKey(o => o.UserId)
            //                 .OnDelete(DeleteBehavior.Cascade);
            //
            //
            // // Global query filter for soft delete
            // builder.HasQueryFilter(u => !u.IsDeleted);
        });
        
        // ==================== Order Configuration ====================
        modelBuilder.Entity<Order>(builder =>
        {
            builder.Property(o => o.Status)
                .IsRequired();
            
            builder.Property(o => o.Address)
                .IsRequired()
                .HasMaxLength(200);
            
            builder.Property(o => o.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            var orders = new List<Order>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    UserId = UserId1,
                    CreatedAt = DateTimeOffset.Now,
                    UpdatedAt = DateTimeOffset.Now,
                    Address = "123 Main St, Cityville",
                    Status = "Pending",
                    TotalAmount = 1000
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    UserId = UserId2,
                    CreatedAt = DateTimeOffset.Now,
                    UpdatedAt = DateTimeOffset.Now,
                    Address = "123 Main St, Cityville",
                    Status = "Pending",
                    TotalAmount = 1000
                },
            };
            builder.HasData(orders);
        });
        
        // ==================== Cart Configuration ====================
        modelBuilder.Entity<Cart>(builder =>
        {
            builder.HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId);

            var carts = new List<Cart>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    UserId = UserId1,
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    UserId = UserId2,
                }
            };
            builder.HasData(carts);
        });

        // ==================== Product Configuration ====================
        modelBuilder.Entity<Product>(builder =>
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);
            
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            
            builder.HasOne(p => p.Inventory)
                .WithOne(i => i.Product)
                .HasForeignKey<Inventory>(i => i.Id);

            var products = new List<Product>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Áo",
                    Description = "Áo dài",
                    Price = 1000,
                    SellerId = SellerId1,
                },
            };

            for (int i = 0; i < 1000; i++)
            {
                if (i % 2 == 0)
                {
                    var newProduct = new Product()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Áo" + i,
                        Description = "Áo dài" + i,
                        Price = 1000,
                        SellerId = SellerId1
                    };
                    products.Add(newProduct);
                }
                else
                {
                    var newProduct = new Product()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Áo" + i,
                        Description = "Quần dài" + i,
                        Price = 2000,
                        SellerId = SellerId2
                    };
                    products.Add(newProduct); 
                }
            }
            builder.HasData(products);
        });

    }
}
//xong catogory với có 100 trong db

//tạo 1000 dòng cho tất cả các table