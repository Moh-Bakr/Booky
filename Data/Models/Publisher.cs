using System.Collections.Generic;

namespace Booky.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //one to many prop 
        public List<Book> Books { get; set; }
    }
}