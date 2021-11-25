using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Employee_list
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Employee_detailview : ContentPage
    {
        private bool initialized = false;
        public ObservableCollection<Employee> TodoItems { get; set; } = new ObservableCollection<Employee>();

        private readonly Employee_Server todoServer = RestService.For<Employee_Server>("https://jsonplaceholder.typicode.com");
        public Employee_detailview()
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