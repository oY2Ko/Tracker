using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Tracker.Servises;
using Tracker.Models;
using Xamarin.Essentials;
using System.Linq;

namespace Tracker.ViewModels
{
    class RegistrationPageViewModel : BaseViewModel
    {

        public ICommand EnterButtonClickCommand { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GroupNumber { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        StudentsService studentsService = new StudentsService();
        public RegistrationPageViewModel()
        {
            EnterButtonClickCommand = new Command(Register);
        }

        private async void Register()
        {
            var profiles = Connectivity.ConnectionProfiles;
            //if (profiles.Contains(ConnectionProfile.Ethernet))
            //{
                // если активно подключение через Wi-Fi
                if (!(String.IsNullOrWhiteSpace(FirstName) && String.IsNullOrWhiteSpace(LastName) && String.IsNullOrWhiteSpace(GroupNumber) && String.IsNullOrWhiteSpace(Login) && String.IsNullOrWhiteSpace(Password)))
                {
                    await studentsService.Add(new Student(Login, Password, new StudentProfile(FirstName, LastName, GroupNumber)));
                    await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                }
            //}
        }
    }
}
