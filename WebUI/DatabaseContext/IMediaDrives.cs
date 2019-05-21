namespace WebUI.DatabaseContext
{
    public interface IMediaDrives
    {
        string DriveLetter { get; set; }
        string DriveMediaType { get; set; }
        string MediaLibraryPath { get; set; }
        int PkDriveId { get; set; }
    }
}