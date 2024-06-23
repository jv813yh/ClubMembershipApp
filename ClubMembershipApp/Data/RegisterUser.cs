using ClubMembershipApp.DTOs;
using ClubMembershipApp.FieldValidators;

namespace ClubMembershipApp.Data
{
    public class RegisterUser : IRegister
    {
        public bool EmailExists(string emailAddress)
        {
            bool emailExists = false;

            using (var db = new ClubMembershipDbContext())
            {
                emailExists = db.UsersDTO
                    .Any(u => u.Email == emailAddress);
            }

            return emailExists;
        }

        public bool Register(string[] fields)
        {
            using(var db = new ClubMembershipDbContext())
            {
                var userDTO = new UserDTO
                {
                    Name = fields[(int)FieldConstants.UserRegistrationFields.Name],
                    Email = fields[(int)FieldConstants.UserRegistrationFields.Email],
                    Password = fields[(int)FieldConstants.UserRegistrationFields.Password],
                    PhoneNumber = fields[(int)FieldConstants.UserRegistrationFields.PhoneNumber],
                    Address = fields[(int)FieldConstants.UserRegistrationFields.Address],
                    City = fields[(int)FieldConstants.UserRegistrationFields.City],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationFields.DateOfBirth])
                };

                db.UsersDTO.Add(userDTO);

                db.SaveChanges();
            }

            return true;
        }
    }
}
