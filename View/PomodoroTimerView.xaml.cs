using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using WPFToDoList.ViewModel;

namespace WPFToDoList.View
{
    /// <summary>
    /// PomodoroTimer.xaml 的交互逻辑
    /// </summary>
    public partial class PomodoroTimerView : Window
    {
        public PomodoroTimerView()
        {
            InitializeComponent();
        }

        public PomodoroTimerView(TaskViewModel taskViewModel) 
        {
            InitializeComponent();
            InitializeTimer();
            leftTime = TimeSpan.FromMinutes(1);
            mainViewModel= taskViewModel;
            mainViewModel.SetVisible(false);
        }

        private DispatcherTimer _timer;
        private bool _isPaused = true;
        private TimeSpan leftTime;
        private bool _isFinish = false;
        private TaskViewModel mainViewModel;


        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!_isPaused)
            {
                leftTime -= TimeSpan.FromSeconds(1);
                timerText.Text = leftTime.ToString(@"mm\:ss");
                if (leftTime == TimeSpan.FromSeconds(0))
                {
                    _timer.Stop();
                    timerEllipse.Fill = Brushes.LimeGreen;
                    timerText.Text = "Good job!";
                    leftTime = TimeSpan.FromMinutes(1);
                    pauseResumeButton.Content = "Resume";
                    _isPaused = true;
                    _isFinish = true;
                }
            }
        }

        private void PauseResumeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isPaused)
            {
                _timer.Start();
                _isPaused = false;
                pauseResumeButton.Content = "Resume";
                if (_isFinish)
                {
                    timerEllipse.Fill = Brushes.SkyBlue;
                    pauseResumeButton.Content = "Pause";
                }
            }
            else
            {
                _timer.Stop();
                _isPaused = true;
                pauseResumeButton.Content = "Pause";
            }
        }

        private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            if (_isPaused)
            {
                timerEllipse.Stroke = Brushes.Black;
                timerEllipse.StrokeThickness = 5;
            }
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            if (_isPaused)
            {
                timerEllipse.Stroke = null;
                timerEllipse.StrokeThickness = 0;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainViewModel.SetVisible(true);
            this.DialogResult = true;
        }
    }
}
