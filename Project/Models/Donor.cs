using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using Project.Models.DTO;

namespace Project.Models
{
    public class Donor
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        //public IEnumerable<Present> Present { get; set; }

    }
}
