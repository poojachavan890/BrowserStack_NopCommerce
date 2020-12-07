namespace BrowserStack.WebTests.PrivilegeManager.TestData.Constants
{
    public static class Constant
    {
        // Folder Paths
        public const string EXE_FILES_FOLDERPATH = "C:\\Automation\\Exe files\\";
        public const string SETUP_FILES_FOLDERPATH = "C:\\Automation\\SetupFiles\\";
        public const string AGENTUTILITY_FOLDERPATH = "C:\\Program Files\\Thycotic\\Agents\\Agent\\";
        public const string SYSTEM32_FOLDERPATH = "C:\\Windows\\System32\\";
        public const string OFFLINE_UPGRADE_ZIP = "C:\\Automation\\OfflineUpgradeZip\\";
        public const string TOTAL_EXECUTION_TIME = "C:\\Automation\\TotalExecutionTime\\";
        public const string FIREFOX_FOLDERPATH = "C:\\Program Files\\Mozilla Firefox\\";
        // File Paths
        public const string FIREFOX_DMG_FILE = EXE_FILES_FOLDERPATH + "Firefox75.dmg";
        public const string CUPCAKE_EXE_FILE = EXE_FILES_FOLDERPATH + "CupCake.exe";
        public const string UPDATEPOLICY_BAT_FILE = SETUP_FILES_FOLDERPATH + "UpdatePolicy.bat";
        public const string AGENTUTILITY_FILE = AGENTUTILITY_FOLDERPATH + "Agent Utility.exe";
        public const string CMD_FILE = SYSTEM32_FOLDERPATH + "cmd.exe";
        public const string Version_10_9_000000 = OFFLINE_UPGRADE_ZIP + "Version_10_9_000000.zip";
        public const string IBM_Version_10_9_000000 = OFFLINE_UPGRADE_ZIP + "IBM\\" + "Version_10_9_000000.zip";
        public const string IBM_DOCS_XML = "doc-host-dev.xml";
        public const string ZoomInstaller_pkg = EXE_FILES_FOLDERPATH + "zoomusInstaller.pkg";
        public const string PUTTY_EXE = EXE_FILES_FOLDERPATH + "putty.exe";
        public const string COFFEE_EXE_FILE = EXE_FILES_FOLDERPATH + "Coffee.exe";
        public const string FREEZE_EXE_FILE = EXE_FILES_FOLDERPATH + "Freeze.exe";
        public const string CALC_EXE_FILE = EXE_FILES_FOLDERPATH + "calc.exe";
        public const string HELLOWORLD_EXE_FILE = EXE_FILES_FOLDERPATH + "HelloWorld.exe";
        public const string PUTTY_64BIT_073_INSTALLER_MSI_FILE = EXE_FILES_FOLDERPATH + "putty-64bit-0.73-installer.msi";
        public const string WIRESHARK_INTEL_DMG_FILE = EXE_FILES_FOLDERPATH + "Wireshark 3.0.3 Intel 64.dmg";
        public const string PERFORMANCE_ANALYZER = "PerformanceAnalyzer.csv";
        public const string FIREFOX_EXE_FILE = FIREFOX_FOLDERPATH + "firefox.exe";

        // Page Urls
        public const string FS_AUTHENTICATION_URL = "/#/configuration?tab=Authentication";
        public const string LSS_VAULT_URL = "/#/lss/vault";
        public const string SPA_URL = "/Spa/PrivilegeManager";
        public const string LogoutSignOutCallback = "/Account/SignOutCallback/";
        // IBM Branding Urls
        public const string IBM_ABOUT_TECHNICAL_SUPPORT_URL = "https://www.ibm.com/mysupport/s/topic/0TO50000000IVs5GAG/security-secret-server?language=en_US&productId=01t50000004ufoNAAQ";
        public const string IBM_ABOUT_FEEDBACK_URL = "https://www.ibm.com/developerworks/rfe/?BRAND_ID=301";
        public const string IBM_ABOUT_DOCUMENTATION_URL = "https://www.ibm.com/support/knowledgecenter/SSWHLP";
        public const string IBM_TMS_FOOTER_URL = "https://www.ibm.com/security";
        public const string IBM_TMS_HELP_URL = "https://www.ibm.com/support/knowledgecenter/en/SSWHLP";
        public const string IBM_AGENTS_KB_IMP_URL = "http://public.dhe.ibm.com/software/security/products/isss/";
        public const string IBM_AGENTS_KB_URL = "https://www.ibm.com/support/pages/node/713591";
        public const string IBM_HELP_DOCUMENTATION_URL = "http://public.dhe.ibm.com/software/security/products/isss/";
        public const string IBM_CONFIGURE_AZUREAD_URL = "https://supportcontent.ibm.com/support/pages/setting-azure-active-directory-integration-privilege-manager";

        public const string IBM_KB_ARTICLE_HREF = "https://thy.center/privman/link/IBMAVExclusions?version=10.8.0";
        public const string IBM_GETTING_STARTED_HREF = "#/help/getting-started";
        public const string IBM_ONLINE_GUIDE_HREF = "https://thy.center/privman/link/IBMGettingStartedPM?version=10.8.0";
        public const string IBM_AD_READ_MORE_HREF = "https://thy.center/privman/link/IBMPrivilegeManagerADSync?version=10.8.0";
        public const string IBM_HELP_DOCUMENTATION_HREF = "https://thy.center/privman/link/IBMUserGuidePM?version=10.8.0";
        public const string IBM_TMS_HELP_URL_HREF = "https://updates.thycotic.net/link.ashx?IBMSupport";

        public const string VIRUS_TOTAL_API_TOKEN = "97043e06cd8497bfa1571f20d5c375a1cd456b2436ff8193b44e6b306b614962";

        public const string BROWSER = "browser";
        public const string ENVIRONMENT = "Environment";
        public const string ONPREM = "OnPrem";
        public const string CLOUD = "Cloud";
        public const string PMONLY = "PMOnly";
        public const string RC_SETUP = "RC_ssSetUp";
        public const string UPGRADE = "Upgrade";
        public const string FIREFOX = "Firefox";

    }
}
