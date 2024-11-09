using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Project.Models.DTO;
namespace Project.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public bool IsDraft { get; set; } = true;
        public int CustomerId { get; set; }
        public Customer Customer;
        [JsonIgnore]
        public List<Card> Presents { get; set; }
    }
}
