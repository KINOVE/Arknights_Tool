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
using System.Windows.Threading;//线程
using System.Configuration;//配置文件

namespace WpfHelloWolrd
{
    public partial class ChildWindow : Window
    {
        public ChildWindow()
        {
            InitializeComponent();
            
        }

        public delegate void GetLizhi(string value1, string value2);  //声明委托
        public GetLizhi getLizhi;                                   //委托对象
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(IsDig (now.Text) && IsDig(upper_limit.Text) && Convert.ToDouble(now.Text) < Convert.ToDouble(upper_limit.Text))
            {
                getLizhi(now.Text, upper_limit.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入正确的理智");
            }
        }

        //检测是否为数字
        public static bool IsDig(String s1)
        {
            if (s1 == "")
                return false;
            foreach (char c in s1)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(ConfigurationManager.AppSettings["upper_limit"]);
            //upper_limit.Text = ConfigurationManager.AppSettings["upper_limit"]; //读取配置文件中的理智上限
            upper_limit.Text = Convert.ToString(MainWindow.Info.info.lz_full);
        }
    }
}
