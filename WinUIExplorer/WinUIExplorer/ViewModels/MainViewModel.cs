using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinUIExplorer.ViewModels
{
    class MainViewModel
    {
        public ReactiveProperty<string> RootPath { get; }
        public ReactiveProperty<TreeViewItemViewModel> CurrentData { get; }
        public ReactiveProperty<ObservableCollection<TreeViewItemViewModel>> DataSource { get; }

        public MainViewModel()
        {
            DataSource = new ReactiveProperty<ObservableCollection<TreeViewItemViewModel>>();
            DataSource.Value = new ObservableCollection<TreeViewItemViewModel>();

            RootPath = new ReactiveProperty<string>();
            RootPath.Subscribe(x =>
            {
                DataSource.Value = new ObservableCollection<TreeViewItemViewModel>();
                if (string.IsNullOrWhiteSpace(x)) return;
                if (Directory.Exists(x) == false) return;

                DataSource.Value.Add(UpdateDataSource(x));
            });

            CurrentData = new ReactiveProperty<TreeViewItemViewModel>();

            DataSource.Value.Add(UpdateDataSource(@"C:\Users\ayuma\source\repos\WinUIExplorer"));
        }

        private TreeViewItemViewModel UpdateDataSource(string rootPath)
        {
            DirectoryTreeViewItemViewModel treeViewItemViewModel = new DirectoryTreeViewItemViewModel()
            {
                Path = rootPath
            };

            string[] directoryEntries = Directory.GetFileSystemEntries(rootPath);

            foreach (string fileOrDirectory in directoryEntries)
            {
                if (File.GetAttributes(fileOrDirectory).HasFlag(FileAttributes.Directory))
                {
                    treeViewItemViewModel.Children.Add(UpdateDataSource(fileOrDirectory));
                }
                else if (Path.GetExtension(fileOrDirectory) == ".png" || Path.GetExtension(fileOrDirectory) == ".jpg")
                {
                    treeViewItemViewModel.Children.Add(new ImageTreeViewItemViewModel()
                    {
                        Path = fileOrDirectory
                    });
                }
                else
                {
                    treeViewItemViewModel.Children.Add(new TextTreeViewItemViewModel()
                    {
                        Path = fileOrDirectory
                    });
                }
            }

            return treeViewItemViewModel;
        }
    }
}
