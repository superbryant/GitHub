
using ClassLibrary1;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Pdf2Text
{
    class ViewModel : BindableBase, IContainerControl
    {
        public ViewModel()
        {
            SelectPathCommand = new DelegateCommand(new Action(SelectPathCommandTarget)); 
        }
      
        private void SelectPathCommandTarget()
        {
            FilePath = AchillesLibrary.DialogHelper.ShowOpenFileDialog();

            Content = PdfToXml.Ins.ReadPdfFile(FilePath);
             
        }
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                OnPropertyChanged("FilePath");
            }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }
        public DelegateCommand SelectPathCommand { get; set; }


        public bool ActivateControl(Control active)
        {
            throw new NotImplementedException();
        }

        public Control ActiveControl
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
