using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class UsersDataSource
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;

            }
            set { _name = value; }
        }

        private string _btnName;
        public string BtnName
        {
            get
            {
                return _btnName;

            }
            set { _btnName = value; }
        }

        public DelegateCommand Archivate { get; protected set; }
        public DelegateCommand Redact { get; protected set; }

        public UsersDataSource(DelegateCommand Redact, string Name, DelegateCommand Archivate, string BtnName)
        {
            this.BtnName = BtnName;
            this.Redact = Redact;
            this.Archivate = Archivate;
            this.Name = Name;
        }
    }

    public class ViewModelViewUsers : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private string _nameOfTbl;
        public string NameOfTbl
        {
            get
            {
                return _nameOfTbl;

            }
            set { _nameOfTbl = value; OnPropertyChanged(); }
        }
        public ObservableCollection<UsersDataSource> _historyDataSource;
        public ObservableCollection<UsersDataSource> DataSource { get { return _historyDataSource; } set { _historyDataSource = value; OnPropertyChanged(); } }

        public DelegateCommand ToAddSomeoneCommand { get; protected set; }
        public string TooltipText { get; set; }
        public string TextAddUserOrPersonalOrMed
        {
            get;
            set;
        }

        private void SetCurrentPatientID(object sender, object data)
        {
            TextAddUserOrPersonalOrMed = "Добавить Пользователя";
            TooltipText = "Архивация позволяет отключить пользователя от системы";
            DataSource = new ObservableCollection<UsersDataSource>();


            using (MySqlContext context = new MySqlContext())
            {
                AccauntRepository accRep = new AccauntRepository(context);




                foreach (var User in accRep.GetAll)
                {
                    DelegateCommand Redact = new DelegateCommand(
                  () =>
                  {

                      MessageBus.Default.Call("GetUserForEditUser", this, User.Id);
                      Controller.NavigateTo<ViewModelEditUser>();
                  }
                  );

                    string BtnName = "Разархивировать";
                    DelegateCommand Archivate = new DelegateCommand(
                        () =>
                        {
                            Data.Accaunt.Get(User.Id).isEnabled = true;
                            Data.Complete();
                            MessageBus.Default.Call("OpenUsers", this, "");
                        }
                        );
                    if (User.isEnabled == true)
                    {
                        BtnName = "Архивировать";
                        Archivate = new DelegateCommand(
                       () =>
                       {
                           Data.Accaunt.Get(User.Id).isEnabled = false;
                           Data.Complete();
                           MessageBus.Default.Call("OpenUsers", this, "");
                       }
                       );
                    }
                    DataSource.Add(new UsersDataSource(Redact, User.Name, Archivate, BtnName));
                }
            }

        }

        public ViewModelViewUsers(NavigationController controller) : base(controller)
        {
            NameOfTbl = "Пользователи";
            base.HasNavigation = true;
            HasNavigation = true;

            MessageBus.Default.Subscribe("OpenUsers", SetCurrentPatientID);

            ToAddSomeoneCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("UpdateAccsEmptyForNewUser", this, this);

                    Controller.NavigateTo<ViewModelAddUser>();
                }
            );

        }
    }
}
