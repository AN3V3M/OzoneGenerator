using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OzoneGenerator
{
    public partial class MainWindow : Window
    {
        private OzoneGrid ozoneGrid;
        private const int GridSize = 27;
        private Button[,] buttons = new Button[GridSize, GridSize];

        public MainWindow()
        {
            InitializeComponent();
            ozoneGrid = new OzoneGrid();
            InitializeGrid();
            UpdateGrid();
        }

        private void InitializeGrid()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Button btn = new Button
                    {
                        Width = 20,
                        Height = 20,
                        Margin = new Thickness(1)
                    };
                    btn.Click += (s, e) => Cell_Click(i, j);
                    buttons[i, j] = btn;
                    OzoneGrid.Children.Add(btn);
                }
            }
        }

        private void UpdateGrid()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    int value = ozoneGrid.GetParcel(i, j);
                    buttons[i, j].Content = value > 0 ? value.ToString() : "";

                    if (value == -1)
                        buttons[i, j].Background = Brushes.Gray;
                    else if (value == 0)
                        buttons[i, j].Background = Brushes.White;
                    else
                        buttons[i, j].Background = Brushes.Blue;
                }
            }
        }

        private void Cell_Click(int row, int col)
        {
            ozoneGrid.PointClean(row, col);
            UpdateGrid();
        }

        private void NextDayButton_Click(object sender, RoutedEventArgs e)
        {
            ozoneGrid.OzoneClean(0, 0);
            UpdateGrid();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ozoneGrid.Restart();
            UpdateGrid();
        }
    }
}
