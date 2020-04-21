using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Pilkarze_MVVM.Model;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Pilkarze_MVVM.ViewModel
{
    internal partial class PilkarzeWidok : ViewModelBase
    {

        private ICommand _addPlayer;
        private ICommand _clearImie = null;
        private ICommand _clearNazwisko = null;
        private ICommand _loadPlayer = null;
        private ICommand _modifyPlayer = null;
        private ICommand _deletePlayer = null;

        public ICommand AddPlayer
        {
            get
            {
                if (_addPlayer == null)
                {
                    _addPlayer = new RelayCommand(
                        arg =>
                        {
                            ListaPilkarzy.Add(new WidokPilkarza(new Pilkarz(Imie, Nazwisko, Wiek, Waga)));
                           // onPropertyChanged(nameof(ListaPilkarzy));
                        },
                        arg => !(string.IsNullOrEmpty(Imie) || Imie == "Podaj imie" || string.IsNullOrEmpty(Nazwisko) || Nazwisko == "Podaj nazwisko"));
                } return _addPlayer;
            }
        }
        public ICommand ClearImie
        {
            get
            {
                if (_clearImie == null)
                {
                    _clearImie = new RelayCommand(
                        arg =>
                        {
                            Imie = null;
                            OnPropertyChanged(nameof(Imie));
                        },
                        arg => Imie == "Podaj imie");
                }
                return _clearImie;
            }
        }
        public ICommand ClearNazwisko
        {
            get
            {
                if (_clearNazwisko == null)
                {
                    _clearNazwisko = new RelayCommand(
                        arg =>
                        {
                            Nazwisko = null;
                            OnPropertyChanged(nameof(Nazwisko));
                        },
                        arg => Nazwisko == "Podaj nazwisko");
                }
                return _clearNazwisko;
            }
        }
        public ICommand LoadPlayer
        {
            get
            {
                if (_loadPlayer == null)
                {
                    _loadPlayer = new RelayCommand(
                        arg =>
                        {

                            WidokPilkarza pilkarz = _pilkarze[SelectedIndex];
                            Imie = pilkarz.Imie;
                            Nazwisko = pilkarz.Nazwisko;
                            Waga = pilkarz.Waga;
                            Wiek = pilkarz.Wiek;
                            OnPropertyChanged(nameof(Imie), nameof(Nazwisko), nameof(Wiek), nameof(Waga));
                        },
                        arg => SelectedIndex != -1
                    );
                }
                return _loadPlayer;
            }
        }     
        public ICommand ModifyPlayer
        {
            get
            {
                if (_modifyPlayer == null)
                {
                    _modifyPlayer = new RelayCommand(
                        arg =>
                        {
                            if (MessageBox.Show("Czy jesteś pewien, że chcesz zmodyfikować zawodnika?", "Modyfikacja zawodnika", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                            {
                                WidokPilkarza pilkarz = _pilkarze[SelectedIndex];
                                pilkarz.Imie = Imie;
                                pilkarz.Nazwisko = Nazwisko;
                                pilkarz.Wiek = Wiek;
                                pilkarz.Waga = Waga;
                            }
                        },
                        arg => SelectedIndex != -1
                    );
                }
                return _modifyPlayer;
            }
        }    
        public ICommand DeletePlayer
        {
            get
            {
                if (_deletePlayer == null)
                {
                    _deletePlayer = new RelayCommand(
                    arg =>
                    {
                        if (MessageBox.Show("Czy jesteś pewien, że chcesz usunąć zawodnika?", "Usuwanie zawodnika", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            _pilkarze.RemoveAt(SelectedIndex);
                            OnPropertyChanged(nameof(ListaPilkarzy));
                        }
                    },
                        arg => SelectedIndex != -1);
                }
                return _deletePlayer;
            }
        }
        public ICommand Save
        {
            get => new RelayCommand(arg => save(), arg => true);
        }

        public void load()
        {
            if (!File.Exists(_saveFileName))
                return;

            List<Pilkarz> loading = JsonConvert.DeserializeObject<List<Pilkarz>>(File.ReadAllText(_saveFileName));

            if (loading != null)
            {
                foreach (Pilkarz pilkarz in loading)
                {
                    _pilkarze.Add(new WidokPilkarza(pilkarz));
                }
            }
        }
        public void save()
        {
            List<Pilkarz> doZapisu = new List<Pilkarz>();
            foreach (WidokPilkarza pilkarz in _pilkarze)
            {
                doZapisu.Add(pilkarz.RepresentedPilkarz);
            }

            string rawJson = JsonConvert.SerializeObject(doZapisu);
            File.WriteAllText(_saveFileName, rawJson);
        }
    }
}
