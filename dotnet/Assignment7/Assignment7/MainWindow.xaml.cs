using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Assignment7
{
    public partial class MainWindow : Window
    {
        private Random m_Random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            Label1.Content = await UpdateLabelAsync("Starting..");

            Task delay = Task.Delay(8000);
            Task t1 = HeavyWorkAsynk("Work 1");
            Task t2 = HeavyWorkAsynk("Work 2");
            Task t3 = HeavyWorkAsynk("Work 3");
            Task workTasks = Task.WhenAll(t1, t2, t3);

            Task timeoutTask = await Task.WhenAny(workTasks, delay);
            if(timeoutTask.Equals(delay))
            {
                Console.WriteLine("Delay {0}, {1}, {2}", timeoutTask.ToString(), timeoutTask.Id, timeoutTask.Status);
                Label1.Content = await UpdateLabelAsync("Work in progress..");
            }
            await workTasks;
            Console.WriteLine("STATUS W1 = {0}, W2 = {1}, W3 = {2}", t1.Status, t2.Status, t3.Status);

            //Put a 2 second delay so we can see the label updates to Work in Progress. Usually it updates to fast to see with the normal eye. It can also be seen in the logs.
            await Task.Delay(2000);
            Label1.Content = await UpdateLabelAsync("Completed");
        }

        public void HeavyWork(string name)
        {
            double secondsToStep = m_Random.NextDouble() * 10;
            Console.WriteLine("STARTING HEAVY WORK WITH NAME {0} and {1} SECONDS", name, secondsToStep);
            Thread.Sleep(TimeSpan.FromSeconds(secondsToStep));
        }

        public Task HeavyWorkAsynk(string name)
        {
            return Task.Run(() => HeavyWork(name));
        }
        private async Task<string> UpdateLabelAsync(string name)
        {
            Console.WriteLine("MAKING THE LABEL {0}", name);
            return await Task.Factory.StartNew(() => name);
        }
    }
}
