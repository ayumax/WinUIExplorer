using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIExplorer.ViewModels
{
    class DirectoryTreeViewItemViewModel : TreeViewItemViewModel
    {
        public ObservableCollection<TreeViewItemViewModel> Children { get; } = new ObservableCollection<TreeViewItemViewModel>();
    }
}
