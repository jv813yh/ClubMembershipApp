using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubMembershipApp.DTOs
{
    public class UserDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity) ,Key]
        public Guid ID { get; set; }

        public string Name { get; set; } 

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public DateTime DateOfBirth { get; set; } 
    }
}
