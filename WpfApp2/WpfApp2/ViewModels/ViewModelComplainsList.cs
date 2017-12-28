using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ComplainsDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public ComplainsType Data { get; set; }
        private bool? _isChecked;
        public bool? IsChecked
        {
            get
            {
                if (_isChecked == null)
                    return false;
                else return _isChecked;
            }
            set { _isChecked = value; OnPropertyChanged(); }
        }
        public ComplainsDataSource(ComplainsType Complains)
        {
       
            this.Data = Complains;
            IsChecked = false;
        }
    }
    public class ViewModelComplainsList : ViewModelBase
    {
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand SaveChangesCommand { get; protected set; }

        public string HeaderText { get; set; }
        public string AddButtonText { get; set; }
        //Жалобы/диагноз/заключение
        public List<ComplainsDataSource> DataSourceList { get; set; }

        public ViewModelComplainsList(NavigationController controller) : base(controller)
        {
            HeaderText = "Жалобы";
            AddButtonText = "Добавить жалобу";
            DataSourceList = new List<ComplainsDataSource>();
            foreach (var ComplainsType in Data.ComplainsTypes.GetAll)
            {
                DataSourceList.Add(new ComplainsDataSource(ComplainsType));
            }
            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    List<ComplainsDataSource> DataSourceListBuffer = new List<ComplainsDataSource>();
                    foreach (var Data in DataSourceList)
                    {
                        if (Data.IsChecked == true)
                        {
                            DataSourceListBuffer.Add(Data);
                        }
                    }
                    MessageBus.Default.Call("SetComplainsList", this, DataSourceListBuffer);
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );
            SaveChangesCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );
        }
    }
}
