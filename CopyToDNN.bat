@ECHO OFF
REM   xcopy reference:  http://www.microsoft.com/resources/documentation/windows/xp/all/proddocs/en-us/ntcmds.mspx?mfr=true

SET DnnDirectory=c:\web\TagYourRep\
SET ModuleFolder=GravityWorks-GenericHtmlRenderer

ECHO.
ECHO - Copying .dll's
xcopy /y /q "%~dp0bin\*.dll" "%DnnDirectory%bin\"

ECHO.
ECHO - Copying .ascx files
xcopy /s /y /q "%~dp0*.ascx" "%DnnDirectory%DesktopModules\%ModuleFolder%\"
xcopy /s /y /q "%~dp0Views\*.ascx" "%DnnDirectory%DesktopModules\%ModuleFolder%\Views\"

ECHO.
ECHO - Copying .aspx files
xcopy /s /y /q "%~dp0*.aspx" "%DnnDirectory%DesktopModules\%ModuleFolder%\"
xcopy /s /y /q "%~dp0*.ashx" "%DnnDirectory%DesktopModules\%ModuleFolder%\"

ECHO.
ECHO - Copying images directory
xcopy /s /y /q "%~dp0images\*.*" "%DnnDirectory%DesktopModules\%ModuleFolder%\images\"
xcopy /s /y /q "%~dp0html\*.*" "%DnnDirectory%DesktopModules\%ModuleFolder%\html\"

ECHO.
ECHO - Copying CSS, JS files
xcopy /s /y /q "%~dp0*.css" "%DnnDirectory%DesktopModules\%ModuleFolder%\"
xcopy /s /y /q "%~dp0*.js" "%DnnDirectory%DesktopModules\%ModuleFolder%\"
xcopy /s /y /q "%~dp0*.png" "%DnnDirectory%DesktopModules\%ModuleFolder%\"
xcopy /s /y /q "%~dp0*.gif" "%DnnDirectory%DesktopModules\%ModuleFolder%\"
xcopy /s /y /q "%~dp0*.jpg" "%DnnDirectory%DesktopModules\%ModuleFolder%\"