using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Present
    {
        [Key]
        public int Id { get; set; }                        
        public string Name { get; set; }                   
        public Category Category { get; set; }             
        public int CategoryId { get; set; }                
        public Donor Donor { get; set; }                   
        public int DonorId { get; set; }                   
        public int Amount { get; set; }    //כמה יחידות יש לי ממתנה זאת             
        public int CustomerAcount { get; set; }  
        public string Winner { get; set; }

        public int Price { get; set; }//אם יש בעיה כנראה זה כאן
        //public IEnumerable<Customer> Customer { get; set; }
    }
}
