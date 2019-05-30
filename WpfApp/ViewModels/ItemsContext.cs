using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfApp.Models;
using System.Linq;
using System;

namespace WpfApp.ViewModels
{
    public class ItemsContext : ViewModelBase
    {
        public ItemsContext(IEnumerable<IEntity> items)
        {
            if (items == null || !items.Any()) throw new ArgumentException("Items");

            Items = new ObservableCollection<IEntity>(items);
            SelectedItem = Items.First();
        }

        public ObservableCollection<IEntity> Items { get; }

        private IEntity selectedItem;
        public IEntity SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public string DisplayMemberPath { get; set; }
    }
}
