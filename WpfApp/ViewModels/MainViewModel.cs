using System.Collections.Generic;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ItemsContext _dogContext;
        private readonly ItemsContext _authorContext;

        public MainViewModel()
        {
            _dogContext = new ItemsContext(FetchDogs()) { DisplayMemberPath = "Breed" };
            _authorContext = new ItemsContext(FetchAuthors()) { DisplayMemberPath = "Genre" };
        }

        private ItemsContext selectedContext;
        public ItemsContext SelectedContext
        {
            get { return selectedContext; }
            set
            {
                selectedContext = value;
                OnPropertyChanged("SelectedContext");
            }
        }

        private bool dogChecked;
        public bool DogChecked
        {
            get { return dogChecked; }
            set
            {
                dogChecked = value;
                if (dogChecked) SelectedContext = _dogContext;
            }
        }

        private bool authorChecked;
        public bool AuthorChecked
        {
            get { return authorChecked; }
            set
            {
                authorChecked = value;
                if (authorChecked) SelectedContext = _authorContext;
            }
        }

        private static IEnumerable<IEntity> FetchDogs()
        {
            return new List<IEntity>
            {
                new Dog("Terrier", "Ralph"),
                new Dog("Beagle", "Eddy"),
                new Dog("Poodle", "Fifi")
            };
        }

        private static IEnumerable<IEntity> FetchAuthors()
        {
            return new List<IEntity>
            {
                new Author("SciFi", "Bradbury"),
                new Author("RomCom", "James")
            };
        }
    }
}