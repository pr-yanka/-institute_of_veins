using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.ViewModels;

namespace WpfApp2.Templates
{
    [PrincipalPermission(SecurityAction.Demand)]
    public partial class SecretWindow : Window, IView
    {
        public SecretWindow()
        {
            InitializeComponent();
        }

        #region IView Members

        public IViewModel ViewModel
        {
            get
            {
                return DataContext as IViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        #endregion
    }
}
