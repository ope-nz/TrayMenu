# TrayMenu
A replacement of the tray toolbar function that removed from Windows 11

Inspired by https://github.com/rojarsmith/TrayToolbar

While TrayToolbar works fine I wanted a pure .Net solution and it annoyed me that it showed file extensions for shortcuts.

My version just adds any shortcut files (*.lnk) in the same directory to a right/left click context menu. Click these will launch the shortcut using Process.Start.
