using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Pilkarze_MVVM
{
    class ModelUtils
    {
        public static int[] wiek()
        {
            int[] wiek = new int[41];
            int i = 15;
            for (int j = 0; j <= 40; j++)
            {
                wiek[j] = i;
                i++;
            }
            return wiek;
        }
    }
    class ViewModelBase : INotifyPropertyChanged
    {
        //zdarzenie informujące o zmiane własności w obiekcie ViewModelu
        public event PropertyChangedEventHandler PropertyChanged;
        //metoda zgłaszająca zmiany we własnościach podanych jako argumenty
        protected void onPropertyChanged(params string[] namesOfProperties)
        {
            //jeśli ktoś obserwuje zdarzenie PropertyChanged
            if (PropertyChanged != null)
            {
                //wywołanie zdarzenia dla wszystkich zgłoszonych do aktualizacji
                //własności w ten sposób powiadamiamy widok o zmianie stanu własności
                //w modelu widoku
                foreach (var prop in namesOfProperties)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
                }
            }
        }
    }
}
