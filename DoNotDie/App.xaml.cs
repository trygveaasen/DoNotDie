using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace DoNotDie
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        MenuItem keepAlive = new MenuItem("Keep alive");
        MenuItem die = new MenuItem("Let die");
        public App() 
        {
            var icon = new NotifyIcon();

            icon.Icon = new Icon(System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/spy.ico")).Stream);
            icon.ContextMenu = new ContextMenu();
            keepAlive.Visible = false;
            keepAlive.Click += KeepAlive_Click;

            die.Click += Die_Click;
            icon.ContextMenu.MenuItems.Add(keepAlive);
            icon.ContextMenu.MenuItems.Add(die);
            icon.Visible = true;


            UpdateVisibility();
            App.Current.Startup += Current_Startup;
        }

        private void Current_Startup(object sender, StartupEventArgs e)
        {
            Live(true);
        }

        private void Die_Click(object sender, EventArgs e)
        {
            Live(false);
        }

        private void KeepAlive_Click(object sender, EventArgs e)
        {
            Live(true);
        }

        void Live(bool live)
        {
            if (live)
            {
                ThreadState.KeepAlive();
            }
            else
            {
                ThreadState.LetDie();
            }
            UpdateVisibility();
        }

        void UpdateVisibility()
        {
            keepAlive.Visible = !ThreadState.StayingAlive;
            die.Visible = ThreadState.StayingAlive;
        }
    }
}
