using System.ComponentModel.DataAnnotations;

namespace Homework_1.Models
{
    public class PutCustomerModel
    {
        [Required, MinLength(2), MaxLength(10)]
        public string CustomerName { get; set; }

        [Required, MinLength(2), MaxLength(15)]
        public string CustomerLastName { get; set; }


        [Required, EmailAddress(ErrorMessage = "Mail address ist not valid")]
        public string CustomerMail { get; set; }

        [Required, Phone(ErrorMessage = "Mail address ist not valid")]
        public string CustomerPhone { get; set; }

        [Required]
        public bool CustomerStatus { get; set; }
    }
}
