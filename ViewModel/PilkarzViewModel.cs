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
        public string Imie { get => _representedPilkarz.Imie; set { _representedPilkarz.Imie = value; onPropertyChanged(nameof(Imie)); } }
        public string Nazwisko { get => _representedPilkarz.Nazwisko; set { _representedPilkarz.Nazwisko = value; onPropertyChanged(nameof(Nazwisko)); } }
        public double Waga { get => _representedPilkarz.Waga; set { _representedPilkarz.Waga = value; onPropertyChanged(nameof(Waga)); } }
        public int Wiek { get => _representedPilkarz.Wiek; set { _representedPilkarz.Wiek = value; onPropertyChanged(nameof(Wiek)); } }
        public WidokPilkarza(Pilkarz pilkarz)
        {
            _representedPilkarz = pilkarz;
        }
    }
}
