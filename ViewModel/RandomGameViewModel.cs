using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFToDoList.View;

namespace WPFToDoList.ViewModel
{
    /// <summary>
    /// 练习多线程的小游戏
    /// </summary>
    class RandomGameViewModel : BindableBase, INavigationAware
    {
        TaskViewModel viewModel;

        public RandomGameViewModel(TaskViewModel viewModel)
        {
            this.viewModel = viewModel;
            Param11 = 1;
            Param12 = 1;
            Param21 = 1;
            Param22 = 1;
            Param31 = 1;
            Param32 = 1;
            Param41 = 1;
            Param42 = 1;
            Answer1 = 0;
            Answer2 = 0;
            Answer3 = 0;
            Answer4 = 0;
            DoneCount = 0;
            DoneSort = "";
        }

        private RelayCommand radioBtnGameCommand;
        /// <summary>
        /// Check
        /// </summary>
        public RelayCommand RadioBtnGameCommand
        {
            get
            {
                if (radioBtnGameCommand == null)
                    radioBtnGameCommand = new RelayCommand(RadioBtnGameCommand_Execute);
                return radioBtnGameCommand;
            }
            set { radioBtnGameCommand = value; }
        }

        private void RadioBtnGameCommand_Execute(object obj)
        {
            SelectedValue = Convert.ToInt32(SelectedValue);
        }

        private RelayCommand startGameCommand;
        /// <summary>
        /// 多线程游戏
        /// </summary>
        public RelayCommand StartGameCommand
        {
            get
            {
                if (startGameCommand == null)
                    startGameCommand = new RelayCommand(StartGameCommand_Execute);
                return startGameCommand;
            }
            set { startGameCommand = value; }
        }

        private void StartGameCommand_Execute(object obj)
        {
            GameStart();
        }

        private void GameStart()
        {
            UpdateDoneCount("resume");
            switch (SelectedValue)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    Task task1 = Task.Run(new Action(() => Add(param11, param12, "1")));
                    Task task2 = Task.Run(new Action(() => Add(param21, param22, "2")));
                    Task task3 = Task.Run(new Action(() => Add(param31, param32, "3")));
                    Task task4 = Task.Run(new Action(() => Add(param41, param42, "4")));
                    Task.WaitAll(task1, task2, task3, task4);
                    break;
                default:
                    break;
            }
        }

        private double Add(double param1, double param2, string tag)
        {
            double ans = 0;
            for (int i = 0; i < 10; i++)
            {
                ans += (param1 + param2);
            }
            switch (tag)
            {
                case "1":
                    Answer1 = ans;
                    break;
                case "2":
                    Answer2 = ans;
                    break;
                case "3":
                    Answer3 = ans;
                    break;
                case "4":
                    Answer4 = ans;
                    break;
                default:
                    break;
            }
            UpdateDoneCount(tag);
            return ans;
        }
        public static readonly object locker = new object();

        private void UpdateDoneCount(string num)
        {
            lock (locker)
            {
                if (num.Equals("resume"))
                {
                    DoneCount = 0;
                    DoneSort = "";
                }
                else
                {
                    DoneCount += 1;
                    DoneSort += num;
                }
            }
        }

        private int _selectedValue;
        public int SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                SetProperty(ref _selectedValue, value);
            }
        }

        private double param11;
        public double Param11
        {
            get { return param11; }
            set { SetProperty(ref param11, value); }
        }

        private double param12;
        public double Param12
        {
            get { return param12; }
            set { SetProperty(ref param12, value); }
        }


        private double answer1;
        public double Answer1
        {
            get { return answer1; }
            set { SetProperty(ref answer1, value); }
        }

        private double param21;
        public double Param21
        {
            get { return param21; }
            set { SetProperty(ref param21, value); }
        }

        private double param22;
        public double Param22
        {
            get { return param22; }
            set { SetProperty(ref param22, value); }
        }


        private double answer2;
        public double Answer2
        {
            get { return answer2; }
            set { SetProperty(ref answer2, value); }
        }

        private double param31;
        public double Param31
        {
            get { return param31; }
            set { SetProperty(ref param31, value); }
        }

        private double param32;
        public double Param32
        {
            get { return param32; }
            set { SetProperty(ref param32, value); }
        }


        private double answer3;
        public double Answer3
        {
            get { return answer3; }
            set { SetProperty(ref answer3, value); }
        }

        private double param41;
        public double Param41
        {
            get { return param41; }
            set { SetProperty(ref param41, value); }
        }

        private double param42;
        public double Param42
        {
            get { return param42; }
            set { SetProperty(ref param42, value); }
        }


        private double answer4;
        public double Answer4
        {
            get { return answer4; }
            set { SetProperty(ref answer4, value); }
        }

        private double doneCount;
        public double DoneCount
        {
            get { return doneCount; }
            set { SetProperty(ref doneCount, value); }
        }

        private string doneSort;
        public string DoneSort
        {
            get { return doneSort; }
            set { SetProperty(ref doneSort, value); }
        }


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
