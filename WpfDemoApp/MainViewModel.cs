using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemoApp.Controls;

namespace WpfDemoApp
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            WelcomeModel = GetWelcomeModel();
            UserListModel = GetUserListModel();
            AdditionalOptionsModel = GetAdditionalOptionsModel();

            CreateLineViewModels();
            CreateModularItems();
        }

        public TypedLineItemModel WelcomeModel { get; init; }
        public UserLineItemModel UserListModel { get; init; }
        public TypedLineItemModel AdditionalOptionsModel { get; init; }

        private ObservableCollection<TypedLineItemModel> lineItems;
        public ObservableCollection<TypedLineItemModel> LineItems
        {
            get => lineItems;
            set
            {
                if (value != lineItems)
                {
                    lineItems = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<IViewItemDescriptor> modularItems;
        public ObservableCollection<IViewItemDescriptor> ModularItems
        {
            get => modularItems;
            set
            {
                if (value != modularItems)
                {
                    modularItems = value;
                    OnPropertyChanged();
                }
            }
        }


        // Hätten wir Business Objects, würden wir die ViewModels hier aus den Business Objects erzeugen
        // (oder erzeugen lassen, z. B. über eine Factory-Methode)
        private void CreateLineViewModels()
        {
            TypedLineItemModel[] lineModels =
            {
                GetWelcomeModel(),
                GetUserListModel(),
                GetAdditionalOptionsModel(),
            };
            LineItems = new ObservableCollection<TypedLineItemModel>(lineModels);
        }

        private void CreateModularItems()
        {
            ModularItems = new ObservableCollection<IViewItemDescriptor>();
            var welcomeItem = new ViewItemDescriptor<SimpleLineItemModel, SimpleLineItem>();
            welcomeItem.ViewModel.DisplayName = "Willkommen!";
            ModularItems.Add(welcomeItem);
            var userListItem = new ViewItemDescriptor<UserLineItemModel, SimpleUserList>();
            ModularItems.Add(userListItem);
            var additionalOptionsItem = new ViewItemDescriptor<SimpleLineItemModel, SimpleLineItem>();
            additionalOptionsItem.ViewModel.DisplayName = "Zusätzliche Konfiguration";
            ModularItems.Add(additionalOptionsItem);
        }

        // Methoden zur Herstellung von komplexeren Objekten sind meistens eine gute Idee:
        //  * vermeidet Redundanz
        //  * stellt sicher, dass man den richtigen Startzustand bekommt
        // Werden Objekte einer Klasse an verschiedenen Stellen gebraucht,
        // ist es sinnvoll, die als statische Methode(n) in der Klasse selbst anzulegen, also
        // public static MyClass Create(p1, p2) { ...; return new MyClass(p1, p2); }
        // Stichwort: Factory-Methode
        private TypedLineItemModel GetWelcomeModel()
        {
            return new TypedLineItemModel(LineType.Start)
            {
                DisplayName = "Willkommen!",
            };
        }
        private UserLineItemModel GetUserListModel()
        {
            return new UserLineItemModel()
            {
                DisplayName = "Benutzerübersicht",
            };
        }
        private TypedLineItemModel GetAdditionalOptionsModel()
        {
            return new TypedLineItemModel(LineType.AdditionalOptions)
            {
                DisplayName = "Zusätzliche Konfiguration",
            };
        }
    }
}
