using ClubMembershipApp.FieldValidators;
using ClubMembershipApp.Models;
using ClubMembershipApp.View;

namespace ClubMembershipApp.Views
{
    public class WelcomeUserView : IView
    {
        public IFieldValidator FieldValidator 
            => null;

        private User _user;

        public WelcomeUserView(User user)
        {
            _user = user;
        }

        public void RunView()
        {
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"Welcome, {_user.Name}");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
        }
    }
}
