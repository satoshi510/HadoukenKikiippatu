using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    int scoresum = 0;

    //オブジェクト
    GameObject KeshikataButtons;
    GameObject Paneruset;
    GameObject PlayTexts;
    GameObject ButtonBlocks;
    GameObject PaneruController;
    GameObject ClearScoreText;
    GameObject ClearTimeText;
    GameObject ScoreSumText;
    GameObject RetryButton;
    GameObject MainMenuButton;
    GameObject wall;
    GameObject kariwall;
    GameObject panchiaction;
    GameObject BGM;



    // Start is called before the first frame update
    void Start()
    {
        //クリア時消すオブジェクトを取り込む
        KeshikataButtons = GameObject.Find("KeshikataButtons");
        Paneruset = GameObject.Find("Paneruset");
        PlayTexts = GameObject.Find("PlayTexts");
        ButtonBlocks = GameObject.Find("ButtonBlocks");
        PaneruController = GameObject.Find("PaneruController");
        RetryButton = GameObject.Find("RetryButton");
        MainMenuButton = GameObject.Find("MainMenuButton");
        wall = GameObject.Find("wall");
        kariwall = GameObject.Find("kariwall");
        panchiaction = GameObject.Find("panchiaction");
        BGM = GameObject.Find("BGM");

        //クリア時表示するテキストを取り込む
        ClearScoreText = GameObject.Find("ClearScoreText");
        ClearTimeText = GameObject.Find("ClearTimeText");
        ScoreSumText = GameObject.Find("ScoreSumText");

        //クリア時表示するテキストを非アクティブ化する
        ClearScoreText.SetActive(false);
        ClearTimeText.SetActive(false);
        ScoreSumText.SetActive(false);
        RetryButton.SetActive(false);
        MainMenuButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //クリア後処理
        if(clearhanntei == true)
        {
            if (timer > 0.5f) //制限時間3分
            {
                ClearTimeText.GetComponent<Text>().text = "タイム:" + ((180 - cleartime) * 5).ToString("f0") + "点";
            }
            if (timer>1f)
            {
                ClearScoreText.GetComponent<Text>().text = "スコア:" + clearscore.ToString("f0") + "点";
            }
            if(timer>2f)
            {
                scoresum = Mathf.FloorToInt(clearscore + ((180 - cleartime) * 5));
                ScoreSumText.GetComponent<Text>().text = "合計:" + scoresum.ToString("f0") + "点";
            }
            if (timer > 3f)
            {
                //ボタンの表示
                RetryButton.SetActive(true);
                MainMenuButton.SetActive(true);
                OpeningController.highscore = scoresum;
            }
        }

        //ゲームオーバー後処理
        if (gameoverhanntei == true)
        {
            if (timer > 2f)
            {
                ClearTimeText.GetComponent<Text>().fontSize = 200;
                ClearTimeText.GetComponent<Text>().text = "GAMEOVER";
            }
            if (timer > 2.5f)
            {
                ScoreSumText.GetComponent<Text>().text = "合計:" + clearscore.ToString("f0") + "点";
            }
            if (timer > 4f)
            {
                //ボタンの表示
                RetryButton.SetActive(true);
                MainMenuButton.SetActive(true);
                OpeningController.highscore = clearscore;
            }
        }


    }

    //クリア時に呼び出される関数
    public void Clear(int x)
    {
        //ゲーム中のものを削除
        Destroy(KeshikataButtons);
        Destroy(Paneruset);
        Destroy(PlayTexts);
        Destroy(ButtonBlocks);
        Destroy(PaneruController);
        Destroy(wall);
        Destroy(panchiaction);
        Destroy(BGM);

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
        Destroy(Paneruset);
        Destroy(PlayTexts);
        Destroy(ButtonBlocks);
        Destroy(PaneruController);
        Destroy(wall);
        Destroy(kariwall);
        Destroy(panchiaction);
        Destroy(BGM);

        //クリア後のテキストをアクティブ化
        ClearTimeText.SetActive(true);
        ScoreSumText.SetActive(true);

        //各テキストの色を白にする
        ClearTimeText.GetComponent<Text>().color = Color.white;
        ScoreSumText.GetComponent<Text>().color = Color.white;

        //PaneruControllerからスコアを得る
        clearscore = x;

        timer = 0;
        gameoverhanntei = true;
    }

    public void RetryButtonDown()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MainMenuButtonDown()
    {
        SceneManager.LoadScene("OpeningScene");
    }

}
