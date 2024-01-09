using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemoApp
{
    public class MasterItemModel : ViewModelBase
    {
        public MasterItemModel(string name, string description = "")
        {
            DisplayName = name;
            Description = description;
        }

        public string DisplayName { get; init; }

        private string description;
        public string Description
        {
            get => description;
            set
            {
                if (!string.Equals(value, description, StringComparison.Ordinal))
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<DetailItemModel> detailItems;
        public ObservableCollection<DetailItemModel> DetailItems
        {
            get => detailItems;
            set
            {
                if (value != detailItems)
                {
                    detailItems = value;
                    OnPropertyChanged();
                }
            }
        }

        public void AddDetailItem()
        {
            var maxId = DetailItems?.Max(di => di.Id) ?? 1;
            AddDetailItem(++maxId);
        }

        public void AddDetailItem(int id)
        {
            if (DetailItems == null)
            {
                DetailItems = new ObservableCollection<DetailItemModel>();
            }
            if (DetailItems.Any(d => d.Id == id))
            {
                throw new ArgumentException("Id already in use.");
            }
            DetailItems.Add(new DetailItemModel(this, id));
        }
    }
}
