using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySystemCSVReader;

public class StageManager : MonoBehaviour
{
    //ステージ情報
    [SerializeField] [Header("ステージ名")] private string stageName;
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
        LoadEnemyDataFromCSV();

        //ステージ進行時間の初期化
        stageTime = 0f;
        isPaused = false;
    }

    void Update()
    {
        //ステージ進行時間の更新
        if (!isPaused)
        {
            stageTime += Time.deltaTime;
        }
    }

    private void LoadEnemyDataFromCSV()
    {
        //ファイル読み込み処理
        List<string[]> csvData = CSVReader.ReadCSVFile(csvFilePath);

        //読み取り値の設定
        for(int i = 0; i < csvData.Count; i++)
        {
            string[] rowData = csvData[i];
            float spawnTime = float.Parse(rowData[0]); //出現開始時間
            float posX = float.Parse(rowData[1]); //出現X座標
            float posY = float.Parse(rowData[2]); //出現Y座標
            float posZ = float.Parse(rowData[3]); //出現Z座標
            float moveSpeed = float.Parse(rowData[4]); //移動速度
            string enemySetting = rowData[5]; //敵プレファブのファイルパス
            string pathSetting = rowData[6]; //スプラインプレファブのファイルパス
            
        }
        
    }

    //一時停止処理
    public void PauseStage()
    {
        isPaused = true;
    }

    //再開処理
    public void ResumeStage()
    {
        isPaused = false;
    }

    //ステージ終了処理
    public void FnishStage()
    {

    }

    //ステージ内計算処理
    public void CalulateStageScore()
    {
        //ステージスコアの計算


        //ステージ終了時のスコアデータの更新
    }


}
