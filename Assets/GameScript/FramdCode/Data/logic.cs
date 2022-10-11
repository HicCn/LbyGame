public class logic
{
    public static int[] GetNextStory(int id)
    {
        var item = Luban.Instane().TBlogic.Get(id);
        return item.NextStory;
    }


}
