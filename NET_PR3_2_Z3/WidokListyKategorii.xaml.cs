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
using System.Xml;

namespace NET_PR3_2_Z3
{
    /// <summary>
    /// Logika interakcji dla klasy WidokListyKategorii.xaml
    /// </summary>
    public partial class WidokListyKategorii : Window
    {
        ListBox listaKategorii;
        public WidokListyKategorii()
        {
            InitializeComponent();
            listaKategorii = (ListBox)FindName("ListaKategorii");
        }

		private void OtwórzKategorię(object sender, RoutedEventArgs e)
		{
            XmlElement wybranaKategoria = (XmlElement)(listaKategorii.SelectedItem);
            if(wybranaKategoria != null)
			    new WidokKategorii(
				    wybranaKategoria
				    )
                    .Show()
                    ; 
		}
	}
}
