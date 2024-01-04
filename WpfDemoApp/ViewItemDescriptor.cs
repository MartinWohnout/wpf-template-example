using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfDemoApp
{
    public interface IViewItemDescriptor
    {
        ViewModelBase ViewModel { get; }

        Control Control { get; }
    }

    internal class ViewItemDescriptor<T, U> : ViewModelBase, IViewItemDescriptor
        where T : ViewModelBase
        where U : Control
    {
        public ViewItemDescriptor()
        {
            ViewModel = Activator.CreateInstance<T>();
            Control = Activator.CreateInstance<U>();

            // Binding manuell herstellen, damit die Komponente vollständig autonom funktionieren kann
            Binding dataContextBinding = new Binding(nameof(ViewModel))
            {
                Source = this,
                Mode = BindingMode.OneWay
            };
            BindingOperations.SetBinding(Control, System.Windows.Controls.Control.DataContextProperty, dataContextBinding);
        }

        ViewModelBase IViewItemDescriptor.ViewModel => ViewModel as ViewModelBase;
        Control IViewItemDescriptor.Control => Control as Control;

        private T viewModel;
        public T ViewModel
        {
            get => viewModel;
            set
            {
                if (value != viewModel)
                {
                    viewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        private U control;
        public U Control
        {
            get => control;
            set
            {
                if (value != control)
                {
                    control = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
