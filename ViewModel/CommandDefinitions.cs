using System.Windows;
using System.Windows.Input;

namespace Pilkarze_MVVM.ViewModel
{
    using Model;
    internal partial class PilkarzeWidok : ViewModelBase
    {

        private ICommand _addPlayer = null;
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
                            pilkarze.addPlayer(Imie, Nazwisko, Wiek, Waga);
                            onPropertyChanged(nameof(ListaPilkarzy));
                        },
                        arg => !(string.IsNullOrEmpty(Imie) || Imie == "Podaj imię" || string.IsNullOrEmpty(Nazwisko) || Nazwisko == "Podaj nazwisko"));
                }
                return _addPlayer;
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
                            onPropertyChanged(nameof(Imie));
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
                            onPropertyChanged(nameof(Nazwisko));
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

                            Pilkarz pilkarz = pilkarze.ListaPilkarzy[SelectedIndex];
                            Imie = pilkarz.Imie;
                            Nazwisko = pilkarz.Nazwisko;
                            Waga = pilkarz.Waga;
                            Wiek = pilkarz.Wiek;
                            onPropertyChanged(nameof(Imie), nameof(Nazwisko), nameof(Wiek), nameof(Waga));
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
                                pilkarze.modifyPlayer(SelectedIndex, Imie, Nazwisko, Wiek, Waga);
                                onPropertyChanged(nameof(ListaPilkarzy));
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
                            pilkarze.deletePlayer(SelectedIndex);
                            onPropertyChanged(nameof(ListaPilkarzy));
                        }
                    },
                        arg => SelectedIndex != -1);
                }
                return _deletePlayer;
            }
        }
    }
}
