
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Pdf2Text
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Exit += App_Exit;
        }

        void App_Exit(object sender, ExitEventArgs e)
        {
            PdfToXml.Ins.Dispose();
        }
    }
}
