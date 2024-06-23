using ClubMembershipApp.Data;
using ClubMembershipApp.FieldValidators;
using ClubMembershipApp.Models;
using ClubMembershipApp.View;

namespace ClubMembershipApp.Views
{
    public class UserLoginView : IView
    {
        private ILogin _login = null;
        public IFieldValidator FieldValidator 
            => null;

        private IView _welcomeUserView;

        public UserLoginView(ILogin login)
        {
            _login = login;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please enter your email address:");
            string email = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            
            User user = _login.ExecutLogin(email, password);

            if(user is not null)
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Success);
                Console.WriteLine("Login successful!");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);

                Console.WriteLine();
                _welcomeUserView = new WelcomeUserView(user);
                _welcomeUserView.RunView();
                Console.ReadKey();
            }
            else
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("Login failed. Please try again.");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            }
        }
    }
}
