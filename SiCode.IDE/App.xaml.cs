﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using SiCodeIDE;
using Wpf.Ui.Appearance;
using Wpf.Ui.Markup;

namespace SiCode.IDE
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // WPF default app startup routines
            base.OnStartup(e);

            // Show startup screen
            Startup s = new Startup();
            s.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            s.Show();

            // Load SiCode IDE configuration

            if (!Directory.Exists(Configuration.ConfigDir))
            {
                Directory.CreateDirectory(Configuration.ConfigDir);
            }
            if (!Directory.Exists(Configuration.RecentProjectsDir))
            {
                Directory.CreateDirectory(Configuration.RecentProjectsDir);
            }

            Configuration.LoadConfig();

            // Set theme
            SetTheme((ThemeType)Configuration.Theme);

            // Wait
            Thread.Sleep(1500);

            // Close startup screen & show main window
            s.Hide();

            SiCode.IDE.HomeWindow w = new SiCode.IDE.HomeWindow();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
        }

        public void SetTheme(ThemeType t)
        {
            ((ThemesDictionary)Resources.MergedDictionaries[0]).Theme = t;
        }
    }
}
