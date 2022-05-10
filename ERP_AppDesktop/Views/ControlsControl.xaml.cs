using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ERP_AppDesktop.Views
{
    public enum OrderStatuss { None, New, Processing, Shipped, Received };
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsMember { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class OrderStatus
    {
        public string Status { get; set; }

        public OrderStatus(string status)
        {
            this.Status = status;
        }
    }



    public partial class ControlsControl : UserControl
    {
        public ControlsControl()
        {
            InitializeComponent();

            ObservableCollection<Customer> custdata = GetData();

            ObservableCollection<OrderStatus> orderStatuses = new ObservableCollection<OrderStatus>
            {
                new OrderStatus("None"),
                new OrderStatus("New"),
                new OrderStatus("Processing"),
                new OrderStatus("Shipped"),
                new OrderStatus("Received"),
            };
        }

        private ObservableCollection<Customer> GetData()
        {
            var customers = new ObservableCollection<Customer>();
            customers.Add(new Customer { FirstName = "Orlando", LastName = "Gee", Email = "orlando0@adventure-works.com", IsMember = true, Status = new OrderStatus("None") });
            customers.Add(new Customer { FirstName = "Keith", LastName = "Harris", Email = "keith0@adventure-works.com", IsMember = true, Status = new OrderStatus("None") });
            customers.Add(new Customer { FirstName = "Donna", LastName = "Carreras", Email = "donna0@adventure-works.com", IsMember = false, Status = new OrderStatus("New") });
            customers.Add(new Customer { FirstName = "Janet", LastName = "Gates", Email = "janet0@adventure-works.com", IsMember = true, Status = new OrderStatus("New") });
            customers.Add(new Customer { FirstName = "Lucy", LastName = "Harrington", Email = "lucy0@adventure-works.com", IsMember = false, Status = new OrderStatus("Processing") });
            customers.Add(new Customer { FirstName = "Rosmarie", LastName = "Carroll", Email = "rosmarie0@adventure-works.com", IsMember = true, Status = new OrderStatus("Processing") });
            customers.Add(new Customer { FirstName = "Dominic", LastName = "Gash", Email = "dominic0@adventure-works.com", IsMember = true, Status = new OrderStatus("Shipped") });
            customers.Add(new Customer { FirstName = "Kathleen", LastName = "Garza", Email = "kathleen0@adventure-works.com", IsMember = false, Status = new OrderStatus("Shipped") });
            customers.Add(new Customer { FirstName = "Katherine", LastName = "Harding", Email = "katherine0@adventure-works.com", IsMember = true, Status = new OrderStatus("Received") });
            customers.Add(new Customer { FirstName = "Johnny", LastName = "Caprio", Email = "johnny0@adventure-works.com", IsMember = false, Status = new OrderStatus("Received") });

            return customers;
        }



        private MenuItem CreateSubMenu(string header)
        {
            var item = new MenuItem { Header = header };
            item.Items.Add(new MenuItem { Header = "Item 1" });
            item.Items.Add("Item 2");
            item.Items.Add(new Separator());
            item.Items.Add("Item 3");
            return item;
        }

        private void ShowContextMenu_Click(object sender, RoutedEventArgs e)
        {
            var contextMenu = new ContextMenu();

            contextMenu.Items.Add(new MenuItem { Header = "Item" });
            contextMenu.Items.Add(new MenuItem { Header = "Item with gesture", InputGestureText = "Ctrl+C" });
            contextMenu.Items.Add(new MenuItem { Header = "Item, disabled", IsEnabled = false });
            contextMenu.Items.Add(new MenuItem { Header = "Item, checked", IsChecked = true });
            contextMenu.Items.Add(new MenuItem { Header = "Item, checked and disabled", IsChecked = true, IsEnabled = false });
            contextMenu.Items.Add(new Separator());
            contextMenu.Items.Add(CreateSubMenu("Item with submenu"));

            var menu = CreateSubMenu("Item with submenu, disabled");
            menu.IsEnabled = false;
            contextMenu.Items.Add(menu);

            contextMenu.IsOpen = true;
        }
    }
}
