
using cfg.song;

public class Test : songBasic
{
    Tbtest item = Luban.Instane().Tbtest;

    public long GetGenerationTime(int id)
    {
        return item.Get(id).GenerationDowmTime;
    }
    public int GetGenerationType(int id)
    {
        return item.Get(id).GenerationType;
    }
    public int GetLen()
    {
        return item.DataList.Count;
    }

    public bool GetIsEnd(int id)
    {
        return item.Get(id).IsEnd;
    }
    public char GetIsButton(int id)
    {
        return item.Get(id).IsButton[0];
    }
}
