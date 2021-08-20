using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        
        public string Email { get; set; }
        [Required]

        public string Subject { get; set; }
        [Required]
        [MaxLength(ErrorMessage ="Message length cannot be more than 250")]
        public string Message { get; set; }
    }
}
