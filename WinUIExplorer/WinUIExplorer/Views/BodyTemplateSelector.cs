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
    class BodyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FolderTemplate { get; set; }
        public DataTemplate TextFileTemplate { get; set; }

        public DataTemplate ImageFileTemplate { get; set; }


        protected override DataTemplate SelectTemplateCore(object item)
        {
            return item switch
            {
                DirectoryTreeViewItemViewModel directory => FolderTemplate,
                ImageTreeViewItemViewModel image => ImageFileTemplate,
                _ => TextFileTemplate,
            };

        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectTemplateCore(item);
        }
    }
}
