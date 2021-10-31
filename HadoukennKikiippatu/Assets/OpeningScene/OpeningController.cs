using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningController : MonoBehaviour
{
    //���̃V�[���ɓ�Փx�̒l�𑗂�ϐ���錾
    public static int difficult;

    //�n�C�X�R�A���L�^����ϐ�
    public static int highscore = 0;

    //�n�C�X�R�A�̕\���p�̕ϐ���錾
    GameObject Highscoretext;

    //�����{�^������������o��{�^���Ɛ}
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
        Highscoretext.GetComponent<Text>().text = "�n�C�X�R�A:" + highscore + "�_"; 


        if(pagesuu == 0)
        {
            maeText.GetComponent<Text>().text = "����";
            tugiText.GetComponent<Text>().text = "����";
        }
        else if(pagesuu >=1 && pagesuu <=10)
        {
            maeText.GetComponent<Text>().text = "�O��";
            tugiText.GetComponent<Text>().text = "����";
        }
        else if(pagesuu ==11)
        {
            maeText.GetComponent<Text>().text = "�O��";
            tugiText.GetComponent<Text>().text = "����";
        }



    }

    //�Q�[���X�^�[�g�{�^�����N���b�N�����Ƃ��̏���
    public void StartButtonDown()
    {
        difficult = 1;
        SceneManager.LoadScene("SampleScene");
    }

    //�Q�[���X�^�[�g2�{�^�����N���b�N�����Ƃ��̏���
    public void StartButton2Down()
    {
        difficult = 2;
        SceneManager.LoadScene("SampleScene");
    }

    //�����{�^�����N���b�N�����Ƃ��̏���
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
