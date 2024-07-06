using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using System.Windows.Navigation;
using WPFToDoList.Data;
using WPFToDoList.Model;
using WPFToDoList.Service;

namespace WPFToDoList.ViewModel
{
    public class AddTaskViewModel : BindableBase, INavigationAware
    {
        TaskService taskService;

        public AddTaskViewModel()
        {
            taskService = new TaskService();
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            KeepAlive = true;
        }

        private string taskDescription;
        /// <summary>
        /// 任务描述
        /// </summary>
        public string TaskDescription
        {
            get { return taskDescription; }
            set
            {
                taskDescription = value; RaisePropertyChanged(nameof(TaskDescription));
            }
        }

        private DateTime startDate;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value; RaisePropertyChanged(nameof(StartDate));
            }
        }

        private DateTime endDate;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value; RaisePropertyChanged(nameof(EndDate));
            }
        }

        private string tags;
        /// <summary>
        /// 标签
        /// </summary>
        public string Tags
        {
            get { return tags; }
            set
            {
                tags = value; RaisePropertyChanged(nameof(Tags));
            }
        }

        private RelayCommand addTaskCommand;
        /// <summary>
        /// 新增
        /// </summary>
        public RelayCommand AddTaskCommand
        {
            get
            {
                if (addTaskCommand == null)
                    addTaskCommand = new RelayCommand(AddTaskCommand_Execute);
                return addTaskCommand;
            }
            set { addTaskCommand = value; }
        }

        private bool keepAlive;
        /// <summary>
        /// 是否关闭当前窗口
        /// </summary>
        public bool KeepAlive
        {
            get { return keepAlive; }
            set { keepAlive = value; RaisePropertyChanged(nameof(KeepAlive)); }
        }

        public void AddTaskCommand_Execute(object parameter)
        {
            try
            {
                TaskModel task = new TaskModel();

                task.TaskDescription = this.TaskDescription;
                task.StartDate = this.StartDate.ToString("yyyyMMdd");
                task.EndDate = this.EndDate.ToString("yyyyMMdd");
                task.CompletionDate = "20990101";
                task.IsRecurring = "0";
                task.TaskStatus = "0";
                task.TaskType = "1";
                task.Tags = this.Tags;
                taskService.SaveTaskData(OptionType.onLineType, task);
                KeepAlive = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(@"新增任务失败,提示信息:{0}", ex.Message));
            }
            finally
            {
            }
        }

        private RelayCommand cancelTaskCommand;
        /// <summary>
        /// 新增
        /// </summary>
        public RelayCommand CancelTaskCommand
        {
            get
            {
                if (cancelTaskCommand == null)
                    cancelTaskCommand = new RelayCommand(CancelTaskCommand_Execute);
                return cancelTaskCommand;
            }
            set { cancelTaskCommand = value; }
        }

        NavigationService navigationService;
        public void CancelTaskCommand_Execute(object parameter)
        {
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
