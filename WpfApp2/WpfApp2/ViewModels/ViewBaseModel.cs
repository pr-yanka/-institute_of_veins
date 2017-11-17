using System;
using System.Windows.Input;
using WpfApp2.Views;

namespace WpfApp2.Navigation
{
    public abstract class ViewModelBase
    {
        public NavigationController Controller { get; protected set; }
        protected bool _hasNavigation = false; 

        public ICommand Navigate { get; }

        public virtual bool HasNavigation
        {
            get { return _hasNavigation; }
            set { _hasNavigation = value; }
        }

        protected ViewModelBase(NavigationController controller)
        {
            Controller = controller;
            Navigate = new RoutedCommand("Navigate", typeof(ViewModelBase));
            //предоставляет доступ отовсюда - ибо команда становится статической и глобальной
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), new CommandBinding(Navigate));
            //LegNavigate = new RoutedCommand("Navigate", typeof(ViewModelBase));
            //предоставляет доступ отовсюда - ибо команда становится статической и глобальной
            //CommandManager.RegisterClassCommandBinding(typeof(MainWindow), new CommandBinding(LegNavigate));
        }

        //protected abstract void Executed(object sender, ExecutedRoutedEventArgs e);
    }
}