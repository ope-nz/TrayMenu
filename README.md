# TrayMenu
A replacement of the tray toolbar function that removed from Windows 11

Inspired by https://github.com/rojarsmith/TrayToolbar

While TrayToolbar works fine I wanted a pure .Net solution and it annoyed me that it showed file extensions for shortcuts.

TrayToolbar also hasnt been updated since late 2021 and the author does not provide the source code.

TrayMenu adds any shortcut files (*.lnk) in the same directory to a right/left click context menu. Clicking these will launch the shortcut using Process.Start.

To deploy;

1. Create a new folder eg C:\Program Files\TrayMenu
2. Copy the release files to the new folder
3. Copy any shortcuts you want to the new folder
4. Run traymenu.exe
5. You should now have a folder icon in your tray menu

Optional
1. If you want to start on Windows start-up press Win+R to open run prompt and type in shell:startup and press OK
2. Create a new shortcut to C:\Program Files\TrayMenu\traymenu.exe
3. TrayMenu should now start up with Windows
