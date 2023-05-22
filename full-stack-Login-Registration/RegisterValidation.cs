namespace full_stack_Login_Registration
{
    public class RegisterValidation
    {
        private User _user;

        public RegisterValidation(User user)
        {
            _user = user;
        }

        public bool HasValidInputs()
        {
            return !ContainsUnfilledInputs() && ConfirmedPasswordIsEqualToPassword();
        }

        private bool ContainsUnfilledInputs()
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
