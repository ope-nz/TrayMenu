using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
 
namespace MyTrayApp
{
    public class SysTrayApp : Form
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new SysTrayApp());
        }
 
        private NotifyIcon  trayIcon;
        private ContextMenu trayMenu;

        private FileInfo[] fileInfo;

        private String exe = Assembly.GetExecutingAssembly().Location;
        private String home = AppDomain.CurrentDomain.BaseDirectory;
 
        public SysTrayApp()
        {
            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
           
            fileInfo = GetFilesFromFolder(home, "lnk");  
        
            foreach (FileInfo fileInfoTemp in fileInfo)  
            {  
                String name = Path.GetFileNameWithoutExtension(fileInfoTemp.Name);
                trayMenu.MenuItems.Add(name, LaunchShortcut);
            } 

            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Exit", OnExit);
 
            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon      = new NotifyIcon();
            trayIcon.Text = "Tray Menu";
			trayIcon.Icon = Icon.ExtractAssociatedIcon(exe);
 
            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible     = true;

            trayIcon.Click += new EventHandler(trayIcon_Click);
        }

        private void trayIcon_Click(object sender, EventArgs e)
        {
            MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(trayIcon, null);
        }

        private void LaunchShortcut(object sender, EventArgs e)
        {
            MenuItem m = (MenuItem)sender;
            System.Diagnostics.Process.Start(home+"\\"+m.Text+".lnk", string.Empty);
        }
 
        protected override void OnLoad(EventArgs e)
        {
            Visible       = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar. 
            base.OnLoad(e);
        }
 
        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
 
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Dispose();
            }
 
            base.Dispose(isDisposing);
        }

        private FileInfo[] GetFilesFromFolder(string folderName, string extension)  
        {  
            DirectoryInfo directoryInfo = new DirectoryInfo(folderName);  
            string internalExtension = string.Concat("*.", extension);  
            FileInfo[] fileInfo = directoryInfo.GetFiles(internalExtension, SearchOption.AllDirectories);  
            return fileInfo;  
        }
    }
}
