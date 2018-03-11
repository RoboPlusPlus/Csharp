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

namespace LearningWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private string getSystemTime()
        {
            
            string nowTime = DateTime.Now.ToString();
            return nowTime;
        }

        private void TextBlock_Upper_Right_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock_Upper_Right.Text = "Mouse enter";
            SecondTextBox.Text = getSystemTime();
        }

        private void TextBlock_Upper_Right_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock_Upper_Right.Text = "Mouse left";
            SecondTextBox.Text = "Silly thing";
        }
    }
}
