using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    //�^�C�}�[
    float timer = 0;

    //�N���A�^�C��
    float cleartime = 0;

    //�N���A����
    bool clearhanntei = false;
    //�Q�[���I�[�o�[����
    bool gameoverhanntei = false;

    //�X�R�A
    int clearscore = 0;
    int scoresum = 0;

    //�I�u�W�F�N�g
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
        //�N���A�������I�u�W�F�N�g����荞��
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

        //�N���A���\������e�L�X�g����荞��
        ClearScoreText = GameObject.Find("ClearScoreText");
        ClearTimeText = GameObject.Find("ClearTimeText");
        ScoreSumText = GameObject.Find("ScoreSumText");

        //�N���A���\������e�L�X�g���A�N�e�B�u������
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

        //�N���A�㏈��
        if(clearhanntei == true)
        {
            if (timer > 0.5f) //��������3��
            {
                ClearTimeText.GetComponent<Text>().text = "�^�C��:" + ((180 - cleartime) * 5).ToString("f0") + "�_";
            }
            if (timer>1f)
            {
                ClearScoreText.GetComponent<Text>().text = "�X�R�A:" + clearscore.ToString("f0") + "�_";
            }
            if(timer>2f)
            {
                scoresum = Mathf.FloorToInt(clearscore + ((180 - cleartime) * 5));
                ScoreSumText.GetComponent<Text>().text = "���v:" + scoresum.ToString("f0") + "�_";
            }
            if (timer > 3f)
            {
                //�{�^���̕\��
                RetryButton.SetActive(true);
                MainMenuButton.SetActive(true);
                OpeningController.highscore = scoresum;
            }
        }

        //�Q�[���I�[�o�[�㏈��
        if (gameoverhanntei == true)
        {
            if (timer > 2f)
            {
                ClearTimeText.GetComponent<Text>().fontSize = 200;
                ClearTimeText.GetComponent<Text>().text = "GAMEOVER";
            }
            if (timer > 2.5f)
            {
                ScoreSumText.GetComponent<Text>().text = "���v:" + clearscore.ToString("f0") + "�_";
            }
            if (timer > 4f)
            {
                //�{�^���̕\��
                RetryButton.SetActive(true);
                MainMenuButton.SetActive(true);
                OpeningController.highscore = clearscore;
            }
        }


    }

    //�N���A���ɌĂяo�����֐�
    public void Clear(int x)
    {
        //�Q�[�����̂��̂��폜
        Destroy(KeshikataButtons);
        Destroy(Paneruset);
        Destroy(PlayTexts);
        Destroy(ButtonBlocks);
        Destroy(PaneruController);
        Destroy(wall);
        Destroy(panchiaction);
        Destroy(BGM);

        //�N���A��̃e�L�X�g���A�N�e�B�u��
        ClearScoreText.SetActive(true);
        ClearTimeText.SetActive(true);
        ScoreSumText.SetActive(true);

        //PaneruController����X�R�A�𓾂�
        clearscore = x;

        cleartime = timer;
        timer = 0;
        clearhanntei = true;
    }

    //�Q�[���I�[�o�[���ɌĂяo�����֐�
    public void GameOver(int x)
    {
        //�Q�[�����̂��̂��폜
        Destroy(KeshikataButtons);
        Destroy(Paneruset);
        Destroy(PlayTexts);
        Destroy(ButtonBlocks);
        Destroy(PaneruController);
        Destroy(wall);
        Destroy(kariwall);
        Destroy(panchiaction);
        Destroy(BGM);

        //�N���A��̃e�L�X�g���A�N�e�B�u��
        ClearTimeText.SetActive(true);
        ScoreSumText.SetActive(true);

        //�e�e�L�X�g�̐F�𔒂ɂ���
        ClearTimeText.GetComponent<Text>().color = Color.white;
        ScoreSumText.GetComponent<Text>().color = Color.white;

        //PaneruController����X�R�A�𓾂�
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
