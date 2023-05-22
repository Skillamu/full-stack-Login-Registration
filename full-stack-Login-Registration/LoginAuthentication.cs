using System.Data.SqlClient;

namespace full_stack_Login_Registration
{
    public class LoginAuthentication
    {
        private DbOperation _dbOperation;
        private User _user;

        public LoginAuthentication(DbOperation dbOperation, User user)
        {
            _dbOperation = dbOperation;
            _user = user;
        }

        public bool WasSuccessful()
        {
            var userFromDb = _dbOperation.FindUser(_user);
            return userFromDb is not null ? true : false;
        }
    }
}