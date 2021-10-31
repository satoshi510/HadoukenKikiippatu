using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningController : MonoBehaviour
{
    //他のシーンに難易度の値を送る変数を宣言
    public static int difficult;

    //ハイスコアを記録する変数
    public static int highscore = 0;

    //ハイスコアの表示用の変数を宣言
    GameObject Highscoretext;

    //説明ボタンを押したら出るボタンと図
    GameObject maebutton;
    GameObject tugibutton;
    GameObject maeText;
    GameObject tugiText;
    GameObject[] page = new GameObject[12];
    int pagesuu;


    // Start is called before the first frame update
    void Start()
    {
        Highscoretext = GameObject.Find("HighScoreText");
        maebutton = GameObject.Find("maebutton");
        tugibutton = GameObject.Find("tugibutton");
        maeText = GameObject.Find("maeText");
        tugiText = GameObject.Find("tugiText");



        for(int i = 0; i<12; i++)
        {
            page[i] = GameObject.Find("page" + i);
            page[i].SetActive(false);
        }

        maebutton.SetActive (false);
        tugibutton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Highscoretext.GetComponent<Text>().text = "ハイスコア:" + highscore + "点"; 


        if(pagesuu == 0)
        {
            maeText.GetComponent<Text>().text = "閉じる";
            tugiText.GetComponent<Text>().text = "次へ";
        }
        else if(pagesuu >=1 && pagesuu <=10)
        {
            maeText.GetComponent<Text>().text = "前へ";
            tugiText.GetComponent<Text>().text = "次へ";
        }
        else if(pagesuu ==11)
        {
            maeText.GetComponent<Text>().text = "前へ";
            tugiText.GetComponent<Text>().text = "閉じる";
        }



    }

    //ゲームスタートボタンをクリックしたときの処理
    public void StartButtonDown()
    {
        difficult = 1;
        SceneManager.LoadScene("SampleScene");
    }

    //ゲームスタート2ボタンをクリックしたときの処理
    public void StartButton2Down()
    {
        difficult = 2;
        SceneManager.LoadScene("SampleScene");
    }

    //説明ボタンをクリックしたときの処理
    public void SetumeiButtonDown()
    {
        maebutton.SetActive(true);
        tugibutton.SetActive(true);

        for (int i = 0; i < 12; i++)
        {
            page[i].SetActive(true);
        }

        pagesuu = 0;

    }

    public void tugiButtonDown()
    {

        if(pagesuu == 11)
        {
            for (int i = 0; i < 12; i++)
            {
                page[i].SetActive(false);
            }

            maebutton.SetActive(false);
            tugibutton.SetActive(false);
        }
         if(pagesuu>=0 && pagesuu <=10)
        {
           page[pagesuu].SetActive (false);
           pagesuu++;
        }
    }

    public void maeButtonDown()
    {

        if (pagesuu == 0)
        {
            for (int i = 0; i < 12; i++)
            {
                page[i].SetActive(false);
            }

            maebutton.SetActive(false);
            tugibutton.SetActive(false);
        }       
        if (pagesuu >= 1 && pagesuu <= 11)
        {
            pagesuu--;
            page[pagesuu].SetActive(true);
        }
    }

}
