using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using log4net;
using RecordCase.Core.System;
using RecordCase.UI.Properties;
using RecordCase.UI.Services;

namespace RecordCase.WPF.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static RelayCommand closeCommand;
        public static RelayCommand CloseCommand
        {
            get
            {
                return closeCommand ?? (closeCommand = new RelayCommand(Close));
            }

        }

        static App()
        {
            //log4net.Config.XmlConfigurator.Configure();
            if (!Directory.Exists(AppProps.AppDataFolder))
                Directory.CreateDirectory(AppProps.AppDataFolder);
        }

        internal static void Close()
        {
            CollectionsService.SaveRecordCollection();
        }
    }
}
