namespace StartPagePlus.UI.Services
{
    public interface INewsItem
    {
        string Name { get; }
        string Description { get; }
        string Date { get; }
        string Link { get; }
    }
}