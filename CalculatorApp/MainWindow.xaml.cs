using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string value = "";
        private int index = 0;
        private string operation;
       
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (operation != "") operation = "";
           
            value += button.Content.ToString();
            textBoxDisplay.Text = value;
        }

        public void Operator_Click(object sender, EventArgs e)
        {
            if (value.Length == 0) return;
            if(operation != "" && value.Last().ToString() == " ")
            {
                value = value.Remove(value.Length - operation.Length);
            }
            operation = $" {((Button)sender).Content.ToString()} ";
            value += $"{operation}";
            textBoxDisplay.Text = value;
        }
        public void Clear_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text = "0";
        }

        public void Equals_Click(object sender, EventArgs e)
        {
            string[] inputs = value.Split(' ');
           // foreach (string input in inputs) { Debug.WriteLine(input); }
            string result = (int.Parse(inputs[0]) + int.Parse(inputs[2])).ToString();
            textBoxDisplay.Text = result;
            value = result;
        }
    }

    public enum OperatorValue
    {
        None = -1,
        Add,
        Subtract,
        Multiply,
        Divide,
    }
}
