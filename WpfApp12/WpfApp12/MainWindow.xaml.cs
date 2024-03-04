using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp12
{
    public partial class MainWindow : Window
    {

        public string apiKey = "bee186c3b204873409849bb46e899e3a";
        public string bingKey = "AtCmvUAtBBu9cafqW42vTD8VQYwzgx7-f_HmVWWlcNtOu8EmpiG9cHgCcXMqZR-Y";
        public string apiUrl = "http://api.openweathermap.org/data/2.5/weather";
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void przycisk(object sender, MouseButtonEventArgs e)
        {
            var wspolrzedne = e.GetPosition(bingMap);
            var lokalizacja = bingMap.ViewportPointToLocation(wspolrzedne);
            var dane = await pobierzDane(lokalizacja.Latitude, lokalizacja.Longitude);
            labelMiejscowosc.Content = "Miejscowość: " + ;
            labelTemperatura.Content = "Temperatura: " + +" °C";
            labelOdczuwalna.Content = "Odczuwalna temperatura: " + +" °C";
            labelDeszcz.Content = "Czy deszcz: " + ;
            labelSnieg.Content = "Czy snieg: " + ;
            labelWilgotnosc.Content = "Wilgotnosc: "+  + " %";
            labelNaslonecznienie.Content = "Naslonecznienie: "+ +"%";
        }

        private async Task<WeatherData> pobierzDane(double latitude, double longitude)
        {
            using(var httpClient = new HttpClient())
            {
                var wynik = await httpClient.GetStringAsync($"{apiUrl}?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric");
                return JsonConvert.DeserializeObject<WeatherData>(wynik);
            }

        }

    }
}
