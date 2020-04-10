using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilkarze_MVVM.ViewModel
{
    using Model;
    using System.Collections.ObjectModel;

    internal partial class PilkarzeWidok : ViewModelBase
    {
        private Pilkarze pilkarze = new Model.Pilkarze();

        private string _imie = "Podaj imie";
        private string _nazwisko  = "Podaj nazwisko";
        private int _wiek = 15;
        private double _waga = 55;
        private int _selectedIndex;

        public string Imie
        {
            get => _imie;
            set { _imie = value; }
        }
        public string Nazwisko
        {
            get => _nazwisko;
            set => _nazwisko = value;
        }
        public int Wiek
        {
            get => _wiek;
            set => _wiek = value;
        }
        public double Waga
        {
            get => _waga;
            set { _waga = value; onPropertyChanged(nameof(Waga)); }
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set { _selectedIndex = value; onPropertyChanged(nameof(SelectedIndex)); }
        }
        public int[] WiekTable
        { get => pilkarze.WiekTable; }
        public ObservableCollection<Pilkarz> ListaPilkarzy
        { get => pilkarze.ListaPilkarzy; } 
    }
}
