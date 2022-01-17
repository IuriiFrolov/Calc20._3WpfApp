using Calc20._3WpfApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calc20._3WpfApp.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    { // Это общие фразы для связи с xaml
        public event PropertyChangedEventHandler PropertyChanged; //Cобытие уведомляет представление что произошли изменения

        void OnPropertyChanged([CallerMemberName]string PropertyName = null)  //принимает имя методода которое обновилось
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        // Переменные и словарь для MainWindowViewModel
        Dictionary<string, string> OperationDict; // Словарь, в котором хранятся два операнда и оператора
        string num2Str = ""; // Временная переменная для хранения второго числа

        

       


        //Свойство связанное с первым полем ввода, а именно с экраном калькулятора.
        private string tbt1; // Закрытое поле можно назвать tbt || showNumTextText     // Заменить ShowNumText.Text   на Tbt1.ToString()
        public string Tbt1 // Открытое поле можно назвать Tbt || ShowNumTextText
        {
            get => tbt1; // возвращаем значение закрытого поля
            set // установка ( присваивания значения value которое нам передали)
            {
                tbt1 = value;//  присваивания значения value которое нам передали заставляем событие сработать через ИНВОК
                OnPropertyChanged();
            }
        }

        //Второе пробное свойство
        //private double btn7 = Convert.ToInt32(7); 
        //public double Btn7
        //{
        //    get => btn7;
        //    set
        //    {
        //         Tbt1 +=btn7; // btn7.Click += new RoutedEventHandler(BtnNum_Click);
        //        OnPropertyChanged();
        //    }
        //}



        //Под каждую клавишу!!!!!
        //Реализуем команду (клавишу)
        public ICommand AddCommand { get; } // свойство будет доступно только для чтения Команда сложения!
        private void OnAddCommandExecute (object p)
        {
            //Tbt1 = Ariph.Add1(Convert.ToDouble(Tbt1), ); // Складывает экран 2 раза, надо бы исправить.
        }
        private bool CanAddCommandExecuted (object p )
        {
            //if (Tbt1 != 0) return true; else return false;   //надо записать что правая часть (второй операнд не равен 0)

            return true;
        }




        // №1 Реализуем команду (клавишу)    ЦИФРЫ
        public ICommand BtnNum_ClickCommand { get; } // свойство будет доступно только для чтения. 
        private void OnBtnNum_ClickCommandExecute(object sender)
        {

            var num = ;
            if (Tbt1 == "")
            {
                Tbt1 = num.Content.ToString();
                OperationDict.Add("Num1", num.Content.ToString());
            }
            else
            {
                Tbt1 += num.Content.ToString();
                OperationDict["Num1"] = Tbt1;
            }




        }
        private bool CanBtnNum_ClickCommandExecuted(object sender)
        {
            //if (Tbt1 != 0) return true; else return false;   //надо записать что правая часть (второй операнд не равен 0)

            return true;
        }








        //Конструктор!
        // Инициализация команды AddCommand в конструкторе MainWindowViewModel
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);  // Название метода под клавишу  =  new RelayCommand( метод клавиши 1, метод клавиши 2)
            OperationDict = new Dictionary<string, string>();
            BtnNum_ClickCommand = new RelayCommand(OnBtnNum_ClickCommandExecute, CanBtnNum_ClickCommandExecuted);


        }

        private void BtnNum_Click(object sender, RoutedEventArgs e)
        {
            var num = sender as Button;
            string value = "";
            if (!OperationDict.TryGetValue("Operator", out value))
            {// Оператор пуст, сохраненный номер является первым
                if (Tbt1 == "")
                {
                    Tbt1 = num.Content.ToString();
                    OperationDict.Add("Num1", num.Content.ToString());
                }
                else
                {
                    Tbt1 += num.Content.ToString();
                    OperationDict["Num1"] = Tbt1;
                }
            }
            else
            {// Оператор не пуст, сохраненный номер является вторым
                if (num2Str == "")
                {
                    Tbt1 += num.Content.ToString();
                    num2Str += num.Content.ToString();
                    OperationDict.Add("Num2", num.Content.ToString());
                }
                else
                {
                    Tbt1 += num.Content.ToString();
                    num2Str += num.Content.ToString();
                    OperationDict["Num2"] = num2Str;
                }
        }
    }
}
