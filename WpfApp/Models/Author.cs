namespace WpfApp.Models
{
    public class Author : IEntity
    {
        public Author(string genre, string name)
        {
            Genre = genre;
            Name = name;
        }

        public string Genre { get; }
        public string Name { get; }
    }
}
