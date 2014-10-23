
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public partial class PdfToXml : Form
    {
        /// <summary>
        /// 单例
        /// </summary>
        private static PdfToXml ins;
        /// <summary>
        /// 如果需要创建索引,有一条后台线程一直在读取他
        /// 为了创建多个对象,所以使用单例
        /// </summary>
        public static PdfToXml Ins
        {
            get
            {
                if (ins == null)
                    ins = new PdfToXml();
                return ins;
            }
            //   set { FrmPdf2Xml.ins = value; }
        }

        /// <summary>
        /// 有单例,为何构造是public,因为出了一条线程在读取他还有另外一个程序在读取他
        /// </summary>
        public PdfToXml()
        {
            // components = new Container();
            InitializeComponent();
            // components.Add(this.axPMAX1);
        }

        public PdfToXml(string[] args)
            : this()
        {
            // TODO: Complete member initialization
            this.args = args;
        }

        string lastText = string.Empty;
        private string[] args;
        public string ReadPdfFile(string pdfPath)
        {
            string result = string.Empty;
            //PdfToXmlModel ptxm = obj as PdfToXmlModel;
            //string pdfPath = ptxm.PdfFile;
            //string destPath = ptxm.XmlPath;
            //List<XmlData> xds = new List<XmlData>();
            string currentText = string.Empty;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pdfPath);
            string fileName = Path.GetFileName(pdfPath);

            try
            {
                //  Log4NetManager.Ins.InfoFormat("pdf 2 xml 文件:{0}", pdfPath);
                axPMAX1.Open(pdfPath);
                int pageCount = axPMAX1.GetPageCount();
                for (int i = 1; i <= pageCount; i++)
                {
                    currentText = axPMAX1.GetPageText(i);

                    #region  这么写是没错的,如果吧lastText提取出来的话,如果一本书其中有两个页面是一模一样的话就错了
                    if (currentText.Equals(lastText))
                    {
                        lastText = currentText;
                        currentText = string.Empty;
                    }
                    else
                    {
                        lastText = currentText;
                    }
                    #endregion

                    currentText = Helper.ToDBC(currentText);
                    currentText = Helper.RemoveASCIIControlCharacter(currentText);
                    currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                    currentText = Helper.RemoveTokens(currentText);
                    result += currentText;
                    //xds.Add(new XmlData()
                    //{
                    //    DocumentID = 0,
                    //    Content = currentText,
                    //    Page = i,
                    //    File = pdfPath,
                    //});

                }
                axPMAX1.Close();

                //Common.Helper.XmlSerialize(xds, destPath);
            }
            catch (Exception ex)
            {

            }
            //if (ptxm.AutoResetPreventOpeningOvertime != null)
            //    ptxm.AutoResetPreventOpeningOvertime.Set();
            //return xds;
            return result;
        }
    }
}