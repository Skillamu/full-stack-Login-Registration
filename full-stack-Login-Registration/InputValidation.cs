namespace full_stack_Login_Registration
{
    public class InputValidation // Maybe creating seperate classes input validation classes for register and login if this gets messy(?).
    {
        private User _user;

        public InputValidation(User user)
        {
            _user = user;
        }

        public bool HasValidInputsForRegistration()
        {
            return !ContainsUnfilledData() && ConfirmedPasswordIsEqualToPassword();
        }

        private bool ContainsUnfilledData()
        {
            return string.IsNullOrWhiteSpace(_user.Username) ? true :
                   string.IsNullOrWhiteSpace(_user.Password) ? true :
                   string.IsNullOrWhiteSpace(_user.ConfirmPassword) ? true : false;
        }

        private bool ConfirmedPasswordIsEqualToPassword()
        {
            return _user.Password == _user.ConfirmPassword;
        }
    }
}