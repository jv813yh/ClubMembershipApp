using ClubMembershipApp.Data;
using ClubMembershipApp.FieldValidators;
using ClubMembershipApp.View;
using static ClubMembershipApp.FieldValidators.FieldConstants;

namespace ClubMembershipApp.Views
{
    public class UserRegistrationView : IView
    {
        IFieldValidator _fieldValidator = null;
        IRegister _register = null;

        public IFieldValidator FieldValidator 
        { 
            get => _fieldValidator; 
        }

        public UserRegistrationView(IRegister regiser, IFieldValidator fieldValidator)
        {
            _fieldValidator = fieldValidator;
            _register = regiser;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteRegistrationHeading();

            _fieldValidator.FieldArray[(int)UserRegistrationFields.Email] = GetInputFromUser(UserRegistrationFields.Email, "Enter your email:");
            _fieldValidator.FieldArray[(int)UserRegistrationFields.Name] = GetInputFromUser(UserRegistrationFields.Name, "Enter your name:");
            _fieldValidator.FieldArray[(int)UserRegistrationFields.Password] = GetInputFromUser(UserRegistrationFields.Password, "Enter your password:");
            _fieldValidator.FieldArray[(int)UserRegistrationFields.ConfirmPassword] = GetInputFromUser(UserRegistrationFields.ConfirmPassword, "Please, confirm password:");
            _fieldValidator.FieldArray[(int)UserRegistrationFields.Address] = GetInputFromUser(UserRegistrationFields.Address, "Enter your address:");
            _fieldValidator.FieldArray[(int)UserRegistrationFields.City] = GetInputFromUser(UserRegistrationFields.City, "Enter your city:");
            _fieldValidator.FieldArray[(int)UserRegistrationFields.DateOfBirth] = GetInputFromUser(UserRegistrationFields.DateOfBirth, "Enter your date of birth:");
            _fieldValidator.FieldArray[(int)UserRegistrationFields.PhoneNumber] = GetInputFromUser(UserRegistrationFields.PhoneNumber, "Enter your phone number:");

            Register();
        }

        private void Register()
        {
            _register.Register(_fieldValidator.FieldArray);

            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine("Registration successful!");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
        }

        private string GetInputFromUser(UserRegistrationFields field, string promptText)
        {
            string fieldValue = "";

            do
            {
                Console.WriteLine(promptText);
                fieldValue = Console.ReadLine();
            } 
            while(!FieldValid(field, fieldValue));


            return fieldValue;
        }

        private bool FieldValid(UserRegistrationFields field, string fieldValue)
        {
            if(_fieldValidator.FieldValidatorDelegates((int)field, fieldValue, _fieldValidator.FieldArray, out string fieldInvalidMessage))
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine(fieldInvalidMessage);
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);

                return false;
            }

            return true;
        }
    }
}
