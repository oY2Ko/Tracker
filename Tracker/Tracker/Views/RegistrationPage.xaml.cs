using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            this.BindingContext = new RegistrationPageViewModel();

        }
    }
}