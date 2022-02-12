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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;//读写Json
using System.IO;

namespace WpfHelloWolrd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            showtimer = new DispatcherTimer();//实例化
            showtimer.Tick += new EventHandler(ShowCurLz);//对应的每次触发的事件（计算用）
            showtimer.Start();//开启时间，这里先开启，会直接刷新一次，然后再调整为六分钟刷新一次
            showtimer.Interval = new TimeSpan(0, 0, 3, 0);//控制时间六分钟跳动一次
        }

        //声明计时器
        private DispatcherTimer showtimer;

        /*
        public void ShowCurTimer(object sender, EventArgs e)
        {
            //当配置文件内数据不为空时，才执行自动计算
            if(ConfigurationManager.AppSettings["full_time"] != "")
            {
                time_test.Text = DateTime.Now.ToString("dd HH:mm:ss");
            }

        }//测试时间显示，已废弃
        */

        public void ShowCurLz(object sender, EventArgs e)
        {
            lizhi_now.Text = Convert.ToString(Info.info.lz_start + Math.Floor((double)((DateTime.Now - Info.info.time_start).TotalMinutes / 6)));
            lizhi_full.Text = Convert.ToString(Info.info.lz_full);
            TimeSpan ts1 = Info.info.time_full.Subtract(DateTime.Now);
            last_time.Text = " " + ts1.Days.ToString() + " 天 "
                            + ts1.Hours.ToString() + " 小时 "
                            + ts1.Minutes.ToString() + " 分钟 ";
            time_test.Text = (Info.info.time_full).ToString(" dd 日 HH 点 mm 分");
        }

        public void Cal_Lz()
        {
            /*
            if (Info.info.is_start)
            {
                
            }
            */
            lizhi_now.Text = Convert.ToString(Info.info.lz_start + Math.Floor((double)((DateTime.Now - Info.info.time_start).TotalMinutes / 6)));
            lizhi_full.Text = Convert.ToString(Info.info.lz_full);
            TimeSpan ts1 = Info.info.time_full.Subtract(DateTime.Now);
            last_time.Text = " " + ts1.Days.ToString() + " 天 "
                            + ts1.Hours.ToString() + " 小时 "
                            + ts1.Minutes.ToString() + " 分钟 ";
            time_test.Text = (Info.info.time_full).ToString(" dd 日 HH 点 mm 分");
        }


        public void GetNow(string value1, string value2)
        {
            lizhi_now.Text = value1;//将数字转为double ----> Convert.ToString(value1)
            lizhi_full.Text = value2;

            Info.info.lz_start = Convert.ToDouble(value1);
            Info.info.lz_full = Convert.ToDouble(value2);
            Info.info.time_start = DateTime.Now;
            double minutes = (Info.info.lz_full - Info.info.lz_start) * 6; //需要回复多少分钟
            Info.info.time_full = DateTime.Now.AddMinutes(minutes);

            Cal_Lz();
        }//更改进度条上的数值文字（委托方法）
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //childWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //childWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            ChildWindow childWindow = new ChildWindow();
            childWindow.getLizhi = GetNow;
            childWindow.Left = 200 + this.Left;
            childWindow.Top = this.Top;
            childWindow.Show();

        }//【更改体力】按钮点击

        
        public class Info
        {
            public DateTime time_start; //记录时间
            public DateTime time_full;  //回满时间
            public double lz_start; //初始理智
            public double lz_full;  //理智上限

            public static Info info = new Info();//创建静态对象
        }//负责存储【记录时间】【回满时间】【初始理智】【理智上限】

        public void Read()
        {
            StreamReader file = File.OpenText("info.json");
            JsonTextReader reader = new JsonTextReader(file);
            JObject jsonObject = (JObject)JToken.ReadFrom(reader);
            Info.info.time_start = (DateTime)jsonObject["time_start"];
            Info.info.time_full = (DateTime)jsonObject["time_full"];
            Info.info.lz_start = (double)jsonObject["lz_start"];
            Info.info.lz_full = (double)jsonObject["lz_full"];
            //test
        }//负责存储【记录时间】【回满时间】【初始理智】【理智上限】
    }
}
