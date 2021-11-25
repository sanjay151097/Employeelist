using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Employee_list
{ 
    public partial class MainPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        private bool initialized = false;
        public ObservableCollection<Employee> TodoItems { get; set; } = new ObservableCollection<Employee>();

        private readonly Employee_Server todoServer = RestService.For<Employee_Server>("https://jsonplaceholder.typicode.com");
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!initialized)
            {
                await GetTodoItems();
                initialized = true;
            }
        }
        public  void frame(object sender, EventArgs e)
        {
           Navigation.PushModalAsync(new Employee_detailview());
        }
            private async Task GetTodoItems()
        {
          

            var items = await todoServer.GetTodoItems();

            foreach (var item in items)
            {
                TodoItems.Add(item);
            }

            var todoItem = await todoServer.GetTodoItem(1);
          
        }
    }
}

