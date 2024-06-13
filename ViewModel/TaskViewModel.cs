using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFToDoList.Model;
using WPFToDoList.Service;
using System.Collections.ObjectModel;
using LiveCharts.Wpf;


namespace WPFToDoList.ViewModel
{
    /// <summary>
    /// ViewModel层
    /// </summary>
    public class TaskViewModel : BindableBase, INavigationAware
    {
        private readonly DependencyObject _myDependencyObject;

        public TaskViewModel()
        {
            _myDependencyObject = new DependencyObject();
            LbNowTime=DateTime.Now;
            SeriesCollection = new ObservableCollection<Series>();
            InitializeChart();
        }

        public static readonly DependencyProperty LbNowTimeProperty =
            DependencyProperty.Register("LbNowTime", typeof(DateTime), typeof(DependencyObject));

        // 创建属性的公开访问器
        public DateTime LbNowTime
        {
            get { return (DateTime)_myDependencyObject.GetValue(LbNowTimeProperty); }
            set { _myDependencyObject.SetValue(LbNowTimeProperty, value); }
        }

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
            return taskService.GetTaskData(Data.OptionType.offlineType);
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
