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
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp2.ViewModels
{
    public class ViewModelAnalizeOverview : ViewModelBase, INotifyPropertyChanged
    {

        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public string ButtonName { get; set; }


        public AnalizeType AnalizeType { get; set; }


        private Visibility _isAnalizeLoadedVisibility;
        public Visibility IsAnalizeLoadedVisibility
        {
            get
            {
                return _isAnalizeLoadedVisibility;
            }
            set { _isAnalizeLoadedVisibility = value; OnPropertyChanged(); }
        }

        public Analize Analize { get; set; }

        public Patient CurrentPatient { get; set; }
        public DelegateCommand SetNewAnalizePicture { get; protected set; }
        public DelegateCommand OpenAnalizePicture { get; protected set; }

        public DelegateCommand ToCurrentPatientCommand { get; protected set; }

        private void SetCurrentPatientID(object sender, object data)
        {
            IsAnalizeLoadedVisibility = Visibility.Hidden;
            CurrentPatient = Data.Patients.Get((int)data);
        }
        private void SetCurrentAnalizeID(object sender, object data)
        {
            IsAnalizeLoadedVisibility = Visibility.Hidden;
            using (MySqlContext context = new MySqlContext())
            {
                AnalizeRepository AnRep = new AnalizeRepository(context);
                AnalizeTypeRepository AnTpRep = new AnalizeTypeRepository(context);
                Analize = AnRep.Get((int)data);
                AnalizeType = AnTpRep.Get(Analize.analyzeType);
            }



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
            IsAnalizeLoadedVisibility = Visibility.Hidden;
            ButtonName = "К Пациенту";
            MessageBus.Default.Subscribe("GetPatientForAnalizeOverview", SetCurrentPatientID);
            MessageBus.Default.Subscribe("GetAnalizeForAnalizeOverview", SetCurrentAnalizeID);
            HasNavigation = false;
            Controller = controller;
            SetNewAnalizePicture = new DelegateCommand(
            () =>
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Выберите файл анализа";
                op.Filter = "Image,Word|*.jpg;*.jpeg;*.png;*.docx|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png|Word Documents (.docx)|*.docx|All Files (*.*)|*.*";
                Analize = Data.Analize.Get(Analize.Id);
                if (op.ShowDialog() == true)
                {
                    if (op.SafeFileName.Contains(".docx"))
                    {
                        byte[] bteToBD = File.ReadAllBytes(op.FileName);
                        Analize.ImageByte = bteToBD;
                    }
                    else if (op.SafeFileName.Contains(".jpg") || op.SafeFileName.Contains(".jpeg")
                    || op.SafeFileName.Contains(".png") || op.SafeFileName.Contains(".JPG") || op.SafeFileName.Contains(".JPEG")
                    || op.SafeFileName.Contains(".PNG"))
                    {
                        Analize.ImageByte = ImageToByte(new BitmapImage(new Uri(op.FileName)));
                    }
                    IsAnalizeLoadedVisibility = Visibility.Visible;
                    Data.Complete();
                }
            }
        );
            OpenAnalizePicture = new DelegateCommand(
            () =>
            {
                try
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
                catch
                {
                    int togle = 0;

                    string FileName = System.IO.Path.GetTempPath() + "Анализ.docx";
                    string _fileNameOnly = "Анализ.docx";
                    byte[] bte = Analize.ImageByte;

                    for (; ; )
                    {
                        try
                        {

                            File.WriteAllBytes(FileName, bte);

                            break;
                        }
                        catch
                        {
                            togle += 1;
                            FileName = System.IO.Path.GetTempPath() + "Анализ" + togle + ".docx";
                            _fileNameOnly = "Анализ" + togle + ".docx";
                        }
                    }
                    Process.Start("WINWORD.EXE", FileName);
                }
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
