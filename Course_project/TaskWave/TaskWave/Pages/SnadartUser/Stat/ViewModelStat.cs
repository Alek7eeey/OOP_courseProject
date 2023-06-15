using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.DataBase;

namespace TaskWave.Pages.SnadartUser.Stat
{
    public class ViewModelStat : InterfaceViewModel
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

        public ViewModelStat()
        {
            // Получение данных о заданиях и датах
            List<int> taskCounts = GetTaskCounts(); // Здесь получите данные о количестве заданий
            List<DateTime> dateList = GetDates(); // Здесь получите список дат
            TaskCount = new ChartValues<int>(taskCounts);
            Dates = dateList.Select(date => date.ToString("dd.MM.yyyy")).ToList();
        }

        private ChartValues<int> taskCount;
        public ChartValues<int> TaskCount
        {
            get { return taskCount; }
            set
            {
                taskCount = value;
                OnPropertyChanged(nameof(TaskCount));
            }
        }

        private List<string> dates;
        public List<string> Dates
        {
            get { return dates; }
            set
            {
                dates = value;
                OnPropertyChanged(nameof(Dates));
            }
        }

        #region command
        private List<int> GetTaskCounts()
        {
            myContext context = new();
            var taskCounts = context.readyTasks
            .Where(task => task.nameOfResponse == Classes.activeUser.user.login) // Фильтрация по имени создателя задачи
            .GroupBy(task => task.dateComplete.Date) // Группировка задач по дате (без учета времени)
            .Select(group => new { Date = group.Key, Count = group.Count() }) // Выборка даты и количества задач
            .OrderBy(entry => entry.Date) // Сортировка по возрастанию даты
            .Select(entry => entry.Count) // Выборка только количества задач
            .ToList();

            return taskCounts;
        }

        private List<DateTime> GetDates()
        {
            myContext context = new();
            var dates = context.readyTasks
                 .Where(task => task.nameOfResponse == Classes.activeUser.user.login) // Фильтрация по имени создателя задачи
                .Select(task => task.dateComplete.Date) // Выборка даты (без учета времени)
                .Distinct() // Удаление повторяющихся дат
                .OrderBy(date => date) // Сортировка по возрастанию даты
                .ToList();

            return dates;
        }
        #endregion
    }
}
