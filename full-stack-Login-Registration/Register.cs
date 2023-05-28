namespace full_stack_Login_Registration
{
    public class Register
    {
        private readonly User _user;
        private readonly DbOperation _dbOperation;

        public Register(User user, DbOperation dbOperation)
        {
            _user = user;
            _dbOperation = dbOperation;
        }

        public User? ConfirmAndCreateUser()
        {
            if (BlankInputs() || ConfirmedPasswordIsNotEqualToPassword()) return null; 
            _dbOperation.CreateUserInDb(_user);
            return _user;
        }

        private bool BlankInputs()
        {
            return string.IsNullOrWhiteSpace(_user.Username) ? true :
                   string.IsNullOrWhiteSpace(_user.Password) ? true :
                   string.IsNullOrWhiteSpace(_user.ConfirmPassword) ? true : false;
        }

        private bool ConfirmedPasswordIsNotEqualToPassword()
        {
            return _user.Password != _user.ConfirmPassword;
        }
    }
}