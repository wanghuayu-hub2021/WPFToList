﻿using LiveCharts.Wpf;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WPFToDoList.Data;
using WPFToDoList.Model;
using WPFToDoList.Service;
using WPFToDoList.View;


namespace WPFToDoList.ViewModel
{
    /// <summary>
    /// ViewModel层
    /// </summary>
    public class TaskViewModel : BindableBase, INavigationAware
    {
        private readonly DependencyObject _myDependencyObject;
        public TaskService TaskService = null;

        public TaskViewModel()
        {
            _myDependencyObject = new DependencyObject();
            SeriesCollection = new ObservableCollection<Series>();
            CurrentUserName = "帅气的卡夫卡";
            InitializeChart();
            InitializeTimer();
            TaskList = GetTaskData();
            SaveCommand = new RelayCommand(SaveCommand_Execute);
            TaskService = new TaskService();
            SelectTask = new TaskModel();
        }

        #region 定时器
        private DispatcherTimer _timer;

        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DayOfWeek = DateTime.Now.DayOfWeek;
            CurrentTime = DateTime.Now;
        }
        #endregion

        #region 变量 
        private RelayCommand saveCommand;
        /// <summary>
        /// 保存
        /// </summary>
        public RelayCommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new RelayCommand(SaveCommand_Execute);
                return saveCommand;
            }
            set { saveCommand = value; }
        }

        public void SaveCommand_Execute(object parameter)
        {
            try
            {
                if (SelectTask != null)
                {
                    int res = TaskService.UpdateTaskData(OptionType.onLineType, SelectTask);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(@"更新失败,提示信息:{0}", ex.Message));
            }
            finally
            {

            }
        }

        private RelayCommand deleteCommand;
        /// <summary>
        /// 删除
        /// </summary>
        public RelayCommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(DeleteCommand_Execute);
                return deleteCommand;
            }
            set { deleteCommand = value; }
        }

        public void DeleteCommand_Execute(object parameter)
        {
            try
            {
                if (SelectTask != null)
                {
                    int res = TaskService.DeleteTaskData(OptionType.onLineType, SelectTask);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(@"删除失败,提示信息:{0}", ex.Message));
            }
            finally
            {
                TaskList.Remove(SelectTask);
            }
        }

        private RelayCommand addCommand;
        /// <summary>
        /// 新增
        /// </summary>
        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand(AddCommand_Execute);
                return addCommand;
            }
            set { addCommand = value; }
        }

        public void AddCommand_Execute(object parameter)
        {
            AddTaskView addTaskView = new AddTaskView();
            addTaskView.Show();
        }

        private TaskModel selectTask;
        /// <summary>
        /// 选中任务行
        /// </summary>
        public TaskModel SelectTask
        {
            get { return selectTask; }
            set
            {
                selectTask = value; RaisePropertyChanged(nameof(SelectTask));
            }
        }

        /// <summary>
        /// 当前时间
        /// </summary>
        private DateTime currentTime;
        public DateTime CurrentTime
        {
            get { return currentTime; }
            set { SetProperty(ref currentTime, value); }
        }

        /// <summary>
        /// 星期几
        /// </summary>
        private DayOfWeek dayOfWeek;
        public DayOfWeek DayOfWeek
        {
            get { return dayOfWeek; }
            set { SetProperty(ref dayOfWeek, value); }
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        private string currentUserName;
        public string CurrentUserName
        {
            get { return currentUserName; }
            set { SetProperty(ref currentUserName, value); }
        }

        /// <summary>
        /// 任务数据
        /// </summary>
        private List<TaskModel> taskList;
        public List<TaskModel> TaskList
        {
            get { return taskList; }
            set { SetProperty(ref taskList, value); }
        }
        #endregion

        private ObservableCollection<Series> _seriesCollection;

        public ObservableCollection<Series> SeriesCollection
        {
            get { return _seriesCollection; }
            set
            {
                _seriesCollection = value;
            }
        }

        private void InitializeChart()
        {
            // 创建数据序列示例
            var series = new LineSeries
            {
                Title = "Sample Series"
            };

            // 添加到数据集合
            SeriesCollection.Add(series);
        }

        public TaskService taskService = new TaskService();

        public List<TaskModel> GetTaskData()
        {
            return taskService.GetTaskData(Data.OptionType.onLineType);
        }

        //需要继承INavigationAware接口，实现接口中三个方法
        //三个方法的执行顺序：
        //1.Main====>PageA
        //先执行Main页面的OnNavigatedFrom，再执行PageA页面的OnNavigatedTo
        //2.PageA====>PageA
        //OnNavigatedFrom()----->IsNavigationTarget()----->OnNavigatedTo()
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //每次重新导航时，是否重新创建当前PageBViewModel实例，
            //return true;时就不会再创建新的实例（不会再次运行当前PageBViewModel构造函数）
            return true;
        }

        /// <summary>
        /// // 从这个ViewModel导航离开时的逻辑
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// // 导航到此ViewModel时的逻辑
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
    }
}
