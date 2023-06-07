using hotel_loby.Model;
using OtelWDB.Model;
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
using System.Windows.Shapes;

namespace hotel_loby
{
    /// <summary>
    /// Interaction logic for FaturaWin.xaml
    /// </summary>
    public partial class FaturaWin : Window
    {
        public FaturaWin()
        {
            InitializeComponent();
        }

        Otel _odam = new Otel();
        Fatura _atura = new Fatura();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int ftID = Convert.ToInt32(textFrFt.Text);

            List<Fatura> fatura = _atura.Get(ftID);

            if (fatura.Count > 0)
            {
                Fatura fat = fatura[0];
                FatId.Content ="KİRALANAN ODA: " + fat.id.ToString();
                FatOwner.Content ="MÜŞTERİ ADI: " +  fat.owner.ToString();
                FatPrice.Content ="TAHSİL EDİLMESİ GEREKEN FATURA ÜCRETİ: " + fat.price.ToString() + " TL";
                //MessageBox.Show(fatura[0].owner.ToString());
            }
            else
            {
                MessageBox.Show("Faturaya bakılmadan önce oda boşaltılmış");
            }




        }
    }
}
