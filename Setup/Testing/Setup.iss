#define BuildFiles "..\..\yt-dlp-GUI\bin\Release\net8.0-windows10.0.17763.0"
#define Version "1.2.0"

[Setup]
AppName=yt-dlp GUI TEST
AppVersion={#Version}
AppPublisher=pprmint.
AppPublisherURL=https://pprmint.art/
AppCopyright=Copyright © 2024 pprmint.
DefaultGroupName=yt-dlp GUI TEST
VersionInfoVersion={#Version}
WizardStyle=modern
MinVersion=10.0.17763
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64
UninstallDisplayIcon={app}\yt-dlp-gui.exe
Compression=lzma2
SolidCompression=yes
DefaultDirName={autopf}\pprmint\yt-dlp GUI TEST
LicenseFile=License.txt
SetupIconFile=icon.ico
WizardImageFile=wizardimage100.bmp,wizardimage125.bmp,wizardimage150.bmp,wizardimage175.bmp,wizardimage200.bmp,wizardimage225.bmp,wizardimage250.bmp
WizardSmallImageFile=smallimage100.bmp,smallimage125.bmp,smallimage150.bmp,smallimage175.bmp,smallimage200.bmp,smallimage225.bmp,smallimage250.bmp
OutputBaseFilename=ytdg_setup

[Tasks]
Name: desktopIcon; Description: "Desktop icon"; GroupDescription: "Additional icons:";
Name: startMenuIcon; Description: "Start Menu icon"; GroupDescription: "Additional icons:"

[Files]
Source: "..\utils\windowsdesktop-runtime-8.0.0-win-x64.exe";  DestDir: {tmp}; Flags: deleteafterinstall; AfterInstall: InstallFramework; Check: FrameworkIsNotInstalled
Source: "{#BuildFiles}\yt-dlp-gui.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildFiles}\yt-dlp-gui.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildFiles}\yt-dlp-gui.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\utils\yt-dlp.exe"; DestDir: "{app}\utils"; Flags: ignoreversion
Source: "..\utils\ffmpeg.exe"; DestDir: "{app}\utils"; Flags: ignoreversion
Source: "..\utils\ffprobe.exe"; DestDir: "{app}\utils"; Flags: ignoreversion

[Dirs]
Name: "{app}\temp"; Permissions: users-modify

[Code]
function FrameworkIsNotInstalled: Boolean;
var
  Version: string;
begin
  if not RegKeyExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\dotnet\Setup\InstalledVersions\x64\sharedhost') then
    Result := True
  else
  begin
    if not RegQueryStringValue(HKEY_LOCAL_MACHINE, 'SOFTWARE\dotnet\Setup\InstalledVersions\x64\sharedhost', 'Version', Version) then
      Result := True
    else
      Result := Version <> '8.0.0';
  end;
end;

procedure InstallFramework;
var
  StatusText: string;
  ResultCode: Integer;
begin
  StatusText := WizardForm.StatusLabel.Caption;
  WizardForm.StatusLabel.Caption := 'Installing .NET framework...';
  WizardForm.ProgressGauge.Style := npbstMarquee;
  try
    if not Exec(ExpandConstant('{tmp}\windowsdesktop-runtime-8.0.0-win-x64.exe'), '/q /norestart', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then
    begin
      MsgBox('.NET installation failed with code: ' + IntToStr(ResultCode) + '.',
      mbError, MB_OK);
    end;    
  finally
    WizardForm.StatusLabel.Caption := StatusText;
    WizardForm.ProgressGauge.Style := npbstNormal;
  end;
end;

[Icons]
Name: "{commondesktop}\yt-dlp GUI TEST"; Filename: "{app}\yt-dlp-gui.exe"; Comment: "Download video and audio using yt-dlp."; Tasks: desktopIcon
Name: "{commonstartmenu}\yt-dlp GUI TEST"; Filename: "{app}\yt-dlp-gui.exe"; Comment: "Download video and audio using yt-dlp."; Tasks: startMenuIcon