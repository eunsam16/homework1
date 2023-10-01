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

namespace homework1
{
    internal class Triangle
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }
        public bool Confirm { get; set; }
    }
}


namespace homework1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Triangle> triangles = new List<Triangle>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var targetTextBox = sender as TextBox;
            bool success = double.TryParse(targetTextBox.Text, out double amount);
            if (!success && !string.IsNullOrEmpty(targetTextBox.Text))
            {
                MessageBox.Show("請輸入數字，輸入錯誤請輸入數字，輸入錯誤");
                targetTextBox.Clear();
            }
            else if (amount <= 0 && !string.IsNullOrEmpty(targetTextBox.Text))
            {
                MessageBox.Show("輸入數值必須大於輸入數值必須大於0，輸入錯誤，輸入錯誤");
                targetTextBox.Clear();
            } //新增新增檢查檢查targetTextBox內容物是不內容物是不是是Null為了讓為了讓Delete後不後不會再跳一次會再跳一次Show，增加使用流暢，增加使用流暢度度
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            triangles.Add(new Triangle()
            {
                Side1 = double.Parse(textbox1.Text),
                Side2 = double.Parse(textbox2.Text),
                Side3 = double.Parse(textbox3.Text),
            });
            foreach (var item in triangles)
            {
                item.Confirm = item.Side1 + item.Side2 > item.Side3 && item.Side1 + item.Side3 > item.Side2 && item.Side2 + item.Side3 > item.Side1; //判斷是否為三角形的函數判斷是否為三角形的函數
                textblock.Text = $"你所輸入的三個邊長分別為你所輸入的三個邊長分別為{item.Side1}, {item.Side2}, {item.Side3}\n";
                if (item.Confirm == true)
                {
                    labelbar.Content = $"邊長邊長{item.Side1},{item.Side2},{item.Side3} 可構成三角可構成三角形形";
                    labelbar.Background = System.Windows.Media.Brushes.Green;
                    textblock.Text += "經過計算後，任意兩邊的和都大於第三邊經過計算後，任意兩邊的和都大於第三邊\n";
                }
                else
                {
                    labelbar.Content = $"邊長邊長{item.Side1},{item.Side2},{item.Side3} 不可構成三不可構成三角形角形";
                    labelbar.Background = System.Windows.Media.Brushes.Red;
                    textblock.Text += "經過計算後，有兩邊的和小於第三邊經過計算後，有兩邊的和小於第三邊\n";
                }
                textblock.Text += $"最終你的所存入的數據分別為最終你的所存入的數據分別為:\n邊邊1 = {item.Side1} 邊邊2 = {item.Side2} 邊邊3 = {item.Side3} 布林值為布林值為 = {item.Confirm} ";
            }
        }
        private void Result_botton(object sender, RoutedEventArgs e)
        {
            textblock.Text = "";
            for (int i = 0; i < triangles.Count; i++)
            {
                textblock.Text += $"第第{i + 1}個三角形個三角形: 邊邊1 = {triangles[i].Side1} 邊邊2 = {triangles[i].Side2} 邊邊3 = {triangles[i].Side3} 布林值為布林值為 = {triangles[i].Confirm}\n";
            }
        }
    }
}
    }
}
