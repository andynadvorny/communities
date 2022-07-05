namespace Communities.Models.ViewModels
{
    public class UserFormViewModel
    {
        public Community User { get; set; }
        public ICollection<Community> CommunityList { get; set; }
    }
}
