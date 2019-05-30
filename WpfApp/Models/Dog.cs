namespace WpfApp.Models
{
    public class Dog : IEntity
    {
        public Dog(string breed, string name)
        {
            Breed = breed;
            Name = name;
        }

        public string Breed { get; }
        public string Name { get; }
    }
}