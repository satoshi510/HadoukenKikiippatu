using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    //タイマー
    float timer = 0;

    //ゲームストップ
    bool Gamestop = false;

    //このボタンのオブジェクト
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
            //ボタンを有効にする
            this.button.interactable = true;
            //パネルコントローラーを再開させる
            GameObject.Find("PaneruController").GetComponent<PaneruController>().SetGamestopfalse();
        }
        
    }

    public void ChangeInteractabe()
    {
        //時間計測開始
        timer = 0;

        //ボタンを無効にする
        this.button.interactable = false;
    }

}
