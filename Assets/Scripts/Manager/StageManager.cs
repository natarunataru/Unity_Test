using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    //ステージ情報
    [SerializeField][Header("ステージ名")] private string stageName;
    [SerializeField] [Header("難易度")] private int stageDifficulty;

    //ステージ進行時間の管理
    private float stageTime;
    private bool isPaused; //ポーズ中フラグ

    //CSVファイルパス
    private const string csvDirectory = "Assets/Data/csv/";
    private string csvFilePath;


    void Start()
    {
        //Gamemanagerからステージ情報を取得


        //CSVファイルパスの設定
        csvFilePath = csvDirectory + stageName + ".csv";



        //CSVファイルの読み込み
        //LoadEnemyDataFromCSV()
        
        //ステージ進行時間の初期化
        stageTime = 0f;
        isPaused = false;
    }

    void Update()
    {
        
    }
}
