using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class RecomendationsDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public RecomendationsType Data { get; set; }
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
        public RecomendationsDataSource(RecomendationsType Recomendations)
        {
            this.Data = Recomendations;
            IsChecked = false;
        }
    }
    public class ViewModelRecomendationsList : ViewModelBase
    {


        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand SaveChangesCommand { get; protected set; }
        public string HeaderText { get; set; }
        public string AddButtonText { get; set; }
        //Жалобы/диагноз/заключение

        public List<RecomendationsDataSource> DataSourceList { get; set; }

        public ViewModelRecomendationsList(NavigationController controller) : base(controller)
        {

            HeaderText = "Рекомендации";
            AddButtonText = "Добавить рекомендацию";
            DataSourceList = new List<RecomendationsDataSource>();
            foreach (var RecomendationsType in Data.RecomendationsTypes.GetAll)
            {
                DataSourceList.Add(new RecomendationsDataSource(RecomendationsType));
            }

            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    List<RecomendationsDataSource> DataSourceListBuffer = new List<RecomendationsDataSource>();
                    foreach(var Data in DataSourceList)
                    {
                        if(Data.IsChecked == true)
                        {
                            DataSourceListBuffer.Add(Data);
                        }
                    }
                    MessageBus.Default.Call("SetRecomendationsList", this, DataSourceListBuffer);
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
