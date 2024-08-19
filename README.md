# yt-dlp GUI. (work in progress) <img align="right" height="40" src="/assets/logo.png">

A _very_ simple Windows Forms app to use [yt-dlp](https://github.com/yt-dlp/yt-dlp) without touching a terminal.

<p align="center">
    <img width="432" alt="Screenshot of the UI." src="/assets/Screenshot_dark.svg">
</p>

## Why "_very_" simple?

If you direct your eyeballs towards the screenshot above you'll (hopefully) see why.

Most of the time you (probably) don't want to fiddle with every little setting and flag that yt-dlp has to offer. I know I don't. I'm writing this to be as simple as entering a video or playlist URL, selecting the desired format and hitting download.

Also, this is my first attempt at writing a C# app in almost a decade and I have basically no prior experience with it. Ctrl, C and V have been used extensively in the making of this program.

## Installing.

Simply download and run the [latest ytdg_setup.exe](../../releases/latest/download/ytdg_setup.exe).

You need at least Windows 10 version 1809.

## Building.

### The program.

Clone the repository and open the solution (.sln) in Visual Studio. Make sure you have the .NET desktop development tools installed for this.

Take a look in the top left corner of your screen, select "Release" in the first dropdown and press F6 (or select "Build Solution" from the "Build" menu at the top).

You can find the compiled program in yt-dlp-GUI\bin.

### The setup.

Install [Inno Setup](https://jrsoftware.org/isinfo.php) and open the "Setup.iss" in the Setup directory. The script expects the following files in the "deps" subdirectory (unless of course you just delete the lines that ask for these):

- [yt-dlp.exe](https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe)
- [ffmpeg.exe and ffprobe.exe](https://github.com/yt-dlp/FFmpeg-Builds/releases/download/latest/ffmpeg-master-latest-win64-gpl.zip) (Can be found in the "bin" folder inside the ZIP.)
- [windowsdesktop-runtime-8.0.8-win-x64.exe](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.8-windows-x64-installer)

Put all these .exes in the "utils" folder, click the "Compile" button in the top left and if it all goes well, you'll end up with a setup exe in the "Output" directory.

## Contributing.

If you have any suggestions for improvements, feel free to fork it and create a PR. If you want to introduce any major changes, talk to me about them first. Just keep in mind that my aim for this program is to be as easy to use and simple as possible, so no feature creep.
