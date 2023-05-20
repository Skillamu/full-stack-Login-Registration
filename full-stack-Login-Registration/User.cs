namespace full_stack_Login_Registration
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }
    }
}
