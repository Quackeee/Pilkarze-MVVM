using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilkarze_MVVM.ViewModel
{
    using Model;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    internal class PilkarzeWidok : ViewModelBase
    {
        private Pilkarze pilkarze = new Model.Pilkarze();

        private string _imie = "Podaj imie";
        private string _nazwisko = "Podaj nazwisko";
        private int _wiek = 15;
        private double _waga = 55;

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
        public int[] WiekTable { get => pilkarze.WiekTable; }
        
        public ObservableCollection<Pilkarz> ListaPilkarzy { get => pilkarze.ListaPilkarzy; }

        private ICommand _addPlayer = null;
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


        /*
        private void onFocusTextBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Podaj imię" || tb.Text == "Podaj nazwisko")
            {
                tb.Clear();
            }
            tb.Foreground = Brushes.Black;
        }

        
        private void textBoxError(TextBox tb)
        {
            tb.BorderBrush = Brushes.Red;
            tb.BorderThickness = new Thickness(3);
            tb.Foreground = Brushes.Black;
        }
        private void textBoxAccept(TextBox tb)
        {
            tb.BorderThickness = new Thickness(1);
            tb.BorderBrush = Brushes.Black;
            tb.Foreground = Brushes.Black;
        }

        private void onUnfocusTextBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
                textBoxError(tb);
            else
                textBoxAccept(tb);
        }

        private bool textBoxesOk => (imie_tb.Text != "" && imie_tb.Text != "Podaj imię" && nazwisko_tb.Text != "" && nazwisko_tb.Text != "Podaj nazwisko");

        private void wrongInputError()
        {
            MessageBox.Show("Niepoprawnie podane dane zawodnika", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            if (imie_tb.Text == "" || imie_tb.Text == "Podaj imię")
            {
                imie_tb.BorderBrush = Brushes.Red;
                imie_tb.BorderThickness = new Thickness(3);
            }
            if (nazwisko_tb.Text == "" || nazwisko_tb.Text == "Podaj nazwisko")
            {
                nazwisko_tb.BorderBrush = Brushes.Red;
                nazwisko_tb.BorderThickness = new Thickness(3);
            }
        }

        private void onSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sdr = (Slider)sender;
            waga_lbl.Content = sdr.Value.ToString() + "kg";
        }

        private void loadPlayer(object sender, SelectionChangedEventArgs e)
        {
            if (pilkarze_lb.SelectedIndex != -1)
            {
                Pilkarz pilkarz = pilkarze[pilkarze_lb.SelectedIndex];

                imie_tb.Text = pilkarz.Imie;
                nazwisko_tb.Text = pilkarz.Nazwisko;
                wiek_cb.SelectedIndex = pilkarz.Wiek - 15;
                waga_sdr.Value = pilkarz.Waga;
                textBoxAccept(imie_tb);
                textBoxAccept(nazwisko_tb);
            }
        }*/
    }
}
