using LiveCharts;
using LiveCharts.Wpf;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        #region 初始化
        public TaskViewModel()
        {
            CurrentUserName = "帅气的卡夫卡";
            InitializeTimer();
            TaskList = GetTaskData();
            CurrentPageNumber = 1;
            Items = new ObservableCollection<TaskModel>(GetPageItems(TaskList, _currentPageNumber, PageSize));
            SaveCommand = new RelayCommand(SaveCommand_Execute);
            SelectTask = new TaskModel();
            IsHide=true;
        }

        public TaskService taskService = new TaskService();
        /// <summary>
        /// 查询任务数据
        /// </summary>
        /// <returns></returns>
        public List<TaskModel> GetTaskData()
        {
            var res = taskService.GetTaskData(Data.OptionType.onLineType);
            TotalCount = res.Count;
            tmpTaskList = res;
            InitializeChart();
            return res;
        }
        #endregion

        #region 定时器显示时间日期
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

        #region 分页逻辑
        private int _pageSize = 15;
        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (value < 1 || value > 20)

                    SetProperty(ref _pageSize, 15);
                else
                    SetProperty(ref _pageSize, value);
            }
        }

        public ObservableCollection<TaskModel> Items { get; set; } // 绑定到ListView的数据源

        // 总项数，用于计算总页数
        public int TotalCount { get; set; }

        private RelayCommand pageChangedCommand;
        /// <summary>
        /// 保存
        /// </summary>
        public RelayCommand PageChangedCommand
        {
            get
            {
                if (pageChangedCommand == null)
                    pageChangedCommand = new RelayCommand(PageChangedCommand_Execute);
                return pageChangedCommand;
            }
            set { pageChangedCommand = value; }
        }

        public void PageChangedCommand_Execute(object parameter)
        {
            int pageNo = Convert.ToInt32(parameter);
            PageChanged(pageNo);
            //CurrentPageNumber = pageNo;
        }

        // 翻页方法
        private void PageChanged(int pageNumber)
        {
            if (pageNumber > 0 && pageNumber <= Math.Max(TotalCount / PageSize, 1))
            {
                Items.Clear();
                var pageItems = GetPageItems(TaskList, pageNumber, PageSize);
                foreach (var item in pageItems)
                {
                    Items.Add(item);
                }
                CurrentPageNumber = pageNumber;
            }
        }

        // 根据当前页码和每页显示的项数获取数据
        private IEnumerable<TaskModel> GetPageItems(List<TaskModel> allItems, int pageNumber, int pageSize)
        {
            return allItems.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        private int _currentPageNumber;
        /// <summary>
        /// 当前页数
        /// </summary>
        public int CurrentPageNumber
        {
            get { return _currentPageNumber; }
            set
            {
                SetProperty(ref _currentPageNumber, value);
            }
        }

        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        #endregion

        #region 常规命令
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
                    int res = taskService.UpdateTaskData(OptionType.onLineType, SelectTask);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(@"更新失败,提示信息:{0}", ex.Message));
            }
            finally
            {
                QueryCommand_Execute(null);
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
                    int res = taskService.DeleteTaskData(OptionType.onLineType, SelectTask);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(@"删除失败,提示信息:{0}", ex.Message));
            }
            finally
            {
                TaskList.Remove(SelectTask);
                tmpTaskList.Remove(SelectTask);
                InitializeChart();
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
            AddTaskView addTaskView = new AddTaskView(this);
            addTaskView.Show();
        }

        private RelayCommand queryCommand;
        /// <summary>
        /// 查询
        /// </summary>
        public RelayCommand QueryCommand
        {
            get
            {
                if (queryCommand == null)
                    queryCommand = new RelayCommand(QueryCommand_Execute);
                return queryCommand;
            }
            set { queryCommand = value; }
        }

        private void QueryCommand_Execute(object obj)
        {
            TaskList = GetTaskData();
            TotalCount = TaskList.Count;
            PageChangedCommand_Execute(CurrentPageNumber);
        }

        private RelayCommand queryCommandUndo;
        /// <summary>
        /// 查询未开始
        /// </summary>
        public RelayCommand QueryCommandUndo
        {
            get
            {
                if (queryCommandUndo == null)
                    queryCommandUndo = new RelayCommand(QueryCommandUndo_Execute);
                return queryCommandUndo;
            }
            set { queryCommandUndo = value; }
        }

        private void QueryCommandUndo_Execute(object obj)
        {
            List<TaskModel> filterTasks = tmpTaskList.AsEnumerable().Where(o => o.TaskStatus.Equals("0")).ToList();
            TaskList = filterTasks;
            TotalCount = filterTasks.Count;
            PageChangedCommand_Execute(CurrentPageNumber);
        }

        private RelayCommand queryCommandDone;
        /// <summary>
        /// 查询已完成
        /// </summary>
        public RelayCommand QueryCommandDone
        {
            get
            {
                if (queryCommandDone == null)
                    queryCommandDone = new RelayCommand(QueryCommandDone_Execute);
                return queryCommandDone;
            }
            set { queryCommandDone = value; }
        }

        private void QueryCommandDone_Execute(object obj)
        {
            List<TaskModel> filterTasks = tmpTaskList.AsEnumerable().Where(o => o.TaskStatus.Equals("2")).ToList();
            TaskList = filterTasks;
            TotalCount = filterTasks.Count;
            PageChangedCommand_Execute(CurrentPageNumber);
        }

        private RelayCommand queryCommandDoing;
        /// <summary>
        /// 查询未进行中
        /// </summary>
        public RelayCommand QueryCommandDoing
        {
            get
            {
                if (queryCommandDoing == null)
                    queryCommandDoing = new RelayCommand(QueryCommandDoing_Execute);
                return queryCommandDoing;
            }
            set { queryCommandDoing = value; }
        }

        private void QueryCommandDoing_Execute(object obj)
        {
            List<TaskModel> filterTasks = tmpTaskList.AsEnumerable().Where(o => o.TaskStatus.Equals("1")).ToList();
            TaskList = filterTasks;
            TotalCount = filterTasks.Count;
            PageChangedCommand_Execute(CurrentPageNumber);
        }

        private RelayCommand pomoCommand;
        public RelayCommand PomoCommand
        {
            get
            {
                if (pomoCommand == null)
                    pomoCommand = new RelayCommand(PomoCommand_Execute);
                return pomoCommand;
            }
            set { pomoCommand = value; }
        }

        private void PomoCommand_Execute(object obj)
        {
            PomodoroTimerView view = new PomodoroTimerView(this);
            if (view.ShowDialog() == true)
            {
                //SetVisible(true);
            }
        }

        public void SetVisible(bool Status)
        {
            IsHide = Status;
        }
        #endregion

        #region 常规变量
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
        /// <summary>
        /// 缓存数据
        /// </summary>
        public List<TaskModel> tmpTaskList;

        /// <summary>
        /// 是否隐藏主页面
        /// </summary>
        public bool isHide;
        public bool IsHide
        {
            get { return isHide; }
            set { SetProperty(ref isHide, value); }
        }

        #endregion

        #region 统计图表

        private void InitializeChart()
        {
            SeriesCollection = new SeriesCollection
            {
                 new ColumnSeries
                 {
                     Title = "数量",
                     Values = new ChartValues<double>(GetChartArr())
                 }
            };
            XAxisLabels.Clear();
            XAxisLabels.Add("未开始");
            XAxisLabels.Add("进行中");
            XAxisLabels.Add("已完成");
        }
        public ObservableCollection<string> XAxisLabels { get; set; } = new ObservableCollection<string>();

        private double[] GetChartArr()
        {
            int countUndo = tmpTaskList.AsEnumerable().Where(o => o.TaskStatus.Equals("0")).Count();
            int countDoing = tmpTaskList.AsEnumerable().Where(o => o.TaskStatus.Equals("1")).Count();
            int countDone = tmpTaskList.AsEnumerable().Where(o => o.TaskStatus.Equals("2")).Count();
            ShowTotalMessage = string.Format("全部任务:{0}个", tmpTaskList.Count);
            ShowTotalMessage0 = string.Format("未完成任务:{0}个", countUndo);
            ShowTotalMessage1 = string.Format("进行中任务:{0}个", countDoing);
            ShowTotalMessage2 = string.Format("已完成任务:{0}个", countDone);
            return new double[] { countUndo, countDoing, countDone };
        }

        private SeriesCollection seriesCollection;
        public LiveCharts.SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set
            {
                SetProperty(ref seriesCollection, value);
            }
        }

        public Axis XAxis { get; set; }
        public Axis YAxis { get; set; }

        private string showTotalMessage;
        public string ShowTotalMessage
        {
            get { return showTotalMessage; }
            set { SetProperty(ref showTotalMessage, value); }
        }

        private string showTotalMessage0;
        public string ShowTotalMessage0
        {
            get { return showTotalMessage0; }
            set { SetProperty(ref showTotalMessage0, value); }
        }

        private string showTotalMessage1;
        public string ShowTotalMessage1
        {
            get { return showTotalMessage1; }
            set { SetProperty(ref showTotalMessage1, value); }
        }

        private string showTotalMessage2;
        public string ShowTotalMessage2
        {
            get { return showTotalMessage2; }
            set { SetProperty(ref showTotalMessage2, value); }
        }
        #endregion

        #region 页面导航
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
        #endregion

    }
}
