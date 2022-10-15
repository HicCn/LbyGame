using SimpleJSON;
using System.IO;
using cfg;
using UnityEngine;

public class Luban 
{
    private static Tables TableServe;
    private Luban()
    {

    }

    public static Tables Instane()
    {

        TableServe ??= new Tables(Loader);
        return TableServe;
    }

    private static JSONNode Loader(string filename)
    {
        return JSON.Parse(File.ReadAllText(Application.dataPath + "/TableData/Luban/" + filename + ".json"));
    }
}
