using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TaskWave.Commands
{
    public class InputFocusCommand : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public InputFocusCommand()
        {
            // вызываем CanExecuteChanged один раз в конструкторе
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

         public override void Execute(object parameter)
        {
            if (parameter is TextBox textBox)
            {
                if (textBox.Text == "\u00A0Логин" || textBox.Text == "\u00A0Пароль" || textBox.Text == "\u00A0Имя" ||textBox.Text == "\u00A0Компания"||textBox.Text == "Дата рождения"||
                    textBox.Text == "\u00A0Почтовый адрес" || textBox.Text == "\u00A0Имя_пользователя telegram"||
                    textBox.Text == "\u00A0Поделитесь информацией о вашей компании или проекте, чтобы мы могли познакомиться с вашей деятельностью более подробно..."
                   )
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    textBox.Text = string.Empty;
                }

                if (textBox.Text == "\u00A0Добавить комментарий")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    textBox.Text = string.Empty;
                }
            }
        }
    }
}
