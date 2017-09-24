using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Model;
using WpfApp2.Templates;
using WpfApp2.ViewModels;

/*
    It’s important to note that you must only call AppDomain.CurrentDomain.SetThreadPrincipal once during your application’s lifetime.
    If you try to call the same method again any time during the execution of the application you will get a PolicyException saying “Default principal object cannot be set twice”.
    Because of this it is not an option to reset the thread’s principal once its default identity has been initially set.
 */

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /*
        protected override void OnStartup(StartupEventArgs e)
        {

            //Create a custom principal with an anonymous identity at startup
            CustomPrincipal customPrincipal = new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);

            base.OnStartup(e);

            //Show the login view
            AuthenticationViewModel viewModel = new AuthenticationViewModel(new AuthenticationService());
            IView loginWindow = new LoginWindow(viewModel);
            loginWindow.Show();

        }
        */
    }
}
