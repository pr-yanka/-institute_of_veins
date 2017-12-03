using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;

namespace WpfApp2.LegParts
{
    public abstract class LegSectionViewModel{
        private int _listNumber;
        public int ListNumber { get; set; }

        public List<LegPartStructure> StructureSource = new List<LegPartStructure>();
        //all values

        //selected value
        private LegPartStructure _selectedValue;
        public LegPartStructure SelectedValue { get; set; }

        private bool _hasSize;
        //has size
        public bool HasSize { get; set; }

        //has double size
        private bool _hasDoubleSize;
        public bool HasDoubleSize { get; set; }

        //has first part
        private bool _hasFirstPart;
        public bool HasFirstPart { get; set; }

        //has second part
        private bool _hasSecondPart;
        public bool HasSecondPart { get; set; }

        private string _text1;
        public string Text1 { get; set; }

        private string _text2;
        public string Text2 { get; set; }

        private float _size;
        public float Size { get; set; }

        private float _size2;
        public float Size2 { get; set; }

        public string SizeToText {
            get
            {
                if (!HasSize && !HasDoubleSize)
                {
                    return "";
                }
                else if (HasSize) return Size.ToString();
                else return Size.ToString() + "*" + Size2.ToString();
            }
        }


    };
}
