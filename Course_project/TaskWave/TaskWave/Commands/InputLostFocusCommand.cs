using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;

namespace TaskWave.Commands
{
    public class InputLostFocusCommand: MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public InputLostFocusCommand()
        {
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
                if (textBox.Text == string.Empty && (textBox.Name == "inputLoginAuth" || textBox.Name == "inputLoginRegister"))
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                    textBox.Text = "\u00A0Логин";
                }
                else if (textBox.Text == string.Empty && (textBox.Name == "inputPasswordAuth"|| textBox.Name == "inputPasswordRegister"))
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                    textBox.Text = "\u00A0Пароль";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "inputNameRegister")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                    textBox.Text = "\u00A0Имя";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "inputNameGmail")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                    textBox.Text = "\u00A0Почтовый адрес";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "inputNameTg")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                    textBox.Text = "\u00A0Имя_пользователя telegram";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "FieldInf")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                    textBox.Text = "\u00A0Поделитесь информацией о вашей компании или проекте, чтобы мы могли познакомиться с вашей деятельностью более подробно...";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "inputCompany")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                    textBox.Text = "\u00A0Компания";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "inputBirthday")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                    textBox.Text = "Дата рождения";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "comments")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Добавить комментарий";
                }
            }
        }
    }
}
