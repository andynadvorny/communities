using System.ComponentModel.DataAnnotations;

namespace Communities.Models
{
    public class Community
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Max length of 30 characters"), MinLength(3)]
        public string Name { get; set; }
        [Display(Name = "Cover Image URL")]
        [Url]
        public string Cover { get; set; }
        public string Description { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Owner")]
        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public Community() { }
        public Community(int id, string name, string cover, string description, Category category, User owner)
        {
            Id = id;
            Name = name;
            Cover = cover;
            Description = description;
            Category = category;
            Owner = owner;
        }
    }
}
