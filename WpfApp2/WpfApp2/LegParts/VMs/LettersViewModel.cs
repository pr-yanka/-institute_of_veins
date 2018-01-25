using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;

namespace WpfApp2.LegParts.VMs
{
    public class LettersViewModel : LegPartViewModel
    {



        private List<LettersSectionViewModel> _sections;
        public  List<LettersSectionViewModel> LegSections
        {
            get { return _sections; }
            set { _sections = value; }
        }



        public void Initialize()
        {




            SaveCommand = new DelegateCommand(
  () =>
  {
      if (LegSections[0].SelectedValue != null || LegSections[1].SelectedValue != null || LegSections[2].SelectedValue != null || LegSections[3].SelectedValue != null)
      {

          IsEmpty = false;

          MessageBus.Default.Call("LegDataSaved", this, this.GetType());
          Controller.NavigateTo<ViewModelAddPhysical>();
      }
      else
      {
          IsEmpty = true;

          MessageBus.Default.Call("LegDataSaved", this, this.GetType());
          Controller.NavigateTo<ViewModelAddPhysical>();
      }
  }

  );



            LevelCount = 4;
        
            _sections = new List<LettersSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                if (i != 0)
                {
                    LegSections.Add(new LettersSectionViewModel(Controller, _sections[i - 1]));

                }
                else
                {
                    LegSections.Add(new LettersSectionViewModel(Controller, null));
                }
                LegSections[i].IsVisible = Visibility.Visible;

                if (i == 0)
                {
                    LegSections[i].StructureSource = new ObservableCollection<Letters>(Data.Letters.GetAll.ToList().Where(x => x.Leter == "C").ToList());
                    LegSections[i].ListNumber = "C";
                }
                else if (i == 1)
                {
                    LegSections[i].StructureSource = new ObservableCollection<Letters>(Data.Letters.GetAll.ToList().Where(x => x.Leter == "E").ToList());
                    LegSections[i].ListNumber = "E";
                }
                else if (i == 2)
                {
                    LegSections[i].StructureSource = new ObservableCollection<Letters>(Data.Letters.GetAll.ToList().Where(x => x.Leter == "A").ToList());
                    LegSections[i].ListNumber = "A";
                }
                else if (i == 3)
                {
                    LegSections[i].StructureSource = new ObservableCollection<Letters>(Data.Letters.GetAll.ToList().Where(x => x.Leter == "P").ToList());
                    LegSections[i].ListNumber = "P";
                }
                Letters emptyLetter = new Letters();
                emptyLetter.Id = 0;
                emptyLetter.Text1 = "";
                emptyLetter.Leter = "";
                LegSections[i].StructureSource.Add(emptyLetter);
            }
            _title = "Буквы";

        }

        public LettersViewModel(NavigationController controller) : base(controller) { }

        public LettersViewModel(NavigationController controller, LegSide side) : base(controller, side)
        {
            Initialize();
        }


    }
}
