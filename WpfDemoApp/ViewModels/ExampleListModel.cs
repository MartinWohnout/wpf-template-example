using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemoApp
{
    public class ExampleListModel : ViewModelBase
    {
        public ExampleListModel()
        {
            BuildExampleList();
            SelectedExample = ExampleList.FirstOrDefault();
        }

        public IEnumerable<IExampleModel> ExampleList { get; private set; }

        private IExampleModel selectedExample;
        public IExampleModel SelectedExample
        {
            get => selectedExample;
            set
            {
                if (value != selectedExample)
                {
                    selectedExample = value;
                    OnPropertyChanged();
                }
            }
        }

        private void BuildExampleList()
        {
            ExampleList = new List<IExampleModel>()
            {
                new TemplateExampleModel(),
                new MasterDetailExampleModel(),
            };
        }
    }
}
