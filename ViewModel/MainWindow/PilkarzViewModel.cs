using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilkarze_MVVM.ViewModel
{
    using Model;

    class WidokPilkarza : ViewModelBase
    {
        private Pilkarz _representedPilkarz;
        public string Imie { get => _representedPilkarz.Imie; set { _representedPilkarz.Imie = value; OnPropertyChanged(nameof(Imie)); } }
        public string Nazwisko { get => _representedPilkarz.Nazwisko; set { _representedPilkarz.Nazwisko = value; OnPropertyChanged(nameof(Nazwisko)); } }
        public double Waga { get => _representedPilkarz.Waga; set { _representedPilkarz.Waga = value; OnPropertyChanged(nameof(Waga)); } }
        public int Wiek { get => _representedPilkarz.Wiek; set { _representedPilkarz.Wiek = value; OnPropertyChanged(nameof(Wiek)); } }

        public Pilkarz RepresentedPilkarz { get => _representedPilkarz; }

        public override string ToString() => _representedPilkarz.ToString();
        public WidokPilkarza(Pilkarz pilkarz)
        {
            _representedPilkarz = pilkarz;
        }
        
    }
}
