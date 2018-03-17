using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using Microsoft.Win32;

namespace WpfApp2.ViewModels
{
    public class ViewModelAnalizeOverview : ViewModelBase
    {
        public string ButtonName { get; set; }
    

        public AnalizeType AnalizeType { get; set; }



        public Analize Analize { get; set; }

        public Patient CurrentPatient { get; set; }
        public DelegateCommand SetNewAnalizePicture { get; protected set; }
        public DelegateCommand OpenAnalizePicture { get; protected set; }

        public DelegateCommand ToCurrentPatientCommand { get; protected set; }

        private void SetCurrentPatientID(object sender, object data)
        {
            CurrentPatient = Data.Patients.Get((int)data);
        }
        private void SetCurrentAnalizeID(object sender, object data)
        {
            Analize = Data.Analize.Get((int)data);

            AnalizeType = Data.AnalizeType.Get(Analize.analyzeType);
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
        public ViewModelAnalizeOverview(NavigationController controller) : base(controller)
        {
           
            ButtonName = "К Пациенту";
            MessageBus.Default.Subscribe("GetPatientForAnalizeOverview", SetCurrentPatientID);
            MessageBus.Default.Subscribe("GetAnalizeForAnalizeOverview", SetCurrentAnalizeID);
            HasNavigation = false;
            Controller = controller;
            SetNewAnalizePicture = new DelegateCommand(
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
                    Data.Complete();
                }
            }
        );
            OpenAnalizePicture = new DelegateCommand(
            () =>
            {
                var img = ByteToImage(Analize.ImageByte);
                int width = Convert.ToInt32(img.Width);
                int height = Convert.ToInt32(img.Height);
                Bitmap TestBitmap = new Bitmap(width, height);
                TestBitmap.Save("TempImage.Bmp");
                TestBitmap.Dispose();
                File.WriteAllBytes("TempImage.Bmp", Analize.ImageByte);
                Process.Start("TempImage.Bmp");
            }
        );

            ToCurrentPatientCommand = new DelegateCommand(
                 () =>
                 {
                     File.Delete("TempImage.Bmp");
                     MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                     Controller.NavigateTo<ViewModelCurrentPatient>();
                 }
             );
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream);
            mStream.Dispose();
            return bm;

        }
    }
}
