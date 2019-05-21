namespace MediaClasses.Classes
{
    public interface IMediaDrive
    {
        string DriveLetter { get; set; }
        string DriveMediaType { get; set; }
        string MediaLibraryPath { get; set; }
        int PkDriveId { get; set; }
    }
}