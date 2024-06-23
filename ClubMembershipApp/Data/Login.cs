using ClubMembershipApp.DTOs;
using ClubMembershipApp.Models;

namespace ClubMembershipApp.Data
{
    public class Login : ILogin
    {
        public User? ExecutLogin(string email, string password)
        {
            using(var db = new ClubMembershipDbContext())
            {
                UserDTO? checkUserDTO = db.UsersDTO
                    .FirstOrDefault(u => u.Email.ToLower() == email.ToLower() && u.Password == password);

                if(checkUserDTO is not null)
                {
                    return MapUserDTOToUser(checkUserDTO);
                }
                else
                {
                    return null;
                }
            }
        }

        private User MapUserDTOToUser(UserDTO userDTO)
        {
            return new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                PhoneNumber = userDTO.PhoneNumber,
                Address = userDTO.Address,
                City = userDTO.City,
                DateOfBirth = userDTO.DateOfBirth
            };
        }
    }
}
