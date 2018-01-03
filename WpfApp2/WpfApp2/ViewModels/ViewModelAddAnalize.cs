using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddAnalize : ViewModelBase
    {
        public Analize Analize { get; set; }
        public Patient CurrentPatient { get; set; }
        public List<AnalizeType> AnalizeTypes { get; set; }
        public int SelectedIndexOfAnalizeType { get; set; }
        public string ButtonName { get; set; }

        private void SetCurrentPatientID(object sender, object data)
        {
            CurrentPatient = Data.Patients.Get((int)data);
            Analize.patientId = CurrentPatient.Id;
            Analize.data = DateTime.Now;
        }
        public DelegateCommand ToCurrentPatient { get; protected set; }
        public DelegateCommand OpenAnalizePicture { get; protected set; }
        public DelegateCommand ToCurrentPatientRealy { get; protected set; }

        public ViewModelAddAnalize(NavigationController controller) : base(controller)
        {
            Analize = new Analize();

            AnalizeTypes = new List<AnalizeType>();
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
                 Analize.analyzeType = SelectedIndexOfAnalizeType + 1;
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
         );
            ToCurrentPatientRealy = new DelegateCommand(
             () =>
             {
                 Controller.NavigateTo<ViewModelCurrentPatient>();
             }
         );
            OpenAnalizePicture = new DelegateCommand(
             () =>
             {
                 OpenFileDialog op = new OpenFileDialog();
                 op.Title = "Выберите фотографию анализа";
                 op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                   "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                   "Portable Network Graphic (*.png)|*.png";
                 if (op.ShowDialog() == true)
                 {
                     Analize.ImageByte = ImageToByte(new BitmapImage(new Uri(op.FileName)));

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
