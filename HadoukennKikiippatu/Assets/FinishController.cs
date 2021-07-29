using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishController : MonoBehaviour
{
    //タイマー
    float timer = 0;

    //クリアタイム
    float cleartime = 0;

    //クリア判定
    bool clearhanntei = false;
    //ゲームオーバー判定
    bool gameoverhanntei = false;

    //スコア
    int clearscore = 0;

    //オブジェクト
    GameObject KeshikataButtons;
    GameObject PaneruButtons;
    GameObject PlayTexts;
    GameObject ButtonBlocks;
    GameObject ClearScoreText;
    GameObject ClearTimeText;
    GameObject ScoreSumText;




    // Start is called before the first frame update
    void Start()
    {
        //クリア時消すオブジェクトを取り込む
        KeshikataButtons = GameObject.Find("KeshikataButtons");
        PaneruButtons = GameObject.Find("PaneruButtons");
        PlayTexts = GameObject.Find("PlayTexts");
        ButtonBlocks = GameObject.Find("ButtonBlocks");

        //クリア時表示するテキストを取り込む
        ClearScoreText = GameObject.Find("ClearScoreText");
        ClearTimeText = GameObject.Find("ClearTimeText");
        ScoreSumText = GameObject.Find("ScoreSumText");

        //クリア時表示するテキストを非アクティブ化する
        ClearScoreText.SetActive(false);
        ClearTimeText.SetActive(false);
        ScoreSumText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //クリア後処理
        if(clearhanntei == true)
        {
            if (timer > 0.5f) //制限時間5分
            {
                ClearTimeText.GetComponent<Text>().text = "タイム:" + ((300 - cleartime) * 5).ToString("f0") + "点";
            }
            if (timer>1f)
            {
                ClearScoreText.GetComponent<Text>().text = "スコア:" + clearscore.ToString("f0") + "点";
            }
            if(timer>2f)
            {
                ScoreSumText.GetComponent<Text>().text = "合計:" + (clearscore + ((300 - cleartime) * 5)).ToString("f0") + "点";
            }
        }

        //ゲームオーバー後処理
        if (gameoverhanntei == true)
        {
            if (timer > 0.5f)
            {
                ClearTimeText.GetComponent<Text>().fontSize = 200;
                ClearTimeText.GetComponent<Text>().text = "GAMEOVER";
            }
            if (timer > 1.5f)
            {
                ScoreSumText.GetComponent<Text>().text = "合計:" + clearscore.ToString("f0") + "点";
            }
        }


    }

    //クリア時に呼び出される関数
    public void Clear(int x)
    {
        //ゲーム中のものを削除
        Destroy(KeshikataButtons);
        Destroy(PaneruButtons);
        Destroy(PlayTexts);
        Destroy(ButtonBlocks);

        //クリア後のテキストをアクティブ化
        ClearScoreText.SetActive(true);
        ClearTimeText.SetActive(true);
        ScoreSumText.SetActive(true);

        //PaneruControllerからスコアを得る
        clearscore = x;

        cleartime = timer;
        timer = 0;
        clearhanntei = true;
    }

    //ゲームオーバー時に呼び出される関数
    public void GameOver(int x)
    {
        //ゲーム中のものを削除
        Destroy(KeshikataButtons);
        Destroy(PaneruButtons);
        Destroy(PlayTexts);
        Destroy(ButtonBlocks);

        //クリア後のテキストをアクティブ化
        ClearScoreText.SetActive(true);
        ClearTimeText.SetActive(true);
        ScoreSumText.SetActive(true);

        //PaneruControllerからスコアを得る
        clearscore = x;

        timer = 0;
        gameoverhanntei = true;
    }

}
