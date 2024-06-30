using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using WPFToDoList.Data;
using WPFToDoList.Service;

namespace WPFToDoList.ViewModel
{
    public class AddTaskViewModel : BindableBase, INavigationAware
    {
        public AddTaskViewModel() { }

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

        public void AddTaskCommand_Execute(object parameter)
        {
            try
            {

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
