using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using TaskWave.Commands;
using TaskWave.DataBase;
using System.Diagnostics;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows;
using Path = System.IO.Path;
using Image = System.Windows.Controls.Image;
using System.Web; // для .NET Framework
using TaskWave.Pages.SnadartUser.Ready_SendTask;
using System.Reflection;
using TaskWave.Pages.Manager.SendTaskCheck;

namespace TaskWave.Pages.SnadartUser.AddFiles
{
    public class ViewModelAddFiles : InterfaceViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private myContext context;
        private Classes.Tasks task;
        private Classes.ReadyTask readyTask;
        private Classes.SendTasks sendTask;
        private WrapPanel wp;
        private string istype;
        private bool isTrue;
        public ViewModelAddFiles(int id, string type, WrapPanel nameWr, bool isTrue = false)
        {
            this.isTrue = isTrue;
            context = new();
            this.wp = nameWr;
            this.istype = type;
            switch (type)
            {
                case "sendTask":
                    foreach (var a in context.sendTasks)
                    {
                        if (a.id == id)
                        {
                            sendTask = a;
                            break;
                        }
                    }
                    break;

                case "checkTask":
                    foreach (var a in context.sendTasks)
                    {
                        if (a.id == id)
                        {
                            sendTask = a;
                            break;
                        }
                    }
                    break;

                case "readyTask":
                    foreach (var a in context.readyTasks)
                    {
                        if (a.id == id)
                        {
                            readyTask = a;
                            break;
                        }
                    }
                    break;

            }
        }

        private MyUserCommand addFiles;
        public MyUserCommand AddFiles
        {
            get
            {
                return addFiles ?? (addFiles = new MyUserCommand(pbj =>
                {
                    int count = 0;
                    if (readyTask != null)
                    {
                        foreach (var a in context.documentTasks)
                        {
                            if (readyTask.TaskId == a.idTask)
                            {
                                addPhToFile(a.title, a.content);
                                count++;
                            }
                        }

                    }
                  
                    else if (sendTask != null)
                    {
                        foreach (var a in context.documentTasks)
                        {
                            if (a.idTask == sendTask.TaskId)
                            {
                                addPhToFile(a.title, a.content);
                                count++;
                            }
                        }
                    }
                  
                    if (count == 0)
                    {
                        addToPanelTitle();
                    }
                }));


            }
        }


        private void addToPanelTitle()
        {
            var tb = new TextBlock();
            tb.Text = "Файлы отсутствуют";
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            tb.FontSize = 21;
            tb.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            tb.FontFamily = new FontFamily("Malgun Gothic Semilight");

            wp.Children.Add(tb);
        }

        private void addPhToFile(string fileName, byte[] fileContent)
        {
            // Создаем временный файл в папке TEMP
            string tempFilePath = Path.Combine(Path.GetTempPath(), fileName);
            File.WriteAllBytes(tempFilePath, fileContent);

            // Определяем тип файла и открываем его
            string extension = Path.GetExtension(fileName).ToLower();
            Image image = new Image();
            image.Stretch = Stretch.UniformToFill;
            image.MaxWidth = 50;
            image.MaxHeight = 50;

            switch (extension)
            {
                case ".doc":
                case ".docx":
                    // файл Microsoft Word
                    image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\microsoft-word-90.png"));
                    break;

                case ".xls":
                case ".xlsx":
                    // файл Microsoft Excel
                    image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\microsoft-excel-90.png"));
                    break;

                case ".pdf":
                    // файл Adobe Acrobat Reader
                    image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\pdf-90.png"));
                    break;

                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".bmp":
                    image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\image-90.png"));
                    break;

                case ".txt":
                    image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\txt-90.png"));
                    break;

                default:
                    image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\file-90.png"));
                    break;
            }

            // Создаем textBlock
            TextBlock textBlock = new TextBlock();
            textBlock.Margin = new Thickness(5, 3, 0, 0);
            textBlock.Inlines.Add(new Run(Path.GetFileName(fileName)));
            textBlock.Foreground = Brushes.White;
            textBlock.Cursor = new Cursor("D:\\studing\\4_semestr\\Course_project\\Cursor\\Red Neon\\normal_select.cur");

            StackPanel stack = new();
            stack.Tag = fileName;
            stack.Cursor = new Cursor("D:\\studing\\4_semestr\\Course_project\\Cursor\\Red Neon\\link_select.cur");
            stack.Children.Add(image);
            stack.Children.Add(textBlock);
            stack.MouseLeftButtonDown += startPr;

            wp.Children.Add(stack);
        }

        private void startPr(object sender, RoutedEventArgs e)
        {
            string nameFile = (sender as StackPanel).Tag as string;
            foreach(var a in context.documentTasks)
            {
                if(a.title == nameFile)
                {
                    OpenFile(a.title, a.content);
                }
            }
        }

        private MyUserCommand goBack;
        public MyUserCommand GoBack
        {
            get
            {
                return goBack ?? (goBack = new MyUserCommand(obj =>
                {
                    if(isTrue)
                    {
                        Classes.NavigationService.mainFr.Navigate(new SendTaskCheck(sendTask.TaskId));
                        return;
                    }

                    if(sendTask != null)
                    {
                        Classes.NavigationService.mainFr.Navigate(new ReadyAndSendTaskInf(sendTask.TaskId));
                        return;
                    }
                    else
                    {
                        Classes.NavigationService.mainFr.Navigate(new ReadyAndSendTaskInf(readyTask.TaskId));
                        return;
                    }
                }));
            }
        }

        private void OpenFile(string fileName, byte[] fileContent)
        {
            // Создаем временный файл в папке TEMP
            string tempFilePath = Path.Combine(Path.GetTempPath(), fileName);
            File.WriteAllBytes(tempFilePath, fileContent);

            // Определяем тип файла и открываем его
            string extension = Path.GetExtension(fileName).ToLower();

            switch (extension)
            {

                case ".doc":
                case ".docx":
                    // Открываем файл с помощью Microsoft Word
                    var wordPath = @"C:\Program Files (x86)\Microsoft Office\root\Office16\WINWORD.EXE";
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = wordPath,
                        Arguments = tempFilePath,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    });
                    break;

                case ".xls":
                case ".xlsx":
                    // Открываем файл с помощью Microsoft Excel
                    var excelPath = @"C:\Program Files (x86)\Microsoft Office\root\Office16\EXCEL.EXE";
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = excelPath,
                        Arguments = tempFilePath,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    });
                    break;

                case ".pdf":
                    // Открываем файл с помощью Adobe Acrobat Reader
                    var pdfPath = @"C:\Program Files (x86)\Adobe\Acrobat DC\Acrobat\Acrobat.exe";
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = pdfPath,
                        Arguments = $"/A \"page=1\" \"{tempFilePath}\"",
                        UseShellExecute = false
                    });
                    break;

                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".bmp":
                    BitmapImage bitmapImage = new BitmapImage();
                    using (MemoryStream ms = new MemoryStream(fileContent))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = ms;
                        bitmapImage.EndInit();
                    }

                    System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                    image.Source = bitmapImage;
                    image.Stretch = Stretch.Uniform;

                    Window window = new Window();
                    window.Title = "Image";
                    window.Icon = new BitmapImage(new Uri(@"D:\studing\4_semestr\Course_project\image\logo.png"));
                    window.Background = Brushes.Transparent;
                    window.Content = image;
                    window.ShowDialog();
                    break;

                case ".txt":
                    Process.Start("C:\\Users\\aleks\\Notepad++\\notepad++.exe", tempFilePath);
                    break;

                default:
                    // Открываем файл с помощью проводника Windows
                    Process.Start("explorer.exe", $"/select,\"{tempFilePath}\"");
                    break;
            }
        }
    }
}
