using System.Text.RegularExpressions;

namespace FieldValidationAPI
{
    public delegate bool ReguiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int minValue, int maxValue);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDate);
    public delegate bool PatternMatchDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsDel(string fieldVal1, string fieldValCompare);

    public class CommonFieldValidatorFunctions
    {
        private static ReguiredValidDel _reguiredValidDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchDel _patternMatchValidDel = null;
        private static CompareFieldsDel _comapareFieldDel = null;


        public static ReguiredValidDel GetReguiredValidDel
        {
            get
            {
                if(_reguiredValidDel == null)
                {
                    _reguiredValidDel = new ReguiredValidDel(RequiredFieldValidator);
                }

                return _reguiredValidDel;
            }
        }

        public static StringLengthValidDel GetStringLengthValidDel
        {
            get
            {
                if(_stringLengthValidDel == null)
                {
                    _stringLengthValidDel = new StringLengthValidDel(StringLengthValidator);
                }

                return _stringLengthValidDel;
            }
        }

        public static DateValidDel GetDateValidDel
        {
            get
            {
                if(_dateValidDel == null)
                {
                    _dateValidDel = new DateValidDel(DateValidator);
                }

                return _dateValidDel;
            }
        }

        public static PatternMatchDel GetPatternMatchDel
        {
            get
            {
                if(_patternMatchValidDel == null)
                {
                    _patternMatchValidDel = new PatternMatchDel(FieldPatternValid);
                }

                return _patternMatchValidDel;
            }
        }


        public static CompareFieldsDel GetCompareFieldsDel
        {
            get
            {
                if(_comapareFieldDel == null)
                {
                    _comapareFieldDel = new CompareFieldsDel(FieldComparisonValid);
                }

                return _comapareFieldDel;
            }
        }


        private static bool RequiredFieldValidator(string fieldVal)
        {
            if(string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }

            return false;
        }

        private static bool StringLengthValidator(string fieldVal, int minValue, int maxValue)
        {
            if(fieldVal.Length >= minValue && fieldVal.Length <= maxValue)
            {
                return true;
            }

            return false;
        }

        private static bool DateValidator(string fieldVal, out DateTime validDate)
        {
            if(DateTime.TryParse(fieldVal, out validDate))
            {
                return true;
            }

            return false;
        }

        private static bool FieldPatternValid(string fieldVal, string regularExpressionPattern)
        {
            if(Regex.IsMatch(fieldVal, regularExpressionPattern))
            {
                return true;
            }

            return false;
        }

        private static bool FieldComparisonValid(string fieldVal1, string fieldVal2)
        {
            if(string.Equals(fieldVal1.Trim(), fieldVal2.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
