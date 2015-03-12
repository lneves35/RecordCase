﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using log4net;

namespace RecordCase.WPF.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
                       
            base.OnStartup(e);

            log4net.Config.XmlConfigurator.Configure(); 

            if (RecordCase.UI.Properties.Settings.Default.DatabaseCollection == null)
                RecordCase.UI.Properties.Settings.Default.DatabaseCollection = new StringCollection();

            
        }
    }
}
