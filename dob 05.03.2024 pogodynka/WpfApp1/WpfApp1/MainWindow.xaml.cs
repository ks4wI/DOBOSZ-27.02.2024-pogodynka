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
using Newtonsoft.Json.Linq;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async Task<JObject> pobierzDane(double szerGeo, double dluGeo)
        {
            string apiKey = "bee186c3b204873409849bb46e899e3a";
            string bingKey = "AtCmvUAtBBu9cafqW42vTD8VQYwzgx7-f_HmVWWlcNtOu8EmpiG9cHgCcXMqZR-Y";
            string apiUrl = "http://api.openweathermap.org/data/2.5/weather?lat=";
            string Url = apiUrl + szerGeo + "&lon=" + dluGeo + "&appid=" + apiKey + "&units=metric";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage ans = await client.GetAsync(Url);
                string rez = await ans.Content.ReadAsStringAsync();
                JObject pog = JObject.Parse(rez);
                return pog;
            }
        }
        public async void klikniecie(object sender, MouseButtonEventArgs e)
        {
            var lokalizacja = e.GetPosition(bingMap);
            var wspolrzedne = bingMap.ViewportPointToLocation(lokalizacja);
            var dane = await pobierzDane(wspolrzedne.Latitude, wspolrzedne.Longitude);
            labelMiejscowosc.Content = "Miejscowość: " + dane["name"];
            labelTemperatura.Content = "Temperatura: " + dane["main"]["temp"].ToString() + " °C";
            labelOdczuwalna.Content = "Odczuwalna temperatura: " + dane["main"]["feels_like"].ToString() + " °C";
            labelDeszcz.Content = "Czy deszcz: " + (dane["weather"][0]["main"].ToString() == "Rain" ? "Tak" : "Nie");
            labelSnieg.Content = "Czy snieg: " + (dane["weather"][0]["main"].ToString() == "Snow" ? "Tak" : "Nie");
            labelWilgotnosc.Content = "Wilgotnosc: " + dane["main"]["humidity"].ToString() + " %";
            labelNaslonecznienie.Content = "Naslonecznienie: " + dane["clouds"]["all"].ToString() + " %";
        }
    }
}
