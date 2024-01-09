using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfDemoApp
{
    public class ExampleTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is IExampleModel exampleModel && container is FrameworkElement fe)
            {
                switch (exampleModel.Type)
                {
                    case IExampleModel.ExampleType.Template:
                        return fe.FindResource("TemplateExampleTemplate") as DataTemplate;
                    case IExampleModel.ExampleType.MasterDetail:
                        return fe.FindResource("MasterDetailExampleTemplate") as DataTemplate;
                    default:
                        break;
                }
            }

            return null;
        }

    }
}
