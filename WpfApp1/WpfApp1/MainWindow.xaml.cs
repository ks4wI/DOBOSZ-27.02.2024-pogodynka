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
using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;


namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        public string apiKey = "bee186c3b204873409849bb46e899e3a";
        public string bingKey = "AtCmvUAtBBu9cafqW42vTD8VQYwzgx7-f_HmVWWlcNtOu8EmpiG9cHgCcXMqZR-Y";
        public string apiUrl = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void przycisk(object sender, MouseButtonEventArgs e)
        {

            labelMiejscowosc.Content = "Miejscowość: ";
            labelTemperatura.Content = "Temperatura: ";
            labelOdczuwalna.Content = "Odczuwalna temperatura: ";
            labelDeszcz.Content = "Czy deszcz: ";
            labelSnieg.Content = "Czy snieg: ";
            labelWilgotnosc.Content = "Wilgotnosc: ";
            labelNaslonecznienie.Content = "Naslonecznienie: ";
        }

    }
}
