using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFToDoList.ViewModel;
using Prism.Mvvm;
using Prism.Regions;

namespace WPFToDoList.View
{
    /// <summary>
    /// AddTaskView.xaml 的交互逻辑
    /// </summary>
    public partial class AddTaskView : Window
    {
        public AddTaskView(TaskViewModel taskViewModel)
        {
            InitializeComponent();
            this.DataContext = new AddTaskViewModel();
            this.IsEnabledChanged += delegate
            {
                if (!this.IsEnabled)
                    this.Close();
            };
            this.Closing += delegate
            {
                taskViewModel.QueryCommand.Execute(this);
            };
        }

    }
}
