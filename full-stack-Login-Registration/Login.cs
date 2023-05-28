namespace full_stack_Login_Registration
{
    public class Login
    {
        private readonly User _user;
        private readonly DbOperation _dbOperation;

        public Login(User user, DbOperation dbOperation)
        {
            _user = user;
            _dbOperation = dbOperation;
        }

        public User? AuthenticateUser()
        {
            var userFromDb = _dbOperation.GetUserInDb(_user);
            return userFromDb is not null ? userFromDb : null;
        }
    }
}