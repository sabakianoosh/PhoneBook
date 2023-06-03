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
using System.Net.Http;
using cs16.lib;


namespace cs16.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           // mylist = new Contact();
        }

        HttpClient client = new HttpClient();
        
        public void getcontacts(object sender,RoutedEventArgs args)
        {
            try
            {
                string contacts = client.GetStringAsync(new Uri($"http://localhost:5245/")).Result;
                tbcontacts.Text = string.Empty;
                tbcontacts.Text += contacts;

            }
            catch
            {
                
            }
        }




        public void delete(object sender,RoutedEventArgs args)
        {
           string d = client.GetStringAsync(new Uri($"http://localhost:5245/delete/{tbfirstname.Text}")).Result;
            tbcontacts.Text = d;
           MessageBox.Show($"{tbfirstname.Text} deleted." );
        }
       
   public void AddContact2(object sender,RoutedEventArgs args)
        {
            
            // if (string.IsNullOrWhiteSpace(tbfirstname.Text) || string.IsNullOrWhiteSpace(tblastname.Text)|| string.IsNullOrWhiteSpace(tbphonenumber.Text))
            // {
            //     MessageBox.Show("complete informations!");
            //     return;
            // }
        string addcn = client.GetStringAsync(new Uri($"http://localhost:5245/add/{tbfirstname.Text}/{tblastname.Text}/{tbphonenumber.Text}/{tbemail.Text}")).Result;
        tbcontacts.Text = addcn;
        }
        public void find(object sender, RoutedEventArgs args)
        {
            string phn = "" ;
            phn = client.GetStringAsync(new Uri($"http://localhost:5245/{tbfirstname.Text}")).Result;
            
            if (string.IsNullOrWhiteSpace(tbfirstname.Text) && 
            string.IsNullOrWhiteSpace(tblastname.Text))
        {
            MessageBox.Show("there is Nothing to find");
            return;
        }

       
        tbcontacts.Text = string.Empty;
        if (phn != "")
        {
            tbcontacts.Text = phn;
        }
    
       else
       {
           tbphonenumber.Text = "0000";
       }
       
        }
    }
}
