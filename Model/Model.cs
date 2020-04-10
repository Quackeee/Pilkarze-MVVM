using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilkarze_MVVM.Model
{
    class Pilkarze
    {
        private ObservableCollection<Pilkarz> _listaPilkarzy = new ObservableCollection<Pilkarz>() { new Pilkarz()};
        private int[] _wiekTable = ModelUtils.wiek();
        public ObservableCollection<Pilkarz> ListaPilkarzy { get => _listaPilkarzy; }
        public int[] WiekTable { get => _wiekTable; }

        public void load() {
            if (File.Exists(@"data.txt"))
            {
                foreach (string line in File.ReadAllLines(@"data.txt"))
                {
                    _listaPilkarzy.Add(new Pilkarz(line));
                }
            }
        }
        public void modifyPlayer(int index, string imie, string nazwisko, int wiek, double waga)
        {
            Pilkarz pilkarz = _listaPilkarzy[index];
            pilkarz.Imie = imie;
            pilkarz.Nazwisko = nazwisko;
            pilkarz.Wiek = wiek;
            pilkarz.Waga = waga;
        }

        public void addPlayer(string imie, string nazwisko, int wiek, double waga)
        {
            _listaPilkarzy.Add(new Pilkarz(imie,nazwisko,wiek,waga));
        }
        public void deletePlayer(int index)
        {
            _listaPilkarzy.RemoveAt(index);
        }
        public void save()
        {
            using (StreamWriter file = new StreamWriter(@"data.txt"))
            {
                foreach (Pilkarz pilkarz in _listaPilkarzy)
                {
                    file.WriteLine(pilkarz.ToString().Remove(pilkarz.ToString().Length - 2, 2));
                }
            }
        }
    }
}
