using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfDemoApp
{
    public enum LineType
    {
        Start = 0,
        UserSelection,
        AdditionalOptions,
    }

    public class SimpleLineItemModel : ViewModelBase
    {
        private string displayName;
        public string DisplayName
        {
            get => displayName;
            set
            {
                if (value != displayName)
                {
                    displayName = value;
                    OnPropertyChanged();
                }
            }
        }
    }

    /// <summary>
    /// Model für Items, bei denen eine ViewModel-Klasse (ggf. mit Unterklassen) unterschiedliche Views unterstützen kann
    /// </summary>
    public class TypedLineItemModel : SimpleLineItemModel
    {
        public TypedLineItemModel(LineType type)
        {
            Type = type;
        }

        public LineType Type { get; init; }
    }

    public class UserLineItemModel : TypedLineItemModel
    {
        public UserLineItemModel() : base(LineType.UserSelection)
        {
            CreateUserList();
        }

        private ObservableCollection<string> users;
        public ObservableCollection<string> Users
        {
            get => users;
            set
            {
                if (value != users)
                {
                    users = value;
                    OnPropertyChanged();
                }
            }
        }

        private void CreateUserList()
        {
            string[] userList = { "Alice", "Bob", "Charlie" };
            Users = new ObservableCollection<string>(userList);
        }
    }
}
