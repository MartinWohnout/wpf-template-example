using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfDemoApp
{
    public class LineTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is TypedLineItemModel lineModel && container is FrameworkElement fe)
            {
                switch (lineModel.Type)
                {
                    case LineType.Start:
                    case LineType.AdditionalOptions:
                    default:
                        return fe.FindResource("CommonLineTemplate") as DataTemplate;
                    case LineType.UserSelection:
                        return fe.FindResource("UserListLineTemplate") as DataTemplate;
                }
            }
            return null;
        }
    }
}
