public interface songBasic
{
    public long GetGenerationTime(int id);
    public int GetGenerationType(int id);
    public int GetLen();
    public bool GetIsEnd(int id);
    public char GetIsButton(int id);
}