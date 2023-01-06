namespace InstallerViewer
{
    public enum InstallerLocation
    {
        WINDOWS_INSTALLER_MSI,
        WINDOWS_INSTALLER_EXE,
        PACKAGE_CACHE_MSI,
        PACKAGE_CACHE_EXE
    }

    public enum OpenFileType
    {
        MSI,
        EXE
    }

    public enum InstallUser
    {
        CURRENT_USER,
        LOCAL_MACHINE
    }
}