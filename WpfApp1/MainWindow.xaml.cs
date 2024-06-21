using System.Text;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        public DateTime _now = DateTime.Now;
        /// <summary>
        /// 現在の日付をリアルタイムで表示
        /// </summary>
        public string Now => _now.ToShortDateString();

        private Task? _delayAction = null;

        public MainWindow()
        {
            _delayAction = new Task(() =>
            {
                var tomorrow = _now.AddDays(1).Date;
                var interval = tomorrow - _now;
                Task.Delay(interval);
                _now = DateTime.Now;
            });
            _delayAction?.Start();

            InitializeComponent();
        }
        public class Time
        {
            public Time()
            {
                this.Date = DateTime.Today;
            }
            public DateTime Date { get; set; }
        }

        public void Dispose()
        {
            _delayAction?.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window1();
            win.ShowDialog();
        }
    }
}