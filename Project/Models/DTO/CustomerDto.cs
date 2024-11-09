using System.ComponentModel.DataAnnotations;

namespace Project.Models.DTO
{
    public class CustomerDto
    {
        
        public string UserName { get; set; }
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        public string Password { get; set; }

    }
}
