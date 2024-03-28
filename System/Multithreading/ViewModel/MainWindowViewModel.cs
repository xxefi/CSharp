using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Multithreading.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        private CancellationTokenSource tokenSource;
        private CancellationTokenSource fibonaciSource;
        private bool primePaused = false;
        private bool fibonacciPaused = false;
        private string _loverBound;
        private string _upperBound;
        private ObservableCollection<int> _primeNumber = new ObservableCollection<int>();
        private ObservableCollection<int> _fibonachiNumber = new ObservableCollection<int>();

        public string LowerBound
        {
            get => _loverBound;
            set => Set(ref _loverBound, value);
        }

        public string UpperBound
        {
            get => _upperBound;
            set => Set(ref _upperBound, value);
        }

        public ObservableCollection<int> PrimeNumber
        {
            get => _primeNumber;
            set => Set(ref _primeNumber, value);
        }

        public ObservableCollection<int> FibonachiNumber
        {
            get => _fibonachiNumber;
            set => Set(ref _fibonachiNumber, value);
        }

        private void GenerateNumber(int lowerBound, int? upperBound, CancellationToken token)
        {
            
            int currentNumber = lowerBound;

            while (!upperBound.HasValue || currentNumber <= upperBound)
            {
                if (IsPrime(currentNumber))
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        PrimeNumber.Add(currentNumber);
                    });
                }

                if (token.IsCancellationRequested)
                    break;

                currentNumber++;

                while (primePaused)
                {
                    Thread.Sleep(100);
                }

                Thread.Sleep(1000);
            }
        }

        private void GenerateFibonachi(CancellationToken token)
        {
            int a = 0;
            int b = 1;

            while (true)
            {
                int next = a + b;

                if (!primePaused)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        FibonachiNumber.Add(next);
                    });
                }


                if (token.IsCancellationRequested)
                    break;

                a = b;
                b = next;

                while (fibonacciPaused)
                {
                    Thread.Sleep(100);
                }

                Thread.Sleep(100);
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

        public RelayCommand Start => new(async () =>
        {
            try
            {
                int lowerBound = int.Parse(LowerBound);
                int? upperBound = int.Parse(UpperBound);
                if (LowerBound == null && UpperBound == null)
                {
                    MessageBox.Show("Enter index");
                    return;
                }

                tokenSource = new CancellationTokenSource();
                fibonaciSource = new CancellationTokenSource();
                CancellationToken token = tokenSource.Token;

                await Task.Run(() =>
                {
                    GenerateNumber(lowerBound, upperBound, token);
                });
                await Task.Run(() =>
                {
                    GenerateFibonachi(token);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });

        public RelayCommand Stop
        {
            get => new(
                () =>
                {
                    tokenSource?.Cancel();
                    MessageBox.Show("Generate Stopped");
                });
        }

        public RelayCommand RestartGenerations
        {
            get => new(
                () =>
                {
                    try
                    {
                        tokenSource?.Cancel();
                        fibonaciSource.Cancel();

                        PrimeNumber.Clear();
                        FibonachiNumber.Clear();

                        primePaused = false;
                        fibonacciPaused = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }

        public RelayCommand StopPrime
        {
            get => new(
                () =>
                {
                    tokenSource?.Cancel();
                    MessageBox.Show("Generate Prime Stopped");
                });
        }

        public RelayCommand StopFibonachi
        {
            get => new(
                () =>
                {
                    fibonaciSource?.Cancel();
                    MessageBox.Show("Generate Fibonaci Stopped");
                });
        }

        public RelayCommand PausePrime
        {
            get => new(
                () =>
                {
                    primePaused = true;
                    MessageBox.Show("Generate Paused");
                });
        }

        public RelayCommand PauseFibonachi
        {
            get => new(
                () =>
                {
                    fibonacciPaused = true;
                    MessageBox.Show("Generate Fibonachi Paused");
                });
        }

        public RelayCommand ResumePrime
        {
            get => new(
                () =>
                {
                    primePaused = false;
                    MessageBox.Show("Generate Resumed");
                });
        }

        public RelayCommand ResumeFibonachi
        {
            get => new(
                () =>
                {
                    fibonacciPaused = false;
                    MessageBox.Show("Generate Fibonachi Resumed");
                });
        }
    }
}
