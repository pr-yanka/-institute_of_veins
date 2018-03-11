using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using WpfApp2.Messaging;

namespace WpfApp2
{

    /// <summary>
    ///     Intent: Behavior which means a scrollviewer will always scroll down to the bottom.
    /// </summary>
    /// 
    public class AutoScrollBehavior : Behavior<ScrollViewer>
    {
        private double _height = 0.0d;
        private ScrollViewer _scrollViewer = null;

        public AutoScrollBehavior()
        {
            //SetOneTime = false;
            MessageBus.Default.Subscribe("SetScrollForAddObsled", SetScroll);
            MessageBus.Default.Subscribe("SetScrollOnlyForAddObsled", SetScrollOnly);
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            this._scrollViewer = base.AssociatedObject;
            this._scrollViewer.ScrollChanged += new ScrollChangedEventHandler(_scrollViewer_LayoutUpdated);
        }
        //public bool SetOneTime { get; set; }
        public void SetScroll(object sender, object data)
        {
            //            this._scrollViewer.ScrollToVerticalOffset(this._height);

            // SetOneTime = true;
            MessageBus.Default.Call("SaveScrollSize", null, _height);
        }
        public void SetScrollOnly(object sender, object data)
        {
            //            this._scrollViewer.ScrollToVerticalOffset(this._height);

            _height = (double)sender;


        }
        private void _scrollViewer_LayoutUpdated(object sender, EventArgs e)
        {
            if (this._scrollViewer.VerticalOffset == 0)
            {
                MessageBus.Default.Call("GetScrollSize", null, _height);
                this._scrollViewer.ScrollToVerticalOffset(this._height);
            }
            else if (this._scrollViewer.VerticalOffset != 0)
            {
                //if (this._scrollViewer.HorizontalOffset != 0)
                //{

                this._height = this._scrollViewer.VerticalOffset;
                //}
                //else
                //{
                //    
                //}
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (this._scrollViewer != null)
            {
                this._scrollViewer.LayoutUpdated -= new EventHandler(_scrollViewer_LayoutUpdated);
            }
        }
    }

    public class AutoScrollBehaviorRight : Behavior<ScrollViewer>
    {
        private double _height = 0.0d;
        private ScrollViewer _scrollViewer = null;

        public AutoScrollBehaviorRight()
        {
            //SetOneTime = false;
            MessageBus.Default.Subscribe("SetScrollForAddObsledRight", SetScroll);
            MessageBus.Default.Subscribe("SetScrollOnlyForAddObsledRight", SetScrollOnly);
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            this._scrollViewer = base.AssociatedObject;
            this._scrollViewer.ScrollChanged += new ScrollChangedEventHandler(_scrollViewer_LayoutUpdated);
        }
        public bool SetOneTime { get; set; }
        public void SetScroll(object sender, object data)
        {
          
            MessageBus.Default.Call("SaveScrollSizeRight", null, _height);
        }
        public void SetScrollOnly(object sender, object data)
        {
            _height = (double)sender;


        }
        private void _scrollViewer_LayoutUpdated(object sender, EventArgs e)
        {
            if (this._scrollViewer.VerticalOffset == 0)
            {
                MessageBus.Default.Call("GetScrollSizeRight", null, _height);
                this._scrollViewer.ScrollToVerticalOffset(this._height);
            }
            else if (this._scrollViewer.VerticalOffset != 0)
            {
                //if (this._scrollViewer.HorizontalOffset != 0)
                //{

                this._height = this._scrollViewer.VerticalOffset;
                //}
                //else
                //{
                //    
                //}
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (this._scrollViewer != null)
            {
                this._scrollViewer.LayoutUpdated -= new EventHandler(_scrollViewer_LayoutUpdated);
            }
        }
    }
    //public class AutoScrollBehavior : Behavior<ScrollViewer>
    //{
    //    private double _height = 0.0d;
    //    private ScrollViewer _scrollViewer = null;

    //    public AutoScrollBehavior()
    //    {
    //        SetOneTime = false;
    //        MessageBus.Default.Subscribe("SetScrollForAddObsled", SetScroll);
    //    }

    //    protected override void OnAttached()
    //    {
    //        base.OnAttached();

    //        this._scrollViewer = base.AssociatedObject;
    //        this._scrollViewer.LayoutUpdated += new EventHandler(_scrollViewer_LayoutUpdated);
    //    }
    //   public  bool SetOneTime { get; set; }
    //    public void SetScroll(object sender, object data)
    //    {
    //        //            this._scrollViewer.ScrollToVerticalOffset(this._height);

    //        SetOneTime = true;
    //    }
    //    private void _scrollViewer_LayoutUpdated(object sender, EventArgs e)
    //    {
    //        if (SetOneTime && this._scrollViewer.VerticalOffset == 0)
    //        {
    //            this._scrollViewer.ScrollToVerticalOffset(this._height); }
    //        else if(this._scrollViewer.VerticalOffset != 0)
    //        {
    //            //if (this._scrollViewer.HorizontalOffset != 0)
    //            //{

    //            this._height = this._scrollViewer.VerticalOffset;
    //            //}
    //            //else
    //            //{
    //            //    
    //            //}
    //        }
    //    }

    //    protected override void OnDetaching()
    //    {
    //        base.OnDetaching();

    //        if (this._scrollViewer != null)
    //        {
    //            this._scrollViewer.LayoutUpdated -= new EventHandler(_scrollViewer_LayoutUpdated);
    //        }
    //    }
    //}


    public class RegexUtilities
    {
        bool invalid = false;

        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid email format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }
    public class StringToPhoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            //retrieve only numbers in case we are dealing with already formatted phone no
            string phoneNo = value.ToString().Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty).Replace("-", string.Empty);

            switch (phoneNo.Length)
            {
                case 7:
                    return Regex.Replace(phoneNo, @"(\d{3})(\d{4})", "$1-$2");
                case 10:
                    return Regex.Replace(phoneNo, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
                case 11:
                    return Regex.Replace(phoneNo, @"(\d{1})(\d{3})(\d{3})(\d{4})", "$1-$2-$3-$4");
                default:
                    return phoneNo;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class FloatToString : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Math.Round((float)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float buf = 0.0f;
            if (float.TryParse(value as string, out buf))
            {
                return buf;
            }
            else
            {
                return 0.0f;
            }

        }
    }
}
