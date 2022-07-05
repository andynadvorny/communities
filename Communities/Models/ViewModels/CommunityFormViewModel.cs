namespace Communities.Models.ViewModels
{
    public class CommunityFormViewModel
    {
        public Community Community { get; set; }
        public ICollection<Category> CategoryList { get; set; }
        public ICollection<User> UserList { get; set; }
    }
}
