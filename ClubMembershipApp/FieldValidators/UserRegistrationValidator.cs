using ClubMembershipApp.Data;
using FieldValidationAPI;
using static ClubMembershipApp.FieldValidators.FieldConstants;

namespace ClubMembershipApp.FieldValidators
{
    public class UserRegistrationValidator : IFieldValidator
    {
        const int nameMinLength = 3;
        const int nameMaxLength = 50;


        FieldValidatorDel _fieldValidatorDel = null;
        StringLengthValidDel _stringLengthValidDel = null;
        ReguiredValidDel _reguiredValidDel = null;
        PatternMatchDel _patternMatchDel = null;
        CompareFieldsDel _compareFieldsDel = null;


        delegate bool EmailExistDel(string email);
        EmailExistDel _emailExistsDel = null;
        IRegister _register = null;


        string[] _fieldArray = null;

        public string[] FieldArray
        {
            get
            {
                if (_fieldArray == null)
                {
                    _fieldArray = new string[Enum.GetValues(typeof(UserRegistrationFields)).Length];
                }

                    return _fieldArray;
            }
        }

        public FieldValidatorDel FieldValidatorDelegates 
            => _fieldValidatorDel;

        public UserRegistrationValidator(IRegister register)
        {
            _register = register;
        }

        public void InitialiseValidatorDelegates()
        {
            _fieldValidatorDel = new FieldValidatorDel(ValidFieldFunc);

            _emailExistsDel = new EmailExistDel(_register.EmailExists);

            _reguiredValidDel = CommonFieldValidatorFunctions.GetReguiredValidDel;
            _stringLengthValidDel = CommonFieldValidatorFunctions.GetStringLengthValidDel;
            _patternMatchDel = CommonFieldValidatorFunctions.GetPatternMatchDel;
            _compareFieldsDel = CommonFieldValidatorFunctions.GetCompareFieldsDel;
        }

        private bool ValidFieldFunc(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {    
            fieldInvalidMessage = string.Empty;

            UserRegistrationFields userReigstrationField = (UserRegistrationFields)fieldIndex;

            switch(userReigstrationField)
            {
                case UserRegistrationFields.Name:
                    if(_reguiredValidDel(fieldValue))
                    {
                        fieldInvalidMessage = "Name is required";
                    }
                    else if(!_stringLengthValidDel(fieldValue, nameMinLength, nameMaxLength))
                    {
                        fieldInvalidMessage = $"Name must be between {nameMinLength} and {nameMaxLength} characters";
                    }
                    break;

                case UserRegistrationFields.Email:
                    if(_reguiredValidDel(fieldValue))
                    {
                        fieldInvalidMessage = "Email is required";
                    }
                    else if(!_patternMatchDel(fieldValue, CommonRegularExpressionValidationPatterns.Email_Address_RegEx_Pattern))
                    {
                        fieldInvalidMessage = "Email is invalid";
                    }
                    else if(_emailExistsDel(fieldValue))
                    {
                        fieldInvalidMessage = "Email already exists";
                    }
                    break;

                case UserRegistrationFields.Password:
                    if(_reguiredValidDel(fieldValue))
                    {
                        fieldInvalidMessage = "Password is required";
                    }
                    else if(!_stringLengthValidDel(fieldValue, 6, 10))
                    {
                        fieldInvalidMessage = "Password must be between 6 and 10 characters";
                    }
                    else if(!_patternMatchDel(fieldValue, CommonRegularExpressionValidationPatterns.Strong_Password_RegEx_Pattern))
                    {
                        fieldInvalidMessage = "Password must contain at least 1 small-case letter, 1 capital letter and 1 special character";
                    }
                    break;

                case UserRegistrationFields.ConfirmPassword:
                    if(_reguiredValidDel(fieldValue))
                    {
                        fieldInvalidMessage = "Confirm password is required";
                    }
                    else if(!_compareFieldsDel(fieldValue, fieldArray[(int)UserRegistrationFields.Password]))
                    {
                        fieldInvalidMessage = "Password and confirm password do not match";
                    }
                    break;

                case UserRegistrationFields.DateOfBirth:
                    if(_reguiredValidDel(fieldValue))
                    {
                        fieldInvalidMessage = "Date of birth is required";
                    }
                    else if(!_patternMatchDel(fieldValue, CommonRegularExpressionValidationPatterns.Uk_Valid_Date_RegEx_Pattern))
                    {
                        fieldInvalidMessage = "Date of birth is invalid, example: DD/MM/YYYY";
                    }
                    break;
                case UserRegistrationFields.Address:
                    if(_reguiredValidDel(fieldValue))
                    {
                        fieldInvalidMessage = "Address is required";
                    }
                    break;
                case UserRegistrationFields.City:
                    if(_reguiredValidDel(fieldValue))
                    {
                        fieldInvalidMessage = "City is required";
                    }
                    break;
                case UserRegistrationFields.PhoneNumber:
                    if (_reguiredValidDel(fieldValue))
                    {
                        fieldInvalidMessage = "Phone number is required";
                    }
                    else if (!_patternMatchDel(fieldValue, CommonRegularExpressionValidationPatterns.Uk_PhoneNumber_RegEx_Pattern))
                    {
                        fieldInvalidMessage = "Phone number is invalid, example: +44 (77) 1234 5678.";
                    }
                    break;

                default:
                    throw new ArgumentException("Invalid field index");
            }

            return (string.IsNullOrEmpty(fieldInvalidMessage) ? false : true);
        }
    }
}
