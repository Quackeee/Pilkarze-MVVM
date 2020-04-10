using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pilkarze_MVVM.ViewModel
{
    class RelayCommand : ICommand
    {
        #region pola prywatne
        //referencje do typów metod zdefiniowanych w interfejsie ICommand

        //delegata Action<object> jest typem określającym metody nic nie
        //zwracające o jednym argumencie typu object
        readonly Action<object> _execute;

        //delegata Predicate<object> oznacza metodę zwracającą zmienną typu
        // bool o argumencie object
        readonly Predicate<object> _canExecute;
        #endregion

        #region konstruktor
        //metody składowe interfejsu ICommand zostaną przekazane do tworzonego obiektu
        //polecenia poprzez konstruktor z zewnątrz
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            else
                _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region Składowe interfejsu ICommand
        //składowe interfejsu ICommand w odniesieniu do wstrzykniętych z zewnątrz
        // metod referencje do nich przechowujemy w prywatnych polach

        //metoda określająca czy polecenie może zostać wykonane
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        //zdarzenie informujące o możliwości wykonania polecenie
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null) CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null) CommandManager.RequerySuggested -= value;
            }
        }
        //metoda wykonywana przez polecenie
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion
    }
}
