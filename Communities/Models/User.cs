using System.ComponentModel.DataAnnotations;

namespace Communities.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "User Picture URL")]
        [Url]
        public string Avatar { get; set; }
        public string Bio { get; set; }
        public ICollection<Community> Communities { get; set; } = new List<Community>();

        public void AddCommunity(Community community)
        {
            Communities.Add(community);
        }

        public void RemoveCommunity(Community community)
        {
            Communities.Remove(community);
        }

        public string ListCommunities()
        {
            return Communities.ToString();
        }

        public User() { }
        public User(int id, string name, string email, string avatar, string bio)
        {
            Id = id;
            Name = name;
            Email = email;
            Avatar = avatar;
            Bio = bio;
        }
    }
}
