using ClubMembershipApp.Data;
using ClubMembershipApp.FieldValidators;
using ClubMembershipApp.View;
using ClubMembershipApp.Views;

namespace ClubMembershipApp
{
    public class Factory
    {
        public static IView GetMainViewObject()
        {
            ILogin login = new Login();
            IRegister register = new RegisterUser();

            IFieldValidator fieldValidator = new UserRegistrationValidator(register);
            fieldValidator.InitialiseValidatorDelegates();

            IView registerView = new UserRegistrationView(register, fieldValidator);
            IView loginView = new UserLoginView(login);

            IView mainView = new MainView(registerView, loginView);

            return mainView;
        }
    }
}
