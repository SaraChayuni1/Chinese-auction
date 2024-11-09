using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Project.Models.DTO;

namespace Project.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MinLength(2)]
        public string UserName { get; set; }
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Mail { get; set; }

        public int Role { get; set; }//Manager=1
                                     //cust=2
        public string Password { get; set; }
        [JsonIgnore]
        public List<Purchase> Purchases { get; set; } //מוצרים בסל בזמן הטיוטה לפני סגירת הזמנה
    }
}
