using System;
using System.Windows.Input;

namespace WpfApp2.Navigation
{
    public abstract class ViewModelBase
    {
        protected NavigationController Controller;

        public ICommand Navigate { get; }

        protected ViewModelBase(NavigationController controller)
        {
            Controller = controller;
            Navigate = new RoutedCommand("Navigate", typeof(ViewModelBase));
            //предоставляет доступ отовсюда - ибо команда становится статической и глобальной
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), new CommandBinding(Navigate));
        }

        //protected abstract void Executed(object sender, ExecutedRoutedEventArgs e);
    }
}