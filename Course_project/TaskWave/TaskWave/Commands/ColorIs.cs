using Azure;
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
    public class ColorIs :MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public ColorIs()
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
            String[] arr = 
                {
                    "\u00A0Логин","\u00A0Компания", "\u00A0Пароль", "\u00A0Имя", "\u00A0Почтовый адрес", "\u00A0Имя_пользователя telegram", "\u00A0Поделитесь информацией о вашей компании или проекте, чтобы мы могли познакомиться с вашей деятельностью более подробно..."
                };
            if (parameter is Page page)
            {
                var textboxes = FindTextBoxes(page);
                
                foreach (var textBox in textboxes)
                {
                    int i = 0;
                    bool k = false;
                    while (i<arr.Length)
                    {
                        if (arr[i] == textBox.Text)
                        {
                            textBox.Foreground = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                            k = true;
                            break;
                        }

                        i++;
                    }

                    if(!k)
                    {
                        textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    }
                }
            }
        }

        public static IEnumerable<TextBox> FindTextBoxes(DependencyObject parent)
        {
            List<TextBox> textboxes = new List<TextBox>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is TextBox textbox)
                {
                    textboxes.Add(textbox);
                }
                else
                {
                    textboxes.AddRange(FindTextBoxes(child));
                }
            }
            return textboxes;
        }
    }
}
