public class textual
{

    public static string[] GetChapter(int id)
    {

        var item = Luban.Instane().Tbtextual.Get(id);
        return item.StoryChapter;
    }

    //public static string GetPlayInput(int id)
    //{
    //    var item = Luban.Instane().Tbtextual.Get(id);
    //    return item.PlayInput;
    //}
}
