using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calc20._3WpfApp
{ // данный класс нужен для реализации IComand и соответственно для команд и клавишь. Делается 1 раз и на всегда.
    class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        } // метод срабатывающий каждый раз когда CanExecute срабатывает обычно обрабатывается автоматически WPF Сейчас мы предаем прогамме эти обязоности  CommandManager

        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            canExecute = CanExecute;
        }
        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true; // проверяет доступность команды


        public void Execute(object parameter) => execute(parameter); // метод который выполнится
    }
}
