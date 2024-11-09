using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; } //המחיר שעלו הכרטיסים

        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }
        public int PurchaseId { get; set; }
  
        
        [ForeignKey("PresentID")]
        public virtual Present Present { get; set; }
        public int PresentID { get; set; }

    }
}
