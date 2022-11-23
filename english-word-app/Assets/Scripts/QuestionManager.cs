using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    // 選択肢の数
    private const int SELECTION_NUM = 4;
    // 英単問題データ
    [SerializeField] private TextAsset _questionData;
    // 英単語テキスト
    [SerializeField] private Text _englishWordText = default;
    // 選択肢のテキスト
    [SerializeField] private Text[] _japaneseButtonText = new Text[SELECTION_NUM];
    // 正解ID
    private int _correctId = -1;

    private void Start() {
        Create();
    }

    /// <summary>
    /// 問題を作成する
    /// </summary>
    public void Create() {
        // 英単データを読み込む
        Data data = JsonFileManager.Load(_questionData);
        // ランダムに問題を4つ選ぶ（重複無し）
        Question[] questions = new Question[SELECTION_NUM];
        List<int> rand = new List<int>();
        for(int i = 0; i < data.datas.Count; i++) {
            rand.Add(i);
        }
        for(int i = 0; i < SELECTION_NUM; i++) {
            int id = rand[Random.Range(0, rand.Count)];
            rand.Remove(id);
            questions[i] = data.datas[id];
        }
        // 正解IDを決定
        _correctId = Random.Range(0, SELECTION_NUM);
        // 画面に表示する
        _englishWordText.text = questions[_correctId].english;
        for(int i = 0; i < SELECTION_NUM; i++) {
            _japaneseButtonText[i].text = questions[i].japanese[Random.Range(0, questions[i].japanese.Count)];
        }
    }

    /// <summary>
    /// 選択肢を選択する
    /// </summary>
    /// <param name="id"></param>
    public void Slect(int id) {
        if(_correctId == id) {
            Debug.Log("正解");
            Create();
        }
        else {
            Debug.Log("不正解");
        }
    }
}
