using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TaskWave.Commands
{
    public class InputLostFocusCommandWhite : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public InputLostFocusCommandWhite()
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
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Логин";
                }
                else if (textBox.Text == string.Empty && (textBox.Name == "inputPasswordAuth" || textBox.Name == "inputPasswordRegister"))
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Пароль";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "inputNameRegister")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Имя";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "inputNameGmail")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Почтовый адрес";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "inputNameTg")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Имя_пользователя telegram";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "FieldInf")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Поделитесь информацией о вашей компании или проекте, чтобы мы могли познакомиться с вашей деятельностью более подробно...";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "inputCompany")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Компания";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "inputBirthday")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Город проживания";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "NamePr")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Название проекта";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "DateCompl")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Дата выполнения";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "comments")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Добавить комментарий";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "nameTask")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Название задачи";
                }
                else if (textBox.Text == string.Empty && textBox.Name == "nameExecutor")
                {
                    textBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                    textBox.Text = "\u00A0Логин исполнителя";
                }
            }
        }
    }
}
