using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilkarze_MVVM.Model
{
    class Pilkarz
    {
        private string _imie;
        private string _nazwisko;
        private int _wiek;
        private double _waga;

        public Pilkarz(string imie = "Cristiano", string nazwisko = "Ronaldo", int wiek = 15, double waga = 55)
        {
            this._imie = imie;
            this._nazwisko = nazwisko;
            this._wiek = wiek;
            this._waga = waga;
        }

        public Pilkarz()
        {
            this._imie = "Cristiano";
            this._nazwisko = "Ronaldo";
            this._wiek = 15;
            this._waga = 55;
        }

        public Pilkarz (string pilkarz)
        {
            string[] words = pilkarz.Split();
            this._imie = words[0];
            this._nazwisko = words[1];
            this._wiek = Convert.ToInt32(words[2]);
            this._waga = Convert.ToDouble(words[3]);
        }

        public override string ToString()
        {
            return String.Format($"{Imie} {Nazwisko} {Wiek} {Waga}kg");
        }

        public string Imie {get => _imie; set { _imie = value; } }
        public string Nazwisko { get => _nazwisko; set { _nazwisko = value; } }
        public double Waga { get => _waga; set { _waga = value; } }
        public int Wiek { get => _wiek; set { _wiek = value; } }
    }
}