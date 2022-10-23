using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplicationGiorgia.Models
{
    public class Author
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name="Author")]
        public string FullName { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
