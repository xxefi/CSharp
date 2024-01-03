using LiveCharts;
using MonefyApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MonefyApp.ViewModel
{

    public partial class MonefyViewModel
    {
        private SeriesCollection _expenseDataSeries;
        public ObservableCollection<Data> Categories { get; set; }
        public ObservableCollection<Data> Data {  get; set; } = new ObservableCollection<Data>();
        public ObservableCollection<Data> DataFilter { get; set; }
        public ObservableCollection<Canvas> PieChart { get; set; }
    }
}
