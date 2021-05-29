using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Memory;

namespace EasyMemoryManipulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Mem _memory = new Mem();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TryToOpenProcess()
        {
            if (_memory.OpenProcess(ProcessTB.Text))
            {
                OpenProcessB.Background = Brushes.Green;
            }

            OpenProcessB.IsEnabled = false;

            Thread.Sleep(2000);

            OpenProcessB.IsEnabled = true;
        }

        private void WriteToMemory()
        {
            var address = MemAdress();
            var type = SelectionTypes();
            var value = ValueTB.Text;

            var success = _memory.WriteMemory(address, type, value);
            if (success)
            {
                LoadToMemoryB.Background = Brushes.Green;
            }
            else
            {
                LoadToMemoryB.Background = Brushes.Red;
            }
        }

        private string SelectionTypes()
        {
            if (CBByte.IsChecked.GetValueOrDefault())
            {
                return "byte";
            }
            if (CB2Bytes.IsChecked.GetValueOrDefault())
            {
                return "2bytes";
            }
            if (CBBytes.IsChecked.GetValueOrDefault())
            {
                return "bytes";
            }
            if (CBFloat.IsChecked.GetValueOrDefault())
            {
                return "float";
            }
            if (CBInt.IsChecked.GetValueOrDefault())
            {
                return "int";
            }
            if (CBString.IsChecked.GetValueOrDefault())
            {
                return "string";
            }
            if (CBDouble.IsChecked.GetValueOrDefault())
            {
                return "double";
            }
            if (CBLong.IsChecked.GetValueOrDefault())
            {
                return "long";
            }

            return "error";
        }

        private string MemAdress()
        {
            var memAdress = MemoryAddresTB.Text;

            if (!Offset1TB.Text.Equals("Offset 1") && !Offset1TB.Text.Equals(""))
            {
                memAdress += $",{Offset1TB.Text}";
            }
            if (!Offset2TB.Text.Equals("Offset 2") && !Offset2TB.Text.Equals(""))
            {
                memAdress += $",{Offset2TB.Text}";
            }
            if (!Offset3TB.Text.Equals("Offset 3") && !Offset3TB.Text.Equals(""))
            {
                memAdress += $",{Offset3TB.Text}";
            }
            if (!Offset4TB.Text.Equals("Offset 4") && !Offset4TB.Text.Equals(""))
            {
                memAdress += $",{Offset4TB.Text}";
            }

            return memAdress;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WriteToMemory();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TryToOpenProcess();
        }
    }
}
