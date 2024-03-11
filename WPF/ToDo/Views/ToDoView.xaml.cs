using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ToDoView : UserControl
    {
        public ToDoView()
        {
            InitializeComponent();
            
        }

        private void Window_Closing(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }

    }
}