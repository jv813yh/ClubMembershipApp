using ClubMembershipApp.Models;

namespace ClubMembershipApp.Data
{
    public interface ILogin
    {
        User? ExecutLogin(string emailAddress, string password);
    }
}
