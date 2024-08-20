namespace FlashCardAPI.Model
{
    public class Admin : User
    {
        public Admin() { }
        public Admin(Guid id, string username, string password) : base(id, username, password)
        {
        }
    }
}
