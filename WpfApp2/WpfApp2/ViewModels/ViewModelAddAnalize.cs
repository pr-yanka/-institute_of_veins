using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels.Panels;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddAnalize : ViewModelBase, INotifyPropertyChanged
    {

        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public DelegateCommand RevertCommand { set; get; }



        public DelegateCommand SaveCommand { set; get; }


        public ICommand OpenCommand { protected set; get; }

        public AnalizePanelViewModel CurrentPanelViewModel { get; protected set; }

        public static bool Handled = false;
        public UIElement UI;
        private void OpenHandler(object sender, object data)
        {
            if (!Handled)
            {
                Handled = true;
                CurrentPanelViewModel.PanelOpened = true;
            }
        }
        public Analize Analize { get; set; }
        public Patient CurrentPatient { get; set; }
        private ObservableCollection<AnalizeType> _analizeTypes;
        public ObservableCollection<AnalizeType> AnalizeTypes { get { return _analizeTypes; } set { _analizeTypes = value; OnPropertyChanged(); } }
        private int _selectedIndexOfAnalizeType;
        public int SelectedIndexOfAnalizeType { get { return _selectedIndexOfAnalizeType; } set { _selectedIndexOfAnalizeType = value; OnPropertyChanged(); } }
        public string ButtonName { get; set; }

        private void SetCurrentPatientID(object sender, object data)
        {
            IsAnalizeLoadedVisibility = Visibility.Hidden;
            CurrentPatient = Data.Patients.Get((int)data);
            Analize.patientId = CurrentPatient.Id;
            Analize.data = DateTime.Now;

            AnalizeTypes = new ObservableCollection<AnalizeType>();
            foreach (var AnalizeType in Data.AnalizeType.GetAll)
            {

                AnalizeTypes.Add(AnalizeType);
            }

        }
        //IsAnalizeLoadedVisibility


        private Visibility _isAnalizeLoadedVisibility;
        public Visibility IsAnalizeLoadedVisibility
        {
            get
            {
                return _isAnalizeLoadedVisibility;
            }
            set { _isAnalizeLoadedVisibility = value; OnPropertyChanged(); }
        }
        public string TextOFNewType { get; private set; }
        public DelegateCommand ToCurrentPatient { get; protected set; }
        public DelegateCommand OpenAnalizePicture { get; protected set; }
        public DelegateCommand ToCurrentPatientRealy { get; protected set; }

        public ViewModelAddAnalize(NavigationController controller) : base(controller)
        {
            IsAnalizeLoadedVisibility = Visibility.Hidden;
            CurrentPanelViewModel = new AnalizePanelViewModel(this);
            OpenCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = true;
            });

            SaveCommand = new DelegateCommand(() =>
            {

                var newType = CurrentPanelViewModel.GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.Str))
                {
                    CurrentPanelViewModel.PanelOpened = false;
                    Handled = false;


                    Data.AnalizeType.Add((newType));

                    Data.Complete();
                    var DataSourceListbuf = AnalizeTypes;
                    AnalizeTypes = new ObservableCollection<AnalizeType>();

                    using (var context = new MySqlContext())
                    {
                        AnalizeTypeRepository sRep = new AnalizeTypeRepository(context);
                        foreach (var HirurgInterupType in sRep.GetAll)
                        {
                            AnalizeTypes.Add(HirurgInterupType);

                        }
                    }
                    SelectedIndexOfAnalizeType = AnalizeTypes.Count - 1;
                    //foreach (var RecomendationsType in Data.OperationForAmbulatornCard.GetAll)
                    //{
                    //    DataSourceList.Add(new OperationForAmbullatorCardDataSource(RecomendationsType));
                    //}


                    Controller.NavigateTo<ViewModelAddAnalize>();
                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            RevertCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.PanelOpened = false;
                Handled = false;
            });
            Analize = new Analize();
            TextOFNewType = "Новый анализ";
            AnalizeTypes = new ObservableCollection<AnalizeType>();
            foreach (var AnalizeType in Data.AnalizeType.GetAll)
            {
                AnalizeTypes.Add(AnalizeType);
            }
            // AnalizeType = Data.AnalizeType.Get(Analize.analyzeType);
            HasNavigation = false;
            ButtonName = "Добавить анализ";
            MessageBus.Default.Subscribe("GetPatientForAnalize", SetCurrentPatientID);
            ToCurrentPatient = new DelegateCommand(
             () =>
             {
                 if (AnalizeTypes.Count != 0)
                 {
                     Analize.analyzeType = AnalizeTypes[SelectedIndexOfAnalizeType].Id;
                     if (Analize.ImageByte == null)
                     {


                         MessageBox.Show("Загрузите фото анализа");
                     }
                     else
                     {
                         Data.Analize.Add(Analize);
                         Data.Complete();
                         MessageBus.Default.Call("GetPatientForAnalizeOverview", this, CurrentPatient.Id);
                         MessageBus.Default.Call("GetAnalizeForAnalizeOverview", this, Analize.Id);
                         Controller.NavigateTo<ViewModelAnalizeOverview>();
                         Analize = new Analize();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Добавьте тип анализа");
                 }
             }
         );
            ToCurrentPatientRealy = new DelegateCommand(
             () =>
             {
                 MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                 Controller.NavigateTo<ViewModelCurrentPatient>();
             }
         );
            OpenAnalizePicture = new DelegateCommand(
             () =>
             {
                 OpenFileDialog op = new OpenFileDialog();
                 op.Title = "Выберите файл анализа";
                 op.Filter = "Image,Word|*.jpg;*.jpeg;*.png;*.docx|" +
                   "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                   "Portable Network Graphic (*.png)|*.png|Word Documents (.docx)|*.docx|All Files (*.*)|*.*";
                 if (op.ShowDialog() == true)
                 {
                     if (op.SafeFileName.Contains(".docx"))
                     { byte[] bteToBD = File.ReadAllBytes(op.FileName);
                         Analize.ImageByte = bteToBD;
                     }
                     else if (op.SafeFileName.Contains(".jpg") || op.SafeFileName.Contains(".jpeg")
                     || op.SafeFileName.Contains(".png") || op.SafeFileName.Contains(".JPG") || op.SafeFileName.Contains(".JPEG")
                     || op.SafeFileName.Contains(".PNG"))
                     {
                         Analize.ImageByte = ImageToByte(new BitmapImage(new Uri(op.FileName)));
                     }
                     IsAnalizeLoadedVisibility = Visibility.Visible;
                 }

             }
         );
        }
        public Byte[] ImageToByte(BitmapImage imageSource)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageSource));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }

            return data;
        }

    }
}
