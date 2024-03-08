using System.Windows.Controls;
using System.Windows.Media;
using wpf_panel;

namespace wpf_demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Grid.RowDefinitions.Add(new RowDefinition());

            Grid.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.ColumnDefinitions.Add(new ColumnDefinition());

            Canvas canvas = new Canvas()
            {
                Width = 100,
                Height = 50,
                Background = Brushes.Blue,
            };
            Grid.Children.Add(canvas);

            WpfCanvas wpfCanvas = new WpfCanvas()
            {
                Width = 100,
                Height = 50,
                Background = Brushes.Red,
            };
            Grid.Children.Add(wpfCanvas);

            Grid.SetRow(canvas, 0);
            Grid.SetColumn(canvas, 0);

            Grid.SetRow(wpfCanvas, 0);
            Grid.SetColumn(wpfCanvas, 1);
        }
    }
}