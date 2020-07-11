using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIExplorer.ViewModels
{
    class TreeViewItemViewModel
    {
        public string Path { get; set; }

        public string Name => System.IO.Path.GetFileName(Path);

    }
}
