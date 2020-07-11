using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIExplorer.ViewModels
{
    class ImageTreeViewItemViewModel : TreeViewItemViewModel
    {
        public BitmapImage Image => new BitmapImage(new Uri(this.Path));
    }
}
