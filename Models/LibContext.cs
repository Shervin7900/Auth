using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lib.Models
{
    public class LibContext : IdentityDbContext
    {
        
        public LibContext(DbContextOptions options) : base(options)
        {
            
        }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<BookShelf> BookShelves { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<BookShelf>().HasData(bookShelves);
            modelBuilder.Entity<Shelf>().HasData(shelfs);
            // modelBuilder.Entity<User>().HasData(users);



              modelBuilder.Entity<Book>(e =>
              {
                  e.HasKey(m => m.Id)
                   .HasName("PK_Book");

                  e.Property(m => m.bookName)
                   .IsRequired()
                   .HasMaxLength(256);
              });

             


              modelBuilder.Entity<User>(e =>
              {
                  
                  e.Property(m => m.UserName)
                  .IsRequired()
                  .HasMaxLength(256);
              });

              modelBuilder.Entity<BookShelf>(e => {
                  e.HasKey(m => m.Id)
                   .HasName("PK_BookShelf");

                  e.Property(m => m.Name)
                  .IsRequired()
                  .HasMaxLength(256);
              });

              modelBuilder.Entity<Shelf>(e => {
                  e.HasKey(m => m.shelfId)
                   .HasName("PK_Shelf");

                  e.Property(m => m.shelfName)
                  .IsRequired()
                  .HasMaxLength(256);
              });


            /* modelBuilder.Entity<Shelf>()
                .Ignore("Users");*/
            /*modelBuilder.Entity<Shelf>()
                .Ignore("User");*//*

            modelBuilder.Entity<Shelf>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Shelfs)
                .HasForeignKey(x => x.UserId)
                ;*/
            /*modelBuilder.Entity<User>()
                .HasMany(x => x.Books)
                .WithMany(x => x.Users);*/

            /*modelBuilder.Entity<Shelf>()
                .HasMany(x => x.Book)
                .WithOne(x => x.Shelf)
                .HasForeignKey("ShelfForeignKey");*/
            /*modelBuilder.Entity<User>()
                .Ignore("Shelf");*/
            /* modelBuilder.Entity<User>()
                 .Ignore("Shelfs");*/
            /* modelBuilder.Entity<Shelf>()
                 .Ignore(x => x.Users);*/
            /*modelBuilder.Entity<User>()
                .HasNoKey(); */


            /* modelBuilder.Entity<Shelf>()
                .Property<int>("BookForeignKey");*/

            /*modelBuilder.Entity<Book>()
                .HasOne(x => x.Shelf)
                .WithMany(x => x.Book)
                .HasForeignKey("BookForeignKey");*/

            /*modelBuilder.Entity<Book>()
                  .Navigation(b => b.Shelf)
                  .UsePropertyAccessMode(PropertyAccessMode.Property);*/





            modelBuilder.Entity<User>().
               ToTable("Users");
            modelBuilder.Entity<Shelf>().
               ToTable("Shelf");
            modelBuilder.Entity<BookShelf>().
               ToTable("Bookshelf");
            modelBuilder.Entity<Book>().
               ToTable("Book");




          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .;Database = Library1;Trusted_Connection = true");
        }


        public static List<Book> books = new List<Book>()
        {
            new Book(){Id = 1 , bookName = "book1"},
            new Book(){Id = 2 , bookName = "book2"},
            new Book(){Id = 3 , bookName = "book3"},
            new Book(){Id = 4 , bookName = "book4"},
            new Book(){Id = 5 , bookName = "book5"}
        };
        public static List<BookShelf> bookShelves = new List<BookShelf>()
        {
            new BookShelf(){ Id=1 , Name ="Bookshelf1" , shelfid = 1, Userid = 1},
            new BookShelf(){ Id=2 , Name ="Bookshelf2" , shelfid = 1, Userid = 2},
            new BookShelf(){ Id=3 ,Name ="Bookshelf3" , shelfid = 2, Userid = 2},
            new BookShelf(){ Id=4 ,Name ="Bookshelf4" , shelfid = 3, Userid = 3},
            new BookShelf(){ Id=5 , Name ="Bookshelf5" , shelfid = 3, Userid = 4},
            new BookShelf(){ Id=6 ,Name ="Bookshelf6" , shelfid = 4, Userid = 5},
            new BookShelf(){ Id=7 , Name ="Bookshelf7" , shelfid = 5, Userid = 1}
        };
        public static List<Shelf> shelfs = new List<Shelf>()
        {
            new Shelf(){ shelfId = 1 , shelfName = "shelf1" , UserId = 1 , books = "book1" , BookStatus = true },
            new Shelf(){ shelfId = 2 , shelfName = "shelf2" , UserId = 2 , books = "book2" , BookStatus = false },
            new Shelf(){ shelfId = 3 , shelfName = "shelf3" , UserId = 3 , books = "book3" , BookStatus = false },
            new Shelf(){ shelfId = 4 , shelfName = "shelf4" , UserId = 1 , books = "book4" , BookStatus = true },
            new Shelf(){ shelfId = 5 , shelfName = "shelf5" , UserId = 2 , books = "book5" , BookStatus = true },
            new Shelf(){ shelfId = 6 , shelfName = "shelf6"  , UserId = 5 , books = "book6"  , BookStatus = true }
        };
        public static List<User> users = new List<User>()
        {
            new User(){UserId = 1 , UserName = "user1"},
            new User(){UserId = 2 , UserName = "user2"},
            new User(){UserId = 3 , UserName = "user3"},
            new User(){UserId = 4 , UserName = "user4"},
            new User(){UserId = 5 , UserName = "user5"}
        };

    }
}
