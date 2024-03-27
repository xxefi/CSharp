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

namespace Multithreading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource tokenSource;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int lowerBound = int.Parse(LowerBound.Text);
                int? upperBound = int.Parse(UpperBound.Text);
                if (LowerBound.Text == null && UpperBound.Text == null)
                {
                    MessageBox.Show("Enter index");
                    return;
                }

                tokenSource = new();
                CancellationToken token = tokenSource.Token;

                await Task.Run(() =>
                {
                    GenerateNumber(lowerBound, upperBound, token);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            tokenSource?.Cancel();
            MessageBox.Show("Generate Stopped");
        }

        private void GenerateNumber(int lowerBound, int? upperBound, CancellationToken token)
        {
            int currentNumber = lowerBound;

            while (!upperBound.HasValue || currentNumber <= upperBound)
            {
                if (IsPrime(currentNumber))
                {
                    Dispatcher.Invoke(() => PrimeNumber.Items.Add(currentNumber));
                }

                if (token.IsCancellationRequested)
                    break;

                currentNumber++;

                Thread.Sleep(1000);
            }


        }

        private bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            } 
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}