namespace Lib.Models
{
    public class Shelf
    {
        public int shelfId { get; set; }
        public string shelfName { get; set;}
        public int UserId { get; set; }
        public string books { get; set; }
        public bool BookStatus { get; set; }
        /*public List<User> Users { get; set; }
        public List<Book> Book { get; set; }
        public List<Shelf> Shelfs { get; set; }*/
       
    }
}
