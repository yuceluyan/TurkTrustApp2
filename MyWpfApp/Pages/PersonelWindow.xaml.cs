using MyWpfApp.PersonelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using MyWpfApp.Operations;

namespace MyWpfApp.Pages
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
     
    public partial class PersonelWindow : System.Windows.Window
    {
        private static readonly Regex regex = new Regex("[^0-9.-]+");
        public List<Employee> PersonelList { get; set; }
        public Employee SelectedPersonel { get; set; }
        
        public PersonelWindow()
        {
            InitializeComponent();
            LoadGrid();
        }
        private void LoadGrid()
        {
            PersonelServiceClient con = new PersonelServiceClient();
            PersonelList = con.getPersonelList().ToList();
        }
        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();
            emp.FirstName = txtAd.Text;
            emp.LastName = txtSoyAd.Text;
            emp.HomePhone = txtTelefon.Text;
            emp.Address = txtAdres.Text;
            emp.City = txtSehir.Text;
            emp.Country = txtUlke.Text;
            emp.BirthDate = dpDogumTarihi.SelectedDate;

            if (emp!=null)
            {
                PersonelServiceClient con = new PersonelServiceClient();
                con.Ekle(emp);
            }
          
        }

        private void BtnSil_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPersonel == null)
            {
                MessageBox.Show("Personel seçiniz..");
                return;
            }

            PersonelServiceClient con = new PersonelServiceClient();
            con.Sil(SelectedPersonel);
        }

        private void BtnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPersonel == null)
            {
                MessageBox.Show("Personel seçiniz..");
                return;
            }

            Employee emp = new Employee();
            emp.FirstName = txtAd.Text;
            emp.LastName = txtSoyAd.Text;
            emp.HomePhone = txtTelefon.Text;
            emp.Address = txtAdres.Text;
            emp.City = txtSehir.Text;
            emp.Country = txtUlke.Text;
            emp.BirthDate = dpDogumTarihi.SelectedDate;

            PersonelServiceClient con = new PersonelServiceClient();
            con.Guncelle(emp);
        }

        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            txtAd.Text = "";
            txtSoyAd.Text = "";
            txtTelefon.Text = "";
            txtAdres.Text = "";
            txtSehir.Text = "";
            txtUlke.Text = "";
            dpDogumTarihi.Text = "";
            LoadGrid();
        }

        private void BtnAra_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();
            emp.FirstName = txtAd.Text;
            emp.LastName = txtSoyAd.Text;

            if (emp!=null)
            {
                PersonelServiceClient con = new PersonelServiceClient();
                PersonelList = con.Ara(emp).ToList();
            }

        }
        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            ExcelExport exc = new ExcelExport();
            exc.ExceleYaz(dgPerson);
        }
  
        private void TxtTelefon_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            return !regex.IsMatch(text);
        }
    }
}
