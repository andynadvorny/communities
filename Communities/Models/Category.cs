using System.ComponentModel.DataAnnotations;

namespace Communities.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Max length of 20 characters"), MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Community> Communities { get; set; } = new List<Community>();

        public void AddCommunity(Community community)
        {
            Communities.Add(community);
        }

        public void RemoveCommunity(Community community)
        {
            Communities.Remove(community);
        }

        public Category() { }
        public Category(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
