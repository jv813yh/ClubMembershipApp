using ClubMembershipApp.Data;
using ClubMembershipApp.FieldValidators;
using ClubMembershipApp.View;

namespace ClubMembershipApp.Views
{
    public class MainView : IView
    {
        public IFieldValidator FieldValidator 
            => null;

        private IView _registerView;
        private IView _loginView;

        public MainView(IView registerView, IView loginView)
        {
            _registerView = registerView;
            _loginView = loginView;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            Console.WriteLine("Please press 'l' if you want to login or if you want to register, press 'r'");

            ConsoleKey input = Console.ReadKey().Key;

            switch(input)
            {
                case ConsoleKey.L:
                    _loginView.RunView();
                    break;
                case ConsoleKey.R:
                    _registerView.RunView();
                    _loginView.RunView();

                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Goodbye");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
