using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DNPAssignment6
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Forms.OpenFileDialog aDialog = new System.Windows.Forms.OpenFileDialog();

        BackgroundWorker backgroundWorker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if ((MediaElement1.Source != null) && (MediaElement1.NaturalDuration.HasTimeSpan))
            {
                mp3PlayingProgressBar.Minimum = 0;
                mp3PlayingProgressBar.Maximum = MediaElement1.NaturalDuration.TimeSpan.TotalSeconds;
                mp3PlayingProgressBar.Value = MediaElement1.Position.TotalSeconds;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            aDialog.ShowDialog();
            MediaElement1.Source = new Uri(aDialog.FileName);
            PlayingLabel.Content = "Playing: " + aDialog.SafeFileName;
            MediaElement1.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MediaElement1.Play();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MediaElement1.Pause();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MediaElement1.Stop();
        }

        private void MediaElement1_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Media loading unsuccessful. " +
            e.ErrorException.Message);
        }
    }
}
