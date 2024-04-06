using Microsoft.Win32;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendUDP.mp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UdpClient udp;
        private const int port = 11000;
        public MainWindow()
        {
            InitializeComponent();
            udp = new UdpClient();
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new();
            of.Filter = "MP3 (*.mp3) | *.mp3";
            if (of.ShowDialog() == true)
            {
                string fileName = of.FileName;
                await SendFile(fileName);
            }
        }

        private async Task SendFile(string fileName)
        {
            try
            {
                using FileStream fs = new(fileName, FileMode.OpenOrCreate);
                IPEndPoint remote = new(IPAddress.Parse(ipadresstext.Text), port);

                byte[] fileNameBytes = System.Text.Encoding.UTF8.GetBytes(System.IO.Path.GetFileName(fileName));
                await udp.SendAsync(fileNameBytes, fileNameBytes.Length, remote);

                byte[] buffer = new byte[1024];
                int bytes;
                while ((bytes = await fs.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await udp.SendAsync(buffer, bytes, remote);
                }
                MessageBox.Show("Файл отправлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}