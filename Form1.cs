using OpenQA.Selenium.Chrome;
using System; 
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; 
using System.Windows.Forms; 
namespace materialsautopilot
{
    public partial class Form1 : Form
    {
     int SleepTime = 500;
     string fotest = "";
     string fotest2 = "";
     string fotest3 = "";
     string fotest4 = "";
     string fotest5 = "";
     string fotest6 = "";
     string fotest7 = "";
     string fotest8 = "";
     string fotest9 = "";

     private int highestPercentageReached = 0;
     static string datasource = @"10.48.0.200";
     static string database = "DYDC";
     static string username = "sa";
     static string password = "Aa123456@";
     static string connString = @"Data Source=" + datasource + ";Initial Catalog="
                      + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
        public Form1()
        {
         InitializeComponent();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
         this.label2.Text = this.fotest;
         this.label3.Text = this.fotest2;
         this.label4.Text = this.fotest3;
         this.label5.Text = this.fotest4;
         this.label6.Text = this.fotest5;
         this.label7.Text = this.fotest6;
         this.label8.Text = this.fotest7;
         this.label9.Text = this.fotest8;
         this.label9.Text = this.fotest8;
         this.label10.Text = this.fotest9;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        int show2(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {
         int result = 0;
         int b = 0;
         b = b + 1;
         int percentComplete = b;

         if(percentComplete > 8)
          { 
          }
         else
         {
          if (percentComplete > highestPercentageReached)
          {
           highestPercentageReached = percentComplete;
           worker.ReportProgress(percentComplete);
          }
         }
          return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         InitializeBackgroundWorker();
        }
        private void InitializeBackgroundWorker()
        {
          this.backgroundWorker1 = new BackgroundWorker();
          this.backgroundWorker1.WorkerReportsProgress = true;
          this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
          this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
          this.backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
          this.backgroundWorker1.RunWorkerAsync(1);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //this.Iron();
            //this.fotest = "鋼筋每公噸牌價下載完成";
            //e.Result = this.show2((int)e.Argument, worker, e);

            this.Points();
            e.Result = this.show2((int)e.Argument, worker, e);
            this.fotest2 = "景氣指標下載完成";

            this.Points2();
            e.Result = this.show2((int)e.Argument, worker, e);
            this.fotest3 = "領先指標下載完成";

            this.Points3();
            e.Result = this.show2((int)e.Argument, worker, e);
            this.fotest4 = "同時指標下載完成";

            this.Points4();
            e.Result = this.show2((int)e.Argument, worker, e);
            this.fotest5 = "落後指標下載完成";

            this.Points5();
            this.fotest = "租金指數下載完成";
            e.Result = this.show2((int)e.Argument, worker, e);

            this.Points6();
            e.Result = this.show2((int)e.Argument, worker, e);
            this.fotest7 = "製造業採購經理人指數(PMI)下載完成";

            this.Points7();
            e.Result = this.show2((int)e.Argument, worker, e);
            this.fotest8 = "非製造業經理人指數(NMI)下載完成";

            this.materials();
            e.Result = this.show2((int)e.Argument, worker, e);
            this.fotest8 = "原物料下載完成";
        }

        private void Iron()
        {
            DateTime today = DateTime.Today;
            if (today.DayOfWeek.ToString() == "Wednesday")
            {
             var tab1 = new ChromeDriver();
             tab1.Navigate().GoToUrl("https://www.google.com.tw/search?q=公噸%2B牌價+豐興&tbs=qdr:w");
             System.Threading.Thread.Sleep(SleepTime);
             string pagesource1 = tab1.PageSource;
             tab1.Quit();
             Iron2(pagesource1);
            }
        }
        private void Iron2(string pageSource)
        {
            string pagehere = pageSource;
            int indextitle = pagehere.IndexOf("<br><h3 class=");
            int i = 0;
            while (pagehere.IndexOf("<br><h3 class=", indextitle + i) != -1)
            {
                indextitle = pagehere.IndexOf("<br><h3 class=", indextitle + i);
                string gettitle = pagehere.Substring(indextitle + 14, 500);
                int startindex = gettitle.IndexOf(">");
                int endindex = gettitle.IndexOf("</h3>");
                string gettitle2 = gettitle.Substring(startindex + 1, (endindex - (startindex) - 1));
                string linkO = pagehere.Substring(indextitle - 2300, 2300);
                int f1dex = linkO.LastIndexOf("<a href");
                string tmp1 = linkO.Substring(f1dex, linkO.Length - f1dex);
                int f2dex = tmp1.IndexOf("http");
                string tmp2 = tmp1.Substring(f2dex, tmp1.Length - f2dex);
                int f3dex = tmp2.IndexOf("\"");
                string tmp3 = tmp2.Substring(0, f3dex);

                if (tmp3.Contains("ctee"))
                {
                    var tab1 = new ChromeDriver();
                    tab1.Navigate().GoToUrl(tmp3);
                    System.Threading.Thread.Sleep(SleepTime);
                    string pagesource1 = tab1.PageSource;
                    
                    tab1.Quit();
                    Iron3(pagesource1);
                    break;
                }
                i++;
            }
        }
        private void Iron3(string Page)
        {
            string pageSource = Page;
            string skeyword = "";
            string skeyword2 = "";
            string skeyword3 = "";
            int start = 0;
            int end = 0;
            int start2 = 0;
            int end2 = 0;
            int start3 = 0;
            int end3 = 0;
            bool deter = false;
            start = pageSource.IndexOf("鋼筋每公噸牌價");
            end = pageSource.IndexOf("元", start);
            skeyword = pageSource.Substring(start, end - start);
            start2 = pageSource.IndexOf("datetime=\"");
            end2 = pageSource.IndexOf("T", start2);
            skeyword2 = pageSource.Substring(start2 + 10, end2 - (start2 + 10));

            start3 = pageSource.IndexOf("廢鋼每公噸收購牌價");
            end3 = pageSource.IndexOf("元", start3);
            skeyword3 = pageSource.Substring(start3, end3 - start3);

            string splitYear = skeyword2;
            string splitYear2 = splitYear.Substring(0, 4);
            int isplitYear2 = Int32.Parse(splitYear2);
            string splitMonth = skeyword2;
            string splitMonth2 = skeyword2.Substring(5, 2);
            string splitDay = skeyword2;
            string splitDay2 = skeyword2.Substring(8, 2);
            string test = skeyword;
            string test2 = string.Empty;

            for (int t1 = 0; t1 < test.Length; t1++)
            {
                if (char.IsDigit(test[t1]))
                {
                    test2 += test[t1]; // iron 20900
                }
            }
            int tmpskeyword = Int32.Parse(test2);

            string test3 = skeyword3;
            string test4 = string.Empty;

            for (int t1 = 0; t1 < test3.Length; t1++)
            {
                if (char.IsDigit(test3[t1]))
                {
                    test4 += test3[t1]; //badiron 10900
                }
            }
            decimal c = 0;
            int basepoint = 17100;
            double basecompare = 0;
            int tmpskeyword2 = Int32.Parse(test4);
            DateTime today = DateTime.Today;
            string rec = today.Date.ToString();
            int a = Int32.Parse(test2);
            int b = Int32.Parse(test4);

            basecompare = a - basepoint;
            basecompare = basecompare / basepoint;
            string d = basecompare.ToString("0.00");
            c = Decimal.Parse(d) * 100;

             deter = RetreivedPrices(isplitYear2, splitMonth2, splitDay2, skeyword2, "", tmpskeyword2, a, b, 0, "", c, "每週", rec.Substring(0, 10));
           
            if (deter == true)
            {
            }
            else
            {
             InsertPrices(isplitYear2, splitMonth2, splitDay2, skeyword2, "", tmpskeyword2, a, b, 0, "", c, "每週", rec.Substring(0, 10));
            }
        }

        private void Points()
        {
            var tab1 = new ChromeDriver();
            tab1.Navigate().GoToUrl("https://index.ndc.gov.tw/n/zh_tw/lightscore#/");
            System.Threading.Thread.Sleep(SleepTime);
            string pagesource1 = tab1.PageSource;
            tab1.Quit();
            Signals(pagesource1, "https://index.ndc.gov.tw/n/zh_tw/lightscore#/");
        }

        /// <summary>
        /// 領先指標
        /// </summary>
        private void Points2()
        {
         var tab1 = new ChromeDriver();
         tab1.Navigate().GoToUrl("https://index.ndc.gov.tw/n/zh_tw/leading#/");
         System.Threading.Thread.Sleep(SleepTime);
         string pagesource1 = tab1.PageSource;
         tab1.Quit();
         LeadPoints(pagesource1, "https://index.ndc.gov.tw/n/zh_tw/leading#/");
        }

        /// <summary>
        /// 同時指標
        /// </summary>
        private void Points3()
        {
            var tab1 = new ChromeDriver();
            tab1.Navigate().GoToUrl("https://index.ndc.gov.tw/n/zh_tw/coincident#/");
            System.Threading.Thread.Sleep(SleepTime);
            string pagesource1 = tab1.PageSource;
            tab1.Quit();
            Coincidence(pagesource1, "https://index.ndc.gov.tw/n/zh_tw/coincident#/");
        }

        /// <summary>
        /// 落後指標
        /// </summary>
        private void Points4()
        {
            var tab1 = new ChromeDriver();
            tab1.Navigate().GoToUrl("https://index.ndc.gov.tw/n/zh_tw/lagged#/");
            System.Threading.Thread.Sleep(SleepTime);
            string pagesource1 = tab1.PageSource;
            tab1.Quit();
            Lagged(pagesource1, "https://index.ndc.gov.tw/n/zh_tw/lagged#/");
        } 

        /// <summary>
        /// 租金指數
        /// </summary>
        private void Points5()
        {
            var tab1 = new ChromeDriver();
            tab1.Navigate().GoToUrl("https://pip.moi.gov.tw/V3/Default.aspx");
            System.Threading.Thread.Sleep(SleepTime);
            string pagesource1 = tab1.PageSource;
            tab1.Quit();
            Rent(pagesource1, "https://pip.moi.gov.tw/V3/Default.aspx");
        }
        private void Points6()
        {
            var tab1 = new ChromeDriver();
            tab1.Navigate().GoToUrl("https://index.ndc.gov.tw/n/zh_tw/PMI#/");
            System.Threading.Thread.Sleep(SleepTime);
            string pagesource1 = tab1.PageSource;
            tab1.Quit();
            PMI(pagesource1, "https://index.ndc.gov.tw/n/zh_tw/PMI#/");
        }
        private void Points7()
        {
            var tab1 = new ChromeDriver();
            tab1.Navigate().GoToUrl("https://index.ndc.gov.tw/n/zh_tw/NMI#/");
            System.Threading.Thread.Sleep(SleepTime);
            string pagesource1 = tab1.PageSource;
            tab1.Quit();
            NMI(pagesource1, "https://index.ndc.gov.tw/n/zh_tw/NMI#/");
        }
        private void materials()
        {
            for (int i = 0; i < 8; i++)
            {
                string[] materialarray = new string[]
                 {
                  "鋼板",    
                  "銅",
                  "混凝土",   
                  "倫敦鎳",  
                  "冷軋",
                  "熱軋鋼品中鋼盤價",
                  "倫敦鋁現貨價",
                  "PVC 進口價"        
                 };
                var source0 = new ChromeDriver();
                source0.Navigate().GoToUrl("https://fubon-ebrokerdj.fbs.com.tw/z/ze/zeq/zeq.djhtm");
                System.Threading.Thread.Sleep(SleepTime);
                string sourcePage0 = source0.PageSource;
                source0.Quit();
                Materal2(sourcePage0, materialarray[i]);
            }
        }
        private void Materal2(string Page, string Material)
        {
            string pageSource = Page;
            string material = Material;
            int ikeyword = pageSource.IndexOf(material);
            if(ikeyword == -1)
            {
                string abc = "no need to update";
            }
            else {
            string skeyword = "";
            string link = "";
            int start = 0;
            int end = 0;
            skeyword = pageSource.Substring(ikeyword - 40, 40);
            start = skeyword.IndexOf("href");
            end = skeyword.LastIndexOf("\">");
            link = skeyword.Substring(start + 6, end - (start + 6));
            Materal3(link, material);
            }
        }
        private void Materal3(string Url, string Material)
        {
            //https://fubon-ebrokerdj.fbs.com.tw/z/ze/zeq/zeq.djhtm
            string url = Url;
            string material = Material;
            string completedUrl = "https://fubon-ebrokerdj.fbs.com.tw" + url;
            var web = new ChromeDriver();
            web.Navigate().GoToUrl(completedUrl);
            System.Threading.Thread.Sleep(SleepTime);
            string pageSource = web.PageSource;
            web.Quit();
            Material4(url, pageSource, material);
        }
        private void Material4(string url, string page, string material)
        {
            string pageSource = page;
            string _material = material;
            string skeyword1 = "";
            string skeyword2 = "";
            string completedkeyword1 = "";
            int tip0 = 0;
            int tip1 = 0;
            int tipend = 0;
            int notehead = 0;
            int notehead2 = 0;
            int noteheadend = 0;
            tip0 = pageSource.IndexOf("tip0");
            if (tip0 <0)
            {
                Materal3(url, _material);
            }
            tip1 = pageSource.IndexOf("title", tip0);
            tipend = pageSource.IndexOf("class", tip1);
            skeyword1 = pageSource.Substring(tip1, tipend - tip1);
            completedkeyword1 = skeyword1.Substring(skeyword1.IndexOf("=") + 2, skeyword1.LastIndexOf("\"") - (skeyword1.IndexOf("=") + 2));
            int splitZeo = completedkeyword1.IndexOf(".");
            string completedkeyword2 = completedkeyword1.Substring(0, splitZeo);
            notehead = pageSource.IndexOf("notehead");
            notehead2 = pageSource.IndexOf("\">", notehead);
            noteheadend = pageSource.IndexOf("<", notehead2);
            skeyword2 = pageSource.Substring(notehead2 + 2, noteheadend - (notehead2 + 2)); 

            //skeyword2 日期 ex: 2022/10/22
            int basepoint = 24311;        //steel 鋼板
            double basepoint2 = 263.17;   //copper 銅
            double basepoint3 = 1875;     //concrete 混凝土
            double basepoint4 = 12070;    //nickel 倫敦鎳
            double basepoint5 = 23067;    //cold-rolled 冷軋
            double basepoint6 = 20841;    //hot-rolled 熱軋鋼品中鋼盤價
            double basepoint7 = 1761;     //aluminium 倫敦鋁現貨價
            double basepoint8 = 876;      //PVC 

            double basecompare = 0; //steel   鋼板
            double basecompare2 = 0;  //copper 銅
            double basecompare3 = 0;  //concrete  混凝土
            double basecompare4 = 0;  //nickel 倫敦鎳
            double basecompare5 = 0;  //cold-rolled  冷軋
            double basecompare6 = 0;  //hot-rolled  熱軋鋼品中鋼盤價
            double basecompare7 = 0;  //aluminium 倫敦鋁現貨價
            double basecompare8 = 0;  //PVC
            string splitYear = skeyword2;
            string splitYear2 = splitYear.Substring(0, 4);
            int isplitYear2 = Int32.Parse(splitYear2);
            //splitYear2 = 年 ex: 2022
            string splitMonth = skeyword2;
            string splitMonth2 = skeyword2.Substring(5, 2);
            //splitMonth2 = 月 ex: 10
            string splitDay = skeyword2;
            string splitDay2 = skeyword2.Substring(8, 2);
            //splitDay2 = 日 ex: 22
            DateTime today = DateTime.Today;
            string rec = today.Date.ToString();
            //rec = 日期+時間 ex: 10/28/2022 12:00:00 AM
            string test3 = completedkeyword2;
            //test3 = 取得值
            string test4 = string.Empty;
            for (int t1 = 0; t1 < test3.Length; t1++)
            {
                if (char.IsDigit(test3[t1]))
                {
                    test4 += test3[t1];
                }
            }
            //test4 = 每一字元是否是是數字
            int tmpskeyword2 = Int32.Parse(test4); //get exact number of iron
            bool deter = false;
            decimal c = 0;

            if (_material.Contains("鋼板"))
            {
                basecompare = tmpskeyword2 - basepoint;
                basecompare = basecompare / basepoint;
                string a = basecompare.ToString("0.00");
                c = Decimal.Parse(a) * 100;
            }

            if (_material.Contains("銅"))
            {
                basecompare2 = tmpskeyword2 - basepoint2;
                basecompare2 = basecompare2 / basepoint2;
                string a = basecompare2.ToString("0.00");
                c = Decimal.Parse(a) * 100;
            }

            if (_material.Contains("混凝土"))
            {
                basecompare3 = tmpskeyword2 - basepoint3;
                basecompare3 = basecompare3 / basepoint3;
                string a = basecompare3.ToString("0.00");
                c = Decimal.Parse(a) * 100;
            }

            if (_material.Contains("倫敦鎳"))
            {
                basecompare4 = tmpskeyword2 - basepoint4;
                basecompare4 = basecompare4 / basepoint4;
                string a = basecompare4.ToString("0.00");
                c = Decimal.Parse(a) * 100;
            }

            if (_material.Contains("冷軋"))
            {
                basecompare5 = tmpskeyword2 - basepoint5;
                basecompare5 = basecompare5 / basepoint5;
                string a = basecompare5.ToString("0.00");
                c = Decimal.Parse(a) * 100;
            }

            if (_material.Contains("熱軋"))
            {
                basecompare6 = tmpskeyword2 - basepoint6;
                basecompare6 = basecompare6 / basepoint6;
                string a = basecompare6.ToString("0.00");
                c = Decimal.Parse(a) * 100;
            }

            if (_material.Contains("倫敦鋁現貨價"))
            {
                basecompare7 = tmpskeyword2 - basepoint7;
                basecompare7 = basecompare7 / basepoint7;
                string a = basecompare7.ToString("0.00");
                c = Decimal.Parse(a) * 100;
            }

            if (_material.Contains("PVC 進口價"))
            {
                basecompare8 = tmpskeyword2 - basepoint8;
                basecompare8 = basecompare8 / basepoint8;
                string a = basecompare8.ToString("0.00");
                c = Decimal.Parse(a) * 100;
            }

            deter = RetreivedPrices(isplitYear2, splitMonth2, splitDay2, skeyword2, _material, tmpskeyword2, 0, 0, 0, "", c, "每週", rec.Substring(0, 10));
            if (deter == true)
            {
            }
            else
            {
             InsertPrices(isplitYear2, splitMonth2, splitDay2, skeyword2, _material, tmpskeyword2, 0, 0, 0, "", c, "每週", rec.Substring(0, 10));
            }

        }
        private void Signals(string Page, string Url)
        {
            string pageSource = Page;
            string url = Url;
            string skeyword = "";
            string skeyword2 = ""; //月的值
            string skeyword3 = "";//年的值
            int start = 0;
            int end = 0;
            int nextpoint = 0;
            int nextpoint2 = 0;
            int i = 0;
            bool deter = false;
 
            while (nextpoint != -1 && nextpoint2 != -1)
            {
                start = pageSource.IndexOf("<tspan>", nextpoint);
                end = pageSource.IndexOf("</tspan>", nextpoint);
                nextpoint = pageSource.IndexOf("<tspan>", nextpoint + 1);

                if (nextpoint == -1 || nextpoint2 == -1)
                {
                }
                else
                {
                    skeyword = pageSource.Substring(nextpoint + 7, end - (start + 7));
                    i++;
                }
            }

            start = pageSource.IndexOf("month.t.m");
            nextpoint = pageSource.IndexOf("\">", start);
            nextpoint2 = pageSource.IndexOf("<", nextpoint);
            skeyword2 = pageSource.Substring(nextpoint+2, nextpoint2- (nextpoint+2));

            start = pageSource.IndexOf("month.t.y");
            nextpoint = pageSource.IndexOf("\">", start);
            nextpoint2 = pageSource.IndexOf("<", nextpoint);
            skeyword3 = pageSource.Substring(nextpoint + 2, nextpoint2 - (nextpoint + 2));



            deter = GetPoints("景氣對策信號", skeyword3 + "/" + skeyword2, skeyword, "");
            if (deter == true)
            {
            }
            else
            {
                PutPoints("景氣對策信號", skeyword3 + "/" + skeyword2, skeyword, "");
            }
        }

        /// <summary>
        /// 領先指標
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        private  string LeadPoints(string Page, string Url)
        {
            string error = "";
            string pageSource = Page;
            string url = Url;
            string skeyword = "";
            string skeyword2 = "";
            string skeyword3 = "";
            string skeyword4 = "";
            bool deter = false;
            int start = 0;
            int end = 0;
            int start2 = 0;
            int end2 = 0;
            int nextpoint = 0;
            int nextpoint2 = 0;
            int i = 0;
            while (nextpoint != -1 && nextpoint2 != -1)
            {
                start = pageSource.IndexOf("number: 2\">", nextpoint);
                end = pageSource.IndexOf("</p>", start);
                nextpoint = pageSource.IndexOf("number: 2\">", nextpoint + 1);

                start2 = pageSource.IndexOf("percentage\">", nextpoint2);
                end2 = pageSource.IndexOf("</p>", start2);
                nextpoint2 = pageSource.IndexOf("percentage\">", nextpoint2 + 1);

                if (nextpoint == -1 || nextpoint2 == -1)
                {
                }
                else
                {
                    skeyword = pageSource.Substring(nextpoint + 11, end - (start + 11));
                    skeyword2 = pageSource.Substring(nextpoint2 + 12, end2 - (start2 + 12));

                    if (skeyword == "0.00")
                    {
                        error = "no";
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            start = pageSource.IndexOf("month.t.m");
            nextpoint = pageSource.IndexOf("\">", start);
            nextpoint2 = pageSource.IndexOf("<", nextpoint);
            skeyword3 = pageSource.Substring(nextpoint + 2, nextpoint2 - (nextpoint + 2));
            start = pageSource.IndexOf("month.t.y");
            nextpoint = pageSource.IndexOf("\">", start);
            nextpoint2 = pageSource.IndexOf("<", nextpoint);
            skeyword4 = pageSource.Substring(nextpoint + 2, nextpoint2 - (nextpoint + 2));
            if (skeyword.Contains("0.0"))
            {
                Points2();
            }
            else {
            deter = GetPoints("領先指標", skeyword4 + "/" + skeyword3, skeyword, "較上月變化" + skeyword2);
            if (deter == true)
            {

            }
            else
            {
                PutPoints("領先指標", skeyword4 + "/" + skeyword3, skeyword, "較上月變化" + skeyword2);
            }
            }


            return error;

        }

        /// <summary>
        /// 同時指標
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        private  string Coincidence(string Page, string Url)
        {
            bool deter = false;
            string error = "";
            string pageSource = Page;
            string url = Url;
            string skeyword = "";
            string skeyword2 = "";

            string skeyword3 = "";
            string skeyword4 = "";
            int start = 0;
            int end = 0;
            int start2 = 0;
            int end2 = 0;
            int nextpoint = 0;
            int nextpoint2 = 0;
            int i = 0;
 

            while (nextpoint != -1 && nextpoint2 != -1)
            {
                start = pageSource.IndexOf("number: 2\">", nextpoint);
                end = pageSource.IndexOf("</p>", start);
                nextpoint = pageSource.IndexOf("number: 2\">", nextpoint + 1);

                start2 = pageSource.IndexOf("percentage\">", nextpoint2);
                end2 = pageSource.IndexOf("</p>", start2);
                nextpoint2 = pageSource.IndexOf("percentage\">", nextpoint2 + 1);

                if (nextpoint == -1 || nextpoint2 == -1)
                {
                }
                else
                {
                    skeyword = pageSource.Substring(nextpoint + 11, end - (start + 11));
                    skeyword2 = pageSource.Substring(nextpoint2 + 12, end2 - (start2 + 12));

                    if (skeyword == "0.00")
                    {
                        error = "no";
                    }
                    else
                    {
                        
                        i++;
                    }
                }
            }

            start = pageSource.IndexOf("month.t.m");
            nextpoint = pageSource.IndexOf("\">", start);
            nextpoint2 = pageSource.IndexOf("<", nextpoint);
            skeyword3 = pageSource.Substring(nextpoint + 2, nextpoint2 - (nextpoint + 2));
            start = pageSource.IndexOf("month.t.y");
            nextpoint = pageSource.IndexOf("\">", start);
            nextpoint2 = pageSource.IndexOf("<", nextpoint);
            skeyword4 = pageSource.Substring(nextpoint + 2, nextpoint2 - (nextpoint + 2));



            if (skeyword.Contains("0.0"))
            {
                Points3();
            }
            else { 
            deter = GetPoints("同時指標", skeyword4 + "/" + skeyword3, skeyword, "較上月變化" + skeyword2);
            if (deter == true)
            {
            }
            else
            {
                PutPoints("同時指標", skeyword4 + "/" + skeyword3, skeyword, "較上月變化" + skeyword2);
            }
            }
            return error;
        }

        /// <summary>
        /// 落後指標
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        private  string Lagged(string Page, string Url)
        {
            bool deter = false;
            string error = "";
            string pageSource = Page;
            string url = Url;
            string skeyword = "";
            string skeyword2 = "";

            string skeyword3 = "";
            string skeyword4 = "";
            int start = 0;
            int end = 0;
            int start2 = 0;
            int end2 = 0;
            int nextpoint = 0;
            int nextpoint2 = 0;
            int i = 0;
 

            while (nextpoint != -1 && nextpoint2 != -1)
            {
                start = pageSource.IndexOf("number: 2\">", nextpoint);
                end = pageSource.IndexOf("</p>", start);
                nextpoint = pageSource.IndexOf("number: 2\">", nextpoint + 1);
                start2 = pageSource.IndexOf("percentage\">", nextpoint2);
                end2 = pageSource.IndexOf("</p>", start2);
                nextpoint2 = pageSource.IndexOf("percentage\">", nextpoint2 + 1);
                if (nextpoint == -1 || nextpoint2 == -1)
                {
                }
                else
                {
                    skeyword = pageSource.Substring(nextpoint + 11, end - (start + 11));
                    skeyword2 = pageSource.Substring(nextpoint2 + 12, end2 - (start2 + 12));
                    if (skeyword == "0.00")
                    {
                     error = "no";
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            start = pageSource.IndexOf("month.t.m");
            nextpoint = pageSource.IndexOf("\">", start);
            nextpoint2 = pageSource.IndexOf("<", nextpoint);
            skeyword3 = pageSource.Substring(nextpoint + 2, nextpoint2 - (nextpoint + 2));
            start = pageSource.IndexOf("month.t.y");
            nextpoint = pageSource.IndexOf("\">", start);
            nextpoint2 = pageSource.IndexOf("<", nextpoint);
            skeyword4 = pageSource.Substring(nextpoint + 2, nextpoint2 - (nextpoint + 2));



            if (skeyword.Contains("0.0"))
            {
                Points4();
            }
            else { 
            deter = GetPoints("落後指標", skeyword4 + "/" + skeyword3, skeyword, "較上月變化" + skeyword2);
            if (deter == true)
            {
            }
            else
            {
                PutPoints("落後指標", skeyword4 + "/" + skeyword3, skeyword, "較上月變化" + skeyword2);
            }
            }
            return error;

        }

        /// <summary>
        /// 租金指數
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        private string Rent(string Page, string Url)
        {
            //顯示主計總處租金指數(%)趨勢圖">主計總處租金指數(%) 
            string error = "";
            string pageSource = Page;
            string url = Url;
            string skeyword = "";  //租金指數
            string skeyword2 = ""; //日期
            int start = 0;
            int sNext = 0;
            int sNNext = 0;
            bool deter = false;

            start = pageSource.IndexOf("顯示主計總處租金指數(%)趨勢圖\">主計總處租金指數(%)");
            sNext = pageSource.IndexOf("<span>", start);
            sNNext = pageSource.IndexOf("</span>", sNext);
            skeyword = pageSource.Substring(sNext+6, sNNext - (sNext+6));
            sNNext = pageSource.IndexOf("</span></td></tr>", sNext);
            skeyword2 = pageSource.Substring(sNNext-6, 6);
 
            if (skeyword == "")
            {
                Points5();
            }
            if (skeyword.Length <= 3)
            {
                error = "no";
            }
            else
            {
                deter = GetPoints("租金指數(%)", skeyword2, skeyword, "");
                if (deter == true)
                {
                }
                else
                {
                 PutPoints("租金指數(%)", skeyword2, skeyword, "");
                }
            }

            return error;
        }
 
        private string PMI(string Page, string Url)
        {
          string error = "";
          string pageSource = Page;
          string url = Url;
          string skeyword = "";  //變化百分比
          string skeyword2 = ""; //PMI指數
          string skeyword3 = ""; //月
          string skeyword4 = ""; //年

          int start = 0;
          int start2 = 0;
          int start3 = 0;
          int end = 0;
          int sNext = 0;
          int sNNext = 0;
          bool deter = false;
          start = pageSource.IndexOf("percentage\"");
          end = pageSource.IndexOf("</span>", start);
          skeyword = pageSource.Substring(start, end - start);
          start2 = skeyword.IndexOf("\">");
          skeyword = skeyword.Substring(start2 + 2, skeyword.Length - (start2 + 2));
          start = pageSource.IndexOf("\"big.score+'");
          end = pageSource.IndexOf("</p>", start);

          skeyword2 = pageSource.Substring(start, end - start);
          start2 = skeyword2.IndexOf("\">");

          skeyword2 = skeyword2.Substring(start2 + 2, skeyword2.Length - (start2 + 2));
          skeyword2 = skeyword2.Remove(skeyword2.Length - 1, 1);

          start3 = pageSource.IndexOf("monthName");
          sNext = pageSource.IndexOf("\">", start3);
          sNNext = pageSource.IndexOf("<", sNext);
          skeyword3 = pageSource.Substring(sNext+2, sNNext - (sNext+2));

            start3 = pageSource.IndexOf("month.t.y");
            sNext = pageSource.IndexOf("</div>", start3);
            skeyword4 = pageSource.Substring(start3+11, sNext - (start3+11));

          if (skeyword2 == "")
          {
           Points6();
          }
          if (skeyword2.Length <= 3)
          {
           error = "no";
          }
          else
          {
           deter = GetPoints("製造業採購經理指數(PMI)", skeyword4+"/"+ skeyword3, skeyword2, "較上月變化" + skeyword + "百分點");
           if (deter == true)
           {
           }
           else
           {
            PutPoints("製造業採購經理指數(PMI)", skeyword4 + "/" + skeyword3, skeyword2, "較上月變化" + skeyword + "百分點");
           }
          }
 
            return error;
        }
        private string NMI(string Page, string Url)
        {
            bool deter = false;
            string error = "";
            string pageSource = Page;
            string url = Url;
            string skeyword = "";
            string skeyword2 = ""; //NMI值
            string skeyword3 = "";  //月
            string skeyword4 = ""; //年
            int start = 0;
            int end = 0;
            int start2 = 0;
            int sNext = 0;
            int sNNext = 0;
            start = pageSource.IndexOf("percentage\"");
            end = pageSource.IndexOf("</span>", start);
            skeyword = pageSource.Substring(start, end - start);
            start2 = skeyword.IndexOf("\">");
            skeyword = skeyword.Substring(start2 + 2, skeyword.Length - (start2 + 2));
            start = pageSource.IndexOf("\"big.score+'");
            end = pageSource.IndexOf("</p>", start);
            skeyword2 = pageSource.Substring(start, end - start);
            start2 = skeyword2.IndexOf("\">");
            skeyword2 = skeyword2.Substring(start2 + 2, skeyword2.Length - (start2 + 2));
            skeyword2 = skeyword2.Remove(skeyword2.Length - 1, 1);

            start2 = pageSource.IndexOf("monthName");
            sNext = pageSource.IndexOf("\">", start2);
            sNNext = pageSource.IndexOf("<", sNext);
            skeyword3 = pageSource.Substring(sNext + 2, sNNext - (sNext + 2));

            start2 = pageSource.IndexOf("month.t.y");
            sNext = pageSource.IndexOf("</div>", start2);
            skeyword4 = pageSource.Substring(start2 + 11, sNext - (start2 + 11));
 
            if (skeyword2 == "")
            {
                Points7();
            }
 
            else
            {
                deter = GetPoints("非製造業經理人指數(NMI)", skeyword4 + "/" + skeyword3, skeyword2, "較上月變化" + skeyword + "百分點");
                if (deter == true)
                {
                }
                else
                {
                    PutPoints("非製造業經理人指數(NMI)", skeyword4 + "/" + skeyword3, skeyword2, "較上月變化" + skeyword + "百分點");
                }
            }
            
            return error;
        }
 
        private static bool GetPoints(string title, string date, string rate, string e)
        {
            bool deter = false;
            SqlConnection myConn = new SqlConnection(connString);
            string str4 = "select count (*) from [DYSD_總體指標_2] where date =@date and rate =@rate ";
            SqlCommand myCommand = new SqlCommand(str4, myConn);
            try
            {
                myConn.Open();
                myCommand.Parameters.AddWithValue("@title", title);
                myCommand.Parameters.AddWithValue("@date", date);
                myCommand.Parameters.AddWithValue("@rate", rate);
                myCommand.Parameters.AddWithValue("@e", e);
                int DataExist = (int)myCommand.ExecuteScalar();

                if (DataExist > 0)
                {
                    deter = true;
                }
                else
                {
                    deter = false;
                }
            }
            catch (System.Exception ex)
            {
                string abc = (ex.ToString());
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            return deter;

        }
        private static bool PutPoints(string title, string date, string rate, string e)
        {
            SqlConnection myConn = new SqlConnection(connString);
            string str4 = "INSERT INTO [DYSD_總體指標_2] (Title, Date, Rate, Memo) VALUES(@title, @date, @rate, @e)";
            SqlCommand myCommand = new SqlCommand(str4, myConn);
            try
            {
                myConn.Open(); 
                myCommand.Parameters.AddWithValue("@title", title);
                myCommand.Parameters.AddWithValue("@date", date);
                myCommand.Parameters.AddWithValue("@rate", rate);
                myCommand.Parameters.AddWithValue("@e", e);
                myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                string abc = (ex.ToString());
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            return true;
        }

        private bool RetreivedPrices(int year, string month, string day, string date, string name, int rate1, int rate2, int rate3, int rate4, string memo, decimal baseprice, string upcircle, string update)
        {
            SqlConnection myConn = new SqlConnection(connString);
            string str = " select count (*) from  [DYDC].[dbo].[listPrices] where name =@name and rate1 = @rate1";
            bool deter = false;
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.Parameters.AddWithValue("@year", year);
                myCommand.Parameters.AddWithValue("@month", month);
                myCommand.Parameters.AddWithValue("@day", day);
                myCommand.Parameters.AddWithValue("@date", date);
                myCommand.Parameters.AddWithValue("@name", name);
                myCommand.Parameters.AddWithValue("@rate1", rate1);
                myCommand.Parameters.AddWithValue("@rate2", rate2);
                myCommand.Parameters.AddWithValue("@rate3", rate3);
                myCommand.Parameters.AddWithValue("@rate4", rate4);
                myCommand.Parameters.AddWithValue("@memo", memo);
                myCommand.Parameters.AddWithValue("@baseprice", baseprice);
                myCommand.Parameters.AddWithValue("@upcircle", upcircle);
                myCommand.Parameters.AddWithValue("@update", update);
                int DataExist = (int)myCommand.ExecuteScalar();
                if (DataExist > 0)
                {
                    deter = true;
                }
                else
                {
                    deter = false;
                }
            }
            catch (System.Exception ex)
            {
                string err = (ex.ToString());
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            return deter;
        }

        private void InsertPrices(int year, string month, string day, string date, string name, int rate1, int rate2, int rate3, int rate4, string memo, decimal baseprice, string upcircle, string update)
        {
            SqlConnection myConn = new SqlConnection(connString);
            string str = "INSERT INTO [dbo].[listPrices]" +
            "([年]" +
            ",[月]" +
            ",[日]" +
            ",[日期]" +
            ",[name]" +
            ",[rate1]" +
            ",[rate2]" +
            ",[rate3]" +
            ",[rate4]" +
            ",[重要記事]" +
            ",[2019.09為基準漲跌幅]" +
            ",[更新週期]" +
            ",[更新日期])"+
            "VALUES(@year, @month, @day, @date," +
            "@name," +
            "@rate1," +
            "@rate2," +
            "@rate3," +
            "@rate4," +
            "@memo," +
            "@baseprice," +
            "@upcircle," +
            "@update )";
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.Parameters.AddWithValue("@year", year);
                myCommand.Parameters.AddWithValue("@month", month);
                myCommand.Parameters.AddWithValue("@day", day);
                myCommand.Parameters.AddWithValue("@date", date);
                myCommand.Parameters.AddWithValue("@name", name);
                myCommand.Parameters.AddWithValue("@rate1", rate1);
                myCommand.Parameters.AddWithValue("@rate2", rate2);
                myCommand.Parameters.AddWithValue("@rate3", rate3);
                myCommand.Parameters.AddWithValue("@rate4", rate4);
                myCommand.Parameters.AddWithValue("@memo", memo);
                myCommand.Parameters.AddWithValue("@baseprice", baseprice);
                myCommand.Parameters.AddWithValue("@upcircle", upcircle);
                myCommand.Parameters.AddWithValue("@update", update);
                myCommand.ExecuteNonQuery();
       
            }
            catch(System.Exception ex)
            {
                string err = (ex.ToString());
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
