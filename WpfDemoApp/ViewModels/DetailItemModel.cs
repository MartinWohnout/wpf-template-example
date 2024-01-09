using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemoApp
{
    public class DetailItemModel : ViewModelBase
    {
        public DetailItemModel(MasterItemModel parent, int id)
        {
            m_parent = parent;
            Id = id;
        }

        private MasterItemModel m_parent;

        public string Parent => m_parent?.DisplayName ?? string.Empty;
        public int Id { get; init; }
    }
}
