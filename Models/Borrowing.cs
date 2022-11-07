using System.ComponentModel.DataAnnotations;

namespace WebApplicationGiorgia.Models
{
    public class Borrowing
    {
        public int ID { get; set; }
        
        public int? MemberID { get; set; }
        
        public Member? Member { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        public int? BookID { get; set; }
        
        public Book? Book { get; set; }
    }
}
