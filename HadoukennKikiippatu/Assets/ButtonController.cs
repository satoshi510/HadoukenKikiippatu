using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    //�^�C�}�[
    float timer = 0;

    //�Q�[���X�g�b�v
    bool Gamestop = false;

    //���̃{�^���̃I�u�W�F�N�g
    Button button;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >=2)
        {
            //�{�^����L���ɂ���
            this.button.interactable = true;
            //�p�l���R���g���[���[���ĊJ������
            GameObject.Find("PaneruController").GetComponent<PaneruController>().SetGamestopfalse();
        }
        
    }

    public void ChangeInteractabe()
    {
        //���Ԍv���J�n
        timer = 0;

        //�{�^���𖳌��ɂ���
        this.button.interactable = false;
    }

}
