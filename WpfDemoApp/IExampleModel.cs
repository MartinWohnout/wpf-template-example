using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemoApp
{
    public interface IExampleModel
    {
        public enum ExampleType
        {
            Template = 0,
            MasterDetail,
        }

        public ExampleType Type { get; }
        public string DisplayName { get; }
    }
}
