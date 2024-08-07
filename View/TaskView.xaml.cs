﻿using Prism.Regions;
using System;
using System.Collections.Generic;
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

namespace WPFToDoList.View
{
    /// <summary>
    /// TaskView.xaml 的交互逻辑
    /// </summary>
    public partial class TaskView : Window
    {
        public TaskView()
        {
            InitializeComponent();
            IRegionManager regionManager = RegionManager.GetRegionManager(this);
            this.DataContext = new TaskViewModel(regionManager);
            this.IsEnabledChanged += taskView_IsEnabledChanged;
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.Key) && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void taskView_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsEnabled)
                this.Show();
            else this.Hide();
        }
    }
}
