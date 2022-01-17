using Lib.Models;

namespace Lib
{
    public class Seeder
    {
        protected LibContext libContext { get; set; }
        public Seeder(LibContext lib)
        {
            libContext = lib;
        }
        public List<Book> Seedbook()
        {
             List<Book> books = new List<Book>()
             {
                new Book(){Id = 1 , bookName = "book1"},
                new Book(){Id = 2 , bookName = "book2"},
                new Book(){Id = 3 , bookName = "book3"},
                new Book(){Id = 4 , bookName = "book4"},
                new Book(){Id = 5 , bookName = "book5"}
             };
             var a = libContext.Add(books);
             return a.Entity;
        }
        public List<BookShelf> SeedBookShelfs()
        {
            List<BookShelf> bookShelves = new List<BookShelf>(){
            new BookShelf(){ Id=1 , Name ="Bookshelf1" , shelfid = 1, Userid = 1},
            new BookShelf(){ Id=2 , Name ="Bookshelf2" , shelfid = 1, Userid = 2},
            new BookShelf(){ Id=3 ,Name ="Bookshelf3" , shelfid = 2, Userid = 2},
            new BookShelf(){ Id=4 ,Name ="Bookshelf4" , shelfid = 3, Userid = 3},
            new BookShelf(){ Id=5 , Name ="Bookshelf5" , shelfid = 3, Userid = 4},
            new BookShelf(){ Id=6 ,Name ="Bookshelf6" , shelfid = 4, Userid = 5},
            new BookShelf(){ Id=7 , Name ="Bookshelf7" , shelfid = 5, Userid = 1}
            };
            var a = libContext.Add(bookShelves);
            return a.Entity;
        }

        public List<User> SeedUser()
        {
            List<User> users = new List<User>()
            {
            new User(){UserId = 1 , UserName = "user1"},
            new User(){UserId = 2 , UserName = "user2"},
            new User(){UserId = 3 , UserName = "user3"},
            new User(){UserId = 4 , UserName = "user4"},
            new User(){UserId = 5 , UserName = "user5"}
            };
            var a = libContext.Add(users);
            return a.Entity;
        }

        public List<Shelf> SeedShelf()
        {
             List<Shelf> shelfs = new List<Shelf>()
             {
                new Shelf(){ shelfId = 1 , shelfName = "shelf1" , UserId = 1 , books = "book1" , BookStatus = true },
                new Shelf(){ shelfId = 2 , shelfName = "shelf2" , UserId = 2 , books = "book2" , BookStatus = false },
                new Shelf(){ shelfId = 3 , shelfName = "shelf3" , UserId = 3 , books = "book3" , BookStatus = false },
                new Shelf(){ shelfId = 4 , shelfName = "shelf4" , UserId = 1 , books = "book4" , BookStatus = true },
                new Shelf(){ shelfId = 5 , shelfName = "shelf5" , UserId = 2 , books = "book5" , BookStatus = true },
                new Shelf(){ shelfId = 6 , shelfName = "shelf6"  , UserId = 5 , books = "book6"  , BookStatus = true }
             };
             var a = libContext.Add(shelfs);
             return a.Entity;
        }
    }
}
