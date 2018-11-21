using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomViewDuplicationIssue
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel ViewModel { get; set; } = new MainViewModel();
        public MainPage()
        {
            InitializeComponent();
            ViewModel.Fella = new Person { FirstName = "John", LastName = "Doe", Gender = "Male" };
            BindingContext = ViewModel;

        }
    }
}
