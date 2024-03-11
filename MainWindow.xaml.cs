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
            string apiUrlTeraz = "http://api.openweathermap.org/data/2.5/forecast?lat=";
            string Url = apiUrlTeraz + szerGeo + "&lon=" + dluGeo + "&appid=" + apiKey + "&units=metric";

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
            labelMiejscowosc.Content = dane["city"]["name"];
            labelTemperatura.Content = dane["list"][0]["main"]["temp"].ToString() + " °C";
            labelOdczuwalna.Content = dane["list"][0]["main"]["feels_like"].ToString() + " °C";
            labelDeszcz.Content = (dane["list"][0]["weather"][0]["main"].ToString() == "Rain" ? "Tak" : "Nie");
            labelSnieg.Content = (dane["list"][0]["weather"][0]["main"].ToString() == "Snow" ? "Tak" : "Nie");
            labelWilgotnosc.Content = dane["list"][0]["main"]["humidity"].ToString() + " %";
            labelNaslonecznienie.Content = dane["list"][0]["clouds"]["all"].ToString() + " %";

            labelMiejscowosc3plus.Content = dane["city"]["name"];
            labelTemperatura3plus.Content = dane["list"][3]["main"]["temp"].ToString() + " °C";
            labelOdczuwalna3plus.Content = dane["list"][3]["main"]["feels_like"].ToString() + " °C";
            labelDeszcz3plus.Content = (dane["list"][3]["weather"][0]["main"].ToString() == "Rain" ? "Tak" : "Nie");
            labelSnieg3plus.Content = (dane["list"][3]["weather"][0]["main"].ToString() == "Snow" ? "Tak" : "Nie");
            labelWilgotnosc3plus.Content = dane["list"][3]["main"]["humidity"].ToString() + " %";
            labelNaslonecznienie3plus.Content = dane["list"][3]["clouds"]["all"].ToString() + " %";

            labelMiejscowosc3min.Content = dane["city"]["name"];
            labelTemperatura3min.Content = dane["list"][0]["main"]["temp"].ToString() + " °C";
            labelOdczuwalna3min.Content = dane["list"][0]["main"]["feels_like"].ToString() + " °C";
            labelDeszcz3min.Content = (dane["list"][0]["weather"][0]["main"].ToString() == "Rain" ? "Tak" : "Nie");
            labelSnieg3min.Content = (dane["list"][0]["weather"][0]["main"].ToString() == "Snow" ? "Tak" : "Nie");
            labelWilgotnosc3min.Content = dane["list"][0]["main"]["humidity"].ToString() + " %";
            labelNaslonecznienie3min.Content = dane["list"][0]["clouds"]["all"].ToString() + " %";
        }
    }
}