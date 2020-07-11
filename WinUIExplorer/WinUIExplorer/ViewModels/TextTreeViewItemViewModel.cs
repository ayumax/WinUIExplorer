using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIExplorer.ViewModels
{
    class TextTreeViewItemViewModel : TreeViewItemViewModel
    {
        public string Body
        {
            get
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    return sr.ReadToEnd();
                }
            }

        }

        public TextTreeViewItemViewModel()
        {
        }
    }
}
