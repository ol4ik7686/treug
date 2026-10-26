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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace treug
{ 
 public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        foreach (char c in e.Text)
        {
            if (!char.IsDigit(c))
            {
                e.Handled = true;
                return;
            }
        }
    }

    private void BtnCheck_Click(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(TbSideA.Text, out int a) ||
            !int.TryParse(TbSideB.Text, out int b) ||
            !int.TryParse(TbSideC.Text, out int c))
        {
            TbResult.Text = "Введите корректные целые числа.";
            return;
        }

        if (a <= 0 || b <= 0 || c <= 0)
        {
            TbResult.Text = "Длины сторон должны быть положительными.";
            return;
        }

        if (a + b <= c || a + c <= b || b + c <= a)
        {
            TbResult.Text = "Треугольник с такими сторонами не существует.";
            return;
        }

        if (a == b && b == c)
            TbResult.Text = "Треугольник равносторонний.";
        else if (a == b || b == c || a == c)
            TbResult.Text = "Треугольник равнобедренный.";
        else
            TbResult.Text = "Треугольник разносторонний.";
    }
}
}