using UnityEngine;

public class JsonFileManager
{
    /// <summary>
    /// 問題データをファイルから読み込んでData型で返す
    /// </summary>
    /// <param name="questionData">TextAsset</param>
    /// <returns>Data</returns>
    public static Data Load(TextAsset questionData) {
        return JsonUtility.FromJson<Data>(questionData.text);
    }
}