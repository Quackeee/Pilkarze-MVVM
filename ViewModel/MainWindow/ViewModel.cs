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
        private string _saveFileName = "./data.json";
        private string _imie = "Podaj imie";
        private string _nazwisko = "Podaj nazwisko";
        private int _wiek = 15;
        private double _waga = 55;
        private int _selectedIndex;
        private ObservableCollection<WidokPilkarza> _pilkarze = null;
        private int[] _wiekTable = ViewModelUtils.wiek();

        public string Imie
        {
            get => _imie;
            set { _imie = value;}
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
            set { _waga = value; OnPropertyChanged(nameof(Waga)); }
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set { _selectedIndex = value; }
        }
        public int[] WiekTable
        { get => _wiekTable; }
        public ObservableCollection<WidokPilkarza> ListaPilkarzy
        { get
            {if (_pilkarze == null)
                {
                    _pilkarze = new ObservableCollection<WidokPilkarza>();
                    load();
                }
                return _pilkarze;
            }
            
        } 
    }
}
