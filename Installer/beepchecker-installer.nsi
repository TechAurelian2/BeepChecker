; BeepChecker Setup Program

;--------------------------------------

Unicode True

!include MUI.nsh ;Include Modern UI
!include WordFunc.nsh
!insertmacro VersionCompare
!include LogicLib.nsh
;--------------------------------------

;General

  RequestExecutionLevel admin

  ;The name of the installer
  Name "BeepChecker"

  ;The setup executable file to create
  OutFile "Output\beepchecker-installer.exe"

  ;The default installation directory
  InstallDir "$PROGRAMFILES64\TechAurelian\BeepChecker"

;--------------------------------------

;Interface Settings

  !define MUI_ABORTWARNING

;--------------------------------------

;Pages

  !insertmacro MUI_PAGE_WELCOME
  !insertmacro MUI_PAGE_LICENSE "Files\license.txt"
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES

  !define MUI_FINISHPAGE_RUN BeepChecker.exe
  !define MUI_FINISHPAGE_RUN_TEXT "Start BeepChecker"
  !insertmacro MUI_PAGE_FINISH
  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES

;--------------------------------------

;Languages

  !insertmacro MUI_LANGUAGE "English"

;--------------------------------------

;Version Information

  VIProductVersion "2.1.1.28"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "ProductName" "BeepChecker"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "Comments" "Play, test or learn the beeps of your PC"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "CompanyName" "TechAurelian"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "LegalTrademarks" ""
  VIAddVersionKey /LANG=${LANG_ENGLISH} "LegalCopyright" "Copyright (c) 2013-2023 TechAurelian (https://techaurelian.com)"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "FileDescription" "BeepChecker Installer"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "FileVersion" "2.1.1.28"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "ProductVersion" "2.1.1.28"

;--------------------------------------

Section
  ; Copy files to installation directory
  SetOutPath $INSTDIR
  File Files\BeepChecker.exe
  File Files\BeepChecker.exe.config
  File Files\license.txt

  ; Create Start Menu shortcut
  CreateShortCut "$SMPROGRAMS\BeepChecker.lnk" "$INSTDIR\BeepChecker.exe" "" "" "" SW_SHOWNORMAL "" "Play, test or learn the beeps of your PC"

  ;Create uninstaller
  WriteUninstaller "$INSTDIR\uninstall.exe"
  SetRegView 64
  WriteRegStr   HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "DisplayName" "BeepChecker"
  WriteRegStr   HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "UninstallString" "$\"$INSTDIR\uninstall.exe$\""
  WriteRegStr   HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "QuietUninstallString" "$\"$INSTDIR\uninstall.exe$\" /S"
  
  WriteRegStr   HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "DisplayVersion" "2.1.1.28"
  WriteRegStr   HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "DisplayIcon" "$\"$INSTDIR\beepchecker.exe$\""
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "EstimatedSize" "102"
  WriteRegStr   HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "HelpLink" "https://techaurelian.com/beepchecker/"
  WriteRegStr   HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "InstallLocation" "$INSTDIR"
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "NoModify" "1"
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "NoRepair" "1"
  WriteRegStr   HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "Publisher" "TechAurelian"
  WriteRegStr   HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "URLInfoAbout" "https://techaurelian.com/beepchecker/"
  WriteRegStr   HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "URLUpdateInfo" "https://techaurelian.com/beepchecker/"
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "VersionMajor" "2"
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker" "VersionMinor" "1"
SectionEnd

;--------------------------------------

;Uninstaller Section

Section "Uninstall"

  ; Delete files from installation directory
  Delete "$INSTDIR\uninstall.exe"
  Delete "$INSTDIR\BeepChecker.exe"
  Delete "$INSTDIR\BeepChecker.exe.config"
  Delete "$INSTDIR\license.txt"
  RMDir "$INSTDIR"
  RMDir "$PROGRAMFILES64\TechAurelian"

  ; Delete Start Menu shortcut
  Delete "$SMPROGRAMS\BeepChecker.lnk"

  ; Delete Uninstall registry key
  SetRegView 64
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BeepChecker"

SectionEnd