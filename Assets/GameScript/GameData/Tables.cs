//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using SimpleJSON;


namespace cfg
{ 
   
public sealed partial class Tables
{
    public Tbtextual Tbtextual {get; }
    public TBlogic TBlogic {get; }
    public song.Tbtest Tbtest {get; }

    public Tables(System.Func<string, JSONNode> loader)
    {
        var tables = new System.Collections.Generic.Dictionary<string, object>();
        Tbtextual = new Tbtextual(loader("tbtextual")); 
        tables.Add("Tbtextual", Tbtextual);
        TBlogic = new TBlogic(loader("tblogic")); 
        tables.Add("TBlogic", TBlogic);
        Tbtest = new song.Tbtest(loader("song_tbtest")); 
        tables.Add("song.Tbtest", Tbtest);
        PostInit();

        Tbtextual.Resolve(tables); 
        TBlogic.Resolve(tables); 
        Tbtest.Resolve(tables); 
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        Tbtextual.TranslateText(translator); 
        TBlogic.TranslateText(translator); 
        Tbtest.TranslateText(translator); 
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}