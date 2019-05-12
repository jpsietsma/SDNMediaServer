namespace MediaClasses.Classes
{
    public interface ITelevisionEpisode
    {
        TelevisionSeason TelevisionSeason { get; set; }
        TelevisionShow TelevisionShow { get; set; }
    }
}