using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //�I�u�W�F�N�g
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
        //�N���A�������I�u�W�F�N�g����荞��
        KeshikataButtons = GameObject.Find("KeshikataButtons");
        PaneruButtons = GameObject.Find("PaneruButtons");
        PlayTexts = GameObject.Find("PlayTexts");
        ButtonBlocks = GameObject.Find("ButtonBlocks");

        //�N���A���\������e�L�X�g����荞��
        ClearScoreText = GameObject.Find("ClearScoreText");
        ClearTimeText = GameObject.Find("ClearTimeText");
        ScoreSumText = GameObject.Find("ScoreSumText");

        //�N���A���\������e�L�X�g���A�N�e�B�u������
        ClearScoreText.SetActive(false);
        ClearTimeText.SetActive(false);
        ScoreSumText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //�N���A�㏈��
        if(clearhanntei == true)
        {
            if (timer > 0.5f) //��������5��
            {
                ClearTimeText.GetComponent<Text>().text = "�^�C��:" + ((300 - cleartime) * 5).ToString("f0") + "�_";
            }
            if (timer>1f)
            {
                ClearScoreText.GetComponent<Text>().text = "�X�R�A:" + clearscore.ToString("f0") + "�_";
            }
            if(timer>2f)
            {
                ScoreSumText.GetComponent<Text>().text = "���v:" + (clearscore + ((300 - cleartime) * 5)).ToString("f0") + "�_";
            }
        }

        //�Q�[���I�[�o�[�㏈��
        if (gameoverhanntei == true)
        {
            if (timer > 0.5f)
            {
                ClearTimeText.GetComponent<Text>().fontSize = 200;
                ClearTimeText.GetComponent<Text>().text = "GAMEOVER";
            }
            if (timer > 1.5f)
            {
                ScoreSumText.GetComponent<Text>().text = "���v:" + clearscore.ToString("f0") + "�_";
            }
        }


    }

    //�N���A���ɌĂяo�����֐�
    public void Clear(int x)
    {
        //�Q�[�����̂��̂��폜
        Destroy(KeshikataButtons);
        Destroy(PaneruButtons);
        Destroy(PlayTexts);
        Destroy(ButtonBlocks);

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
        Destroy(PaneruButtons);
        Destroy(PlayTexts);
        Destroy(ButtonBlocks);

        //�N���A��̃e�L�X�g���A�N�e�B�u��
        ClearScoreText.SetActive(true);
        ClearTimeText.SetActive(true);
        ScoreSumText.SetActive(true);

        //PaneruController����X�R�A�𓾂�
        clearscore = x;

        timer = 0;
        gameoverhanntei = true;
    }

}
