using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TaskWave.Commands;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskWave.Classes
{
    public class Generator
    {

        public static StackPanel createBlockTask(int id, string nameTask, DateTime dateOt, DateTime dateTo, bool isPr = false)
        {
            TimeSpan timeSpan = dateTo.Date.Subtract(DateTime.Now.Date);
            int day = timeSpan.Days;
            StackPanel stackPanel = new StackPanel() { Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5E687C")), Height = 100, Margin = new Thickness(5)};
            TextBlock taskTextBlock = new TextBlock() { FontFamily = new FontFamily("Malgun Gothic Semilight"), FontSize = 18, Margin = new Thickness(3, 0, 0, 0), TextWrapping = TextWrapping.Wrap };
            taskTextBlock.Inlines.Add(new Run(nameTask) { Foreground = Brushes.White });
            TextBlock daysLeftTextBlock = new TextBlock() { FontFamily = new FontFamily("Malgun Gothic Semilight"), FontSize = 18 };

            if (day<10 && day>0 && !isPr)
            {
                daysLeftTextBlock.Inlines.Add(new Run(" (до сдачи осталось дней: ") { Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CE5A57")) });
                daysLeftTextBlock.Inlines.Add(new Run(Convert.ToString(day)) { Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CE5A57")) });
                daysLeftTextBlock.Inlines.Add(new Run(")") { Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CE5A57")) });
                taskTextBlock.Inlines.Add(daysLeftTextBlock);
               
            }

            else if(day>10 && !isPr)
            {
                daysLeftTextBlock.Inlines.Add(new Run(" (до сдачи осталось дней: ") { Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E1B16A")) });
                daysLeftTextBlock.Inlines.Add(new Run(Convert.ToString(day)) { Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E1B16A")) });
                daysLeftTextBlock.Inlines.Add(new Run(")") { Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E1B16A")) });
                taskTextBlock.Inlines.Add(daysLeftTextBlock);
              

            }
            else if(day<0 && !isPr)
            {
                daysLeftTextBlock.Inlines.Add(new Run(" (сдача просрочена на дней: ") { Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#78A5A3")) });
                daysLeftTextBlock.Inlines.Add(new Run(Convert.ToString(day * -1)) { Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#78A5A3")) });
                daysLeftTextBlock.Inlines.Add(new Run(")") { Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#78A5A3")) });
                taskTextBlock.Inlines.Add(daysLeftTextBlock);
               
            }
            stackPanel.Children.Add(taskTextBlock);

            TextBlock date1TextBlock = new TextBlock() { FontFamily = new FontFamily("Microsoft Sans Serif"), FontSize = 13, Margin = new Thickness(3, 27, 0, 0), FontWeight = FontWeights.UltraBold };
            date1TextBlock.Inlines.Add(new Run("Задача поставлена: ") { Foreground = Brushes.White });
            date1TextBlock.Inlines.Add(new Run(Convert.ToString(dateOt.Date.ToString("dd.MM.yyyy"))) { Foreground = Brushes.White, FontFamily = new FontFamily("Malgun Gothic Semilight") });
            stackPanel.Children.Add(date1TextBlock);

            TextBlock date2TextBlock = new TextBlock() { FontFamily = new FontFamily("Microsoft Sans Serif"), FontSize = 13, Margin = new Thickness(3, 0, 0, 0), FontWeight = FontWeights.UltraBold };
            date2TextBlock.Inlines.Add(new Run("Необходимо выполнить до: ") { Foreground = Brushes.White });
            date2TextBlock.Inlines.Add(new Run(Convert.ToString(dateTo.Date.ToString("dd.MM.yyyy"))) { Foreground = Brushes.White, FontFamily = new FontFamily("Malgun Gothic Semilight") });
            stackPanel.Children.Add(date2TextBlock);

            Button moreButton;
            if (!isPr)
            {
                moreButton = new Button() { Content = "Подробнее", Command = new OpenTaskCommand(), CommandParameter = id, Style = (Style)Application.Current.Resources["StartBtn"], VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, -18, 8, 0), Width = 130, Height = 25 };
            }
            else
            {
                moreButton = new Button() { Content = "Подробнее", Command = new OpenPrCommand(), CommandParameter = id, Style = (Style)Application.Current.Resources["StartBtn"], VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, -18, 8, 0), Width = 130, Height = 25 };
            }

            stackPanel.Children.Add(moreButton);
          
            return stackPanel;
        }

        public static StackPanel createBlockForReadyTask(int id, string nameTask, DateTime dateready, DateTime dateTo, bool isSend = false, bool isCheck=false)
        {

            StackPanel stackPanel = new StackPanel() { Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5E687C")), Height = 100, Margin = new Thickness(5) };
            TextBlock taskTextBlock = new TextBlock() { FontFamily = new FontFamily("Malgun Gothic Semilight"), FontSize = 18, Margin = new Thickness(3, 0, 0, 0), TextWrapping = TextWrapping.Wrap };
            taskTextBlock.Inlines.Add(new Run(nameTask) { Foreground = Brushes.White });
            TextBlock daysLeftTextBlock = new TextBlock() { FontFamily = new FontFamily("Malgun Gothic Semilight"), FontSize = 18 };

           
            stackPanel.Children.Add(taskTextBlock);

            if(!isSend)
            {
                TextBlock date1TextBlock = new TextBlock() { FontFamily = new FontFamily("Microsoft Sans Serif"), FontSize = 13, Margin = new Thickness(3, 27, 0, 0), FontWeight = FontWeights.UltraBold };
                date1TextBlock.Inlines.Add(new Run("Задача выполнена: ") { Foreground = Brushes.White });
                date1TextBlock.Inlines.Add(new Run(Convert.ToString(dateready.Date.ToString("dd.MM.yyyy"))) { Foreground = Brushes.White, FontFamily = new FontFamily("Malgun Gothic Semilight") });
                stackPanel.Children.Add(date1TextBlock);
            }
            else
            {
                TextBlock date1TextBlock = new TextBlock() { FontFamily = new FontFamily("Microsoft Sans Serif"), FontSize = 13, Margin = new Thickness(3, 27, 0, 0), FontWeight = FontWeights.UltraBold };
                date1TextBlock.Inlines.Add(new Run("Задача отправлена: ") { Foreground = Brushes.White });
                date1TextBlock.Inlines.Add(new Run(Convert.ToString(dateready.Date.ToString("dd.MM.yyyy"))) { Foreground = Brushes.White, FontFamily = new FontFamily("Malgun Gothic Semilight") });
                stackPanel.Children.Add(date1TextBlock);
            }

            TextBlock date2TextBlock = new TextBlock() { FontFamily = new FontFamily("Microsoft Sans Serif"), FontSize = 13, Margin = new Thickness(3, 0, 0, 0), FontWeight = FontWeights.UltraBold };
            date2TextBlock.Inlines.Add(new Run("Необходимо выполнить до: ") { Foreground = Brushes.White });
            date2TextBlock.Inlines.Add(new Run(Convert.ToString(dateTo.Date.ToString("dd.MM.yyyy"))) { Foreground = Brushes.White, FontFamily = new FontFamily("Malgun Gothic Semilight") });
            stackPanel.Children.Add(date2TextBlock);

            Button moreButton;

            if(!isCheck)
            {
                moreButton = new Button() { Content = "Подробнее", Command = new OpenReadySendTaskCommand(), CommandParameter = id, Style = (Style)Application.Current.Resources["StartBtn"], VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, -18, 8, 0), Width = 130, Height = 25 };
                stackPanel.Children.Add(moreButton);
            }
            else
            {

                moreButton = new Button() { Content = "Подробнее", Command = new OpenReadySendTaskCommand(true), CommandParameter = id, Style = (Style)Application.Current.Resources["StartBtn"], VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, -18, 8, 0), Width = 130, Height = 25 };
                stackPanel.Children.Add(moreButton);

            }

            return stackPanel;
        }

        public static StackPanel panelWithTask(string text, int idPr)
        {
            // Создаем новый StackPanel, который будет содержать элементы блока кода
            StackPanel newBlock = new StackPanel() { Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#31364A")), Height = 44, Margin = new Thickness(10, 10, 10, 10) };

            // Создаем TextBlock
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Style = (Style)Application.Current.Resources["TB_H3TypePr"];
            textBlock.Margin = new Thickness(5);

            // Создаем Image
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\delete-480.png", UriKind.Absolute));
            image.Width = 15;
            image.Cursor = new Cursor("D:\\studing\\4_semestr\\Course_project\\Cursor\\Red Neon\\link_select.cur");
            image.HorizontalAlignment = HorizontalAlignment.Right;
            image.Margin = new Thickness(5, -3, 5, -3);

            // Создаем триггер и команду
            InvokeCommandAction invokeCommandAction = new InvokeCommandAction();
            invokeCommandAction.Command = new DeleteTaskCommand(idPr);
            invokeCommandAction.CommandParameter = text;

            // Создаем EventTrigger и добавляем в него триггер и команду
            System.Windows.Interactivity.EventTrigger eventTrigger = new System.Windows.Interactivity.EventTrigger();
            eventTrigger.EventName = "MouseDown";
            eventTrigger.Actions.Add(invokeCommandAction);

            // Добавляем EventTrigger в Image
            System.Windows.Interactivity.Interaction.GetTriggers(image).Add(eventTrigger);

            // Добавляем Image в TextBlock
            textBlock.Inlines.Add(image);

            // Создаем ScrollViewer и добавляем в него StackPanel
            ScrollViewer scrollViewer = new ScrollViewer() { VerticalScrollBarVisibility = ScrollBarVisibility.Auto, HorizontalScrollBarVisibility = ScrollBarVisibility.Visible };

            // Добавляем TextBlock в новый StackPanel
            scrollViewer.Content = textBlock;

            newBlock.Children.Add(scrollViewer);

            return newBlock;
        }

        public static StackPanel createNotification(string message, DateTime date, string loginSender, int id)
        {
            StackPanel stackPanel = new StackPanel() { Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5E687C")), Height = 100, Margin = new Thickness(5) };
            TextBlock taskTextBlock = new TextBlock() { FontFamily = new FontFamily("Malgun Gothic Semilight"), FontSize = 16, Margin = new Thickness(3, 0, 0, 0), TextWrapping = TextWrapping.Wrap };
            taskTextBlock.Inlines.Add(new Run(message) { Foreground = Brushes.White });
            stackPanel.Children.Add(taskTextBlock);

            TextBlock senderTextBlock = new TextBlock() { FontFamily = new FontFamily("Malgun Gothic Semilight"), FontSize = 16, Margin = new Thickness(3, 0, 0, 0) };
            senderTextBlock.Inlines.Add(new Run("Отправитель: ") { Foreground = Brushes.White});
            senderTextBlock.Inlines.Add(new Run(loginSender) { Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CE5A57")) });
            stackPanel.Children.Add(senderTextBlock);

            TextBlock date1TextBlock = new TextBlock() { FontFamily = new FontFamily("Microsoft Sans Serif"), FontSize = 13, Margin = new Thickness(3, 27, 0, 0), FontWeight = FontWeights.UltraBold };
            date1TextBlock.Inlines.Add(new Run("Отправлено: ") { Foreground = Brushes.White });
            date1TextBlock.Inlines.Add(new Run(Convert.ToString(date.Date.ToString("dd.MM.yyyy"))) { Foreground = Brushes.White, FontFamily = new FontFamily("Malgun Gothic Semilight") });
            stackPanel.Children.Add(date1TextBlock);

            Button moreButton = new Button() { Content = "Просмотрено", Command = new DeleteNotifCommand(), CommandParameter = id, Style = (Style)Application.Current.Resources["StartBtn"], VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, -26, 8, 0), Width = 130, Height = 25 };
            stackPanel.Children.Add(moreButton);

            return stackPanel;
        }

        public static StackPanel createRequestRegister(string message,string name, int id)
        {
            StackPanel stackPanel = new StackPanel()
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5E687C")),
                Height = 100,
                Margin = new Thickness(5),
                Orientation = Orientation.Vertical
            };

            TextBlock loginTextBlock = new TextBlock()
            {
                FontFamily = new FontFamily("Malgun Gothic Semilight"),
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#78A5A3")),
                Text = "Логин пользователя: " + name,
                FontSize = 15,
                Margin = new Thickness(5)
            };
            stackPanel.Children.Add(loginTextBlock);

            ScrollViewer scrollViewer = new ScrollViewer()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(5, 5, 170, 5),
                Height = 67,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Foreground = Brushes.White,
                FontFamily = new FontFamily("Malgun Gothic Semilight")
            };
            TextBlock messageTextBlock = new TextBlock()
            {
                TextWrapping = TextWrapping.Wrap,
                FontFamily = new FontFamily("Malgun Gothic Semilight"),
                Text = message
            };
            scrollViewer.Content = messageTextBlock;
            stackPanel.Children.Add(scrollViewer);

            StackPanel buttonStackPanel = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(-20, -105, 8, 0),
                VerticalAlignment = VerticalAlignment.Center
            };

            Button executeButton = new Button()
            {
                Content = "Подтвердить",
                Command = new CommandAcceptUser(),
                CommandParameter = id,
                Style = (Style)Application.Current.Resources["StartBtn"],
            };
            buttonStackPanel.Children.Add(executeButton);

            Button secondButton = new Button()
            {
                Content = "Отменить",
                Style = (Style)Application.Current.Resources["StartBtn"],
                Command = new CommandNotAcceptUser(),
                CommandParameter = id,
            };
            buttonStackPanel.Children.Add(secondButton);

            stackPanel.Children.Add(buttonStackPanel);

            return stackPanel;
        }
    }
}
