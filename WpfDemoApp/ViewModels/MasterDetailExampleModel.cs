using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfDemoApp
{
    public class MasterDetailExampleModel: ViewModelBase, IExampleModel
    {
        public MasterDetailExampleModel()
        {
            BuildMasterList();
            SelectedMasterItem = MasterGridItems.FirstOrDefault();
        }

        public IExampleModel.ExampleType Type => IExampleModel.ExampleType.MasterDetail;
        public string DisplayName => "Master/Detail";

        public ObservableCollection<MasterItemModel> MasterGridItems { get; private set; }

        private MasterItemModel selectedMasterItem;
        public MasterItemModel SelectedMasterItem
        {
            get => selectedMasterItem;
            set
            {
                if (value != selectedMasterItem)
                {
                    selectedMasterItem = value;
                    OnPropertyChanged();
                    // Option 1: DetailModels hier ändern, separates Binding.
                    // DetailModelCollection = value.DetailItems;
                    // wir nehmen Option 2, weils einfacher ist, und binden direkt an die DetailModels des SelectedMasterItem
                }
            }
        }

        private void BuildMasterList()
        {
            // Das ist keine gute Art, Items zu generieren (verquast), aber
            // es zeigt, was man mit verketteten LINQ-Aufrufen machen kann
            MasterGridItems = new ObservableCollection<MasterItemModel>(
                Enumerable.Range(1, 5)
                .Select(i => new MasterItemModel(
                    "Master Item #" + i,
                    "This is Master item #" + i
            )));
            foreach (var mgi in MasterGridItems)
            {
                foreach (var childId in Enumerable.Range(1, GetRandomChildAmount()))
                {
                    mgi.AddDetailItem(childId);
                }
            }
        }

        private Random m_childAmountRnd = new Random();
        private int GetRandomChildAmount()
        {
            return m_childAmountRnd.Next(2, 8);
        }
    }
}
