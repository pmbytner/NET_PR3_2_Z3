using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace NET_PR3_2_Z3
{
    /// <summary>
    /// Logika interakcji dla klasy WidokListyKategorii.xaml
    /// </summary>
    public partial class WidokListyKategorii : Window
    {
        ListBox listaKategorii;
        ObservableCollection<Kategoria> kategorie = new ObservableCollection<Kategoria>();
		public WidokListyKategorii()
        {
            DataContext = kategorie;
            InitializeComponent();
            listaKategorii = (ListBox)FindName("ListaKategorii");
        }

		private void OtwórzKategorię(object sender, RoutedEventArgs e)
		{
			Kategoria wybranaKategoria = (Kategoria)(listaKategorii.SelectedItem);
            if(wybranaKategoria != null)
			    new WidokKategorii(
				    wybranaKategoria
				    )
                    .Show()
                    ; 
		}
		private void DodajKategorię(object sender, RoutedEventArgs e)
		{
            Kategoria nowaKategoria = new Kategoria();
			kategorie.Add(nowaKategoria);
			new WidokKategorii(
				nowaKategoria
				)
				.Show()
				;
		}
		private void UsuńKategorię(object sender, RoutedEventArgs e)
		{

			Kategoria usuwanaKategoria = (Kategoria)(listaKategorii.SelectedItem);
			kategorie.Remove(usuwanaKategoria);
		}

		private void Zapisz(object sender, RoutedEventArgs e)
		{
			XmlSerializer serializator = new XmlSerializer(typeof(ObservableCollection<Kategoria>));
			TextWriter strumieńZapisu = new StreamWriter("text.xml");
			serializator.Serialize(strumieńZapisu, kategorie);
		}
	}
}
