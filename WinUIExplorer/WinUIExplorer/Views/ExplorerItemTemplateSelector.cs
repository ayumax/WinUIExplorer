using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUIExplorer.ViewModels;

namespace WinUIExplorer.Views
{
    class ExplorerItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FolderTemplate { get; set; }
        public DataTemplate FileTemplate { get; set; }

        public DataTemplate ImageFileTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            return item switch
            {
                DirectoryTreeViewItemViewModel directory => FolderTemplate,
                ImageTreeViewItemViewModel image => ImageFileTemplate,
                _ => FileTemplate,
            };

        }
    }
}
