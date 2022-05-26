using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using OtelWDB.Model;
namespace hotel_loby
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Otel _odam = new Otel();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            roomData.ItemsSource = _odam.Get(4);
            roomData.SelectedCells.Clear();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void single_Click(object sender, RoutedEventArgs e)
        {
            roomData.ItemsSource = _odam.Get(1);
            roomData.SelectedCells.Clear();
        }

        private void duo_Click(object sender, RoutedEventArgs e)
        {
            roomData.ItemsSource = _odam.Get(2);
            roomData.SelectedCells.Clear();
        }

        private void tripple_Click(object sender, RoutedEventArgs e)
        {
            roomData.ItemsSource = _odam.Get(3);
            roomData.SelectedCells.Clear();
        }

        private void roomData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //object item = roomData.SelectedItem;
            //string ID = (roomData.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            //var ID = (roomData.SelectedItem as Otel).odaNum;
            //if (ID == null)

            DataGrid gd = (DataGrid)sender;

            Otel row_selected = gd.SelectedItem as Otel;
            if (row_selected != null)
            {
                var ID = row_selected.odaNum;
                keep.Content = $"{ID} NUMARALI ODAYI KİRALA";

            }

            //keep.Content = $"{ID} NUMARALI ODAYI KİRALA";
        }

        private void keep_Click(object sender, RoutedEventArgs e)
        {
            int geciciOda = (roomData.SelectedItem as Otel).odaNum;
            _odam.odaNum = geciciOda;
            _odam.odaOwnerName = customerName.Text;
            _odam.odaOwnerSurName = customerSurname.Text;
            _odam.odaStatus = "DOLU";
            _odam.time = keepTime.Text;

            _odam.Save(_odam);
            roomData.ItemsSource = _odam.Get(4);
            roomData.SelectedCells.Clear();

            customerName.Text = " ";
            customerSurname.Text = " ";
            keepTime.Text = " ";

            MessageBox.Show($"Oda Başarıyla {_odam.odaOwnerName} Adlı Müşteriye {_odam.time} Günlüğüne Kiralandı");
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            int geciciOda = (roomData.SelectedItem as Otel).odaNum;
            MessageBox.Show($"{geciciOda.ToString()} Numaralı Oda Başarıyla Boşaltıldı.");

            _odam.odaNum = geciciOda;
            _odam.odaOwnerName = "BOŞ";
            _odam.odaOwnerSurName = "BOŞ";
            _odam.odaStatus = "BOŞ";
            _odam.time = "BOŞ";

            _odam.Save(_odam);
            roomData.ItemsSource = _odam.Get(4);
            roomData.SelectedCells.Clear();
        }
    }
}
