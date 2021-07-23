using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaneruController : MonoBehaviour
{
    //今のパネルの状態
    int[,] Paneru = new int[7,7];
    //パネルの合計
    int Panerusum = 0;

    //十字消し
    int[,] jyuuji = new int[,] { { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 }, { 1, 1, 1, 1, 1 }, { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 } };
    //クロス消し
    int[,] kurosu = new int[,] { { 1, 0, 0, 0, 1 }, { 0, 1, 0, 1, 0 }, { 0, 0, 1, 0, 0 }, { 0, 1, 0, 1, 0 }, { 1, 0, 0, 0, 1 } };
    //螺旋消し
    int[,] rasen = new int[,] { { 1, 1, 0, 0, 1 }, { 0, 0, 0, 0, 1 }, { 0, 0, 1, 0, 0 }, { 1, 0, 0, 0, 0 }, { 1, 0, 0, 1, 1 } };

    //問題作成用配列
    int[,] toi = new int[5, 5];
    //問題配置行
    int toigyou;
    //問題配置列
    int toiretu;
    //問題作成パターン
    int toikata;
    //問題マス数
    int toisum;
    //問題難易度初期化
    int toihard = 1;

    //十字消しボタンの判定
    private bool isJyuujikesiButton = false;
    //クロス消しボタンの判定
    private bool isKurosukesiButton = false;
    //螺旋消しボタンの判定
    private bool isRasenkesiButton = false;

    //ボタンのオブジェクト
    GameObject Button00;
    GameObject Button01;
    GameObject Button02;
    GameObject Button03;
    GameObject Button04;
    GameObject Button05;
    GameObject Button06;
    GameObject Button10;
    GameObject Button11;
    GameObject Button12;
    GameObject Button13;
    GameObject Button14;
    GameObject Button15;
    GameObject Button16;
    GameObject Button20;
    GameObject Button21;
    GameObject Button22;
    GameObject Button23;
    GameObject Button24;
    GameObject Button25;
    GameObject Button26;
    GameObject Button30;
    GameObject Button31;
    GameObject Button32;
    GameObject Button33;
    GameObject Button34;
    GameObject Button35;
    GameObject Button36;
    GameObject Button40;
    GameObject Button41;
    GameObject Button42;
    GameObject Button43;
    GameObject Button44;
    GameObject Button45;
    GameObject Button46;
    GameObject Button50;
    GameObject Button51;
    GameObject Button52;
    GameObject Button53;
    GameObject Button54;
    GameObject Button55;
    GameObject Button56;
    GameObject Button60;
    GameObject Button61;
    GameObject Button62;
    GameObject Button63;
    GameObject Button64;
    GameObject Button65;
    GameObject Button66;
    GameObject JyuujikesiButton;
    GameObject KurosukesiButton;
    GameObject RasenkesiButton;




    // Start is called before the first frame update
    void Start()
    {
        //パネルの初期化
        for (int i = 0; i < Paneru.GetLength(0); i++)
        {
            for (int j = 0; j < Paneru.GetLength(1); j++)
            {
                Paneru[i, j] = 1;
            }
        }

        //ボタンのオブジェクトを取り込む
        Button00 = GameObject.Find("Button00");
        Button01 = GameObject.Find("Button01");
        Button02 = GameObject.Find("Button02");
        Button03 = GameObject.Find("Button03");
        Button04 = GameObject.Find("Button04");
        Button05 = GameObject.Find("Button05");
        Button06 = GameObject.Find("Button06");
        Button10 = GameObject.Find("Button10");
        Button11 = GameObject.Find("Button11");
        Button12 = GameObject.Find("Button12");
        Button13 = GameObject.Find("Button13");
        Button14 = GameObject.Find("Button14");
        Button15 = GameObject.Find("Button15");
        Button16 = GameObject.Find("Button16");
        Button20 = GameObject.Find("Button20");
        Button21 = GameObject.Find("Button21");
        Button22 = GameObject.Find("Button22");
        Button23 = GameObject.Find("Button23");
        Button24 = GameObject.Find("Button24");
        Button25 = GameObject.Find("Button25");
        Button26 = GameObject.Find("Button26");
        Button30 = GameObject.Find("Button30");
        Button31 = GameObject.Find("Button31");
        Button32 = GameObject.Find("Button32");
        Button33 = GameObject.Find("Button33");
        Button34 = GameObject.Find("Button34");
        Button35 = GameObject.Find("Button35");
        Button36 = GameObject.Find("Button36");
        Button40 = GameObject.Find("Button40");
        Button41 = GameObject.Find("Button41");
        Button42 = GameObject.Find("Button42");
        Button43 = GameObject.Find("Button43");
        Button44 = GameObject.Find("Button44");
        Button45 = GameObject.Find("Button45");
        Button46 = GameObject.Find("Button46");
        Button50 = GameObject.Find("Button50");
        Button51 = GameObject.Find("Button51");
        Button52 = GameObject.Find("Button52");
        Button53 = GameObject.Find("Button53");
        Button54 = GameObject.Find("Button54");
        Button55 = GameObject.Find("Button55");
        Button56 = GameObject.Find("Button56");
        Button60 = GameObject.Find("Button60");
        Button61 = GameObject.Find("Button61");
        Button62 = GameObject.Find("Button62");
        Button63 = GameObject.Find("Button63");
        Button64 = GameObject.Find("Button64");
        Button65 = GameObject.Find("Button65");
        Button66 = GameObject.Find("Button66");
        JyuujikesiButton = GameObject.Find("JyuujikesiButton");
        KurosukesiButton = GameObject.Find("KurosukesiButton");
        RasenkesiButton = GameObject.Find("RasenkesiButton");


        //難易度分の回数問題を足す
        for (int t=0; t< toihard; t++)
        {
            Toisakusei();
            Toitasizann(toigyou, toiretu);
        }



    }

    // Update is called once per frame
    void Update()
    {
        //パネルの合計を初期化
        Panerusum = 0;


        //ボタンの色を更新する
        ColorChange(Button00, Paneru[0, 0]);
        ColorChange(Button01, Paneru[0, 1]);
        ColorChange(Button02, Paneru[0, 2]);
        ColorChange(Button03, Paneru[0, 3]);
        ColorChange(Button04, Paneru[0, 4]);
        ColorChange(Button05, Paneru[0, 5]);
        ColorChange(Button06, Paneru[0, 6]);
        ColorChange(Button10, Paneru[1, 0]);
        ColorChange(Button11, Paneru[1, 1]);
        ColorChange(Button12, Paneru[1, 2]);
        ColorChange(Button13, Paneru[1, 3]);
        ColorChange(Button14, Paneru[1, 4]);
        ColorChange(Button15, Paneru[1, 5]);
        ColorChange(Button16, Paneru[1, 6]);
        ColorChange(Button20, Paneru[2, 0]);
        ColorChange(Button21, Paneru[2, 1]);
        ColorChange(Button22, Paneru[2, 2]);
        ColorChange(Button23, Paneru[2, 3]);
        ColorChange(Button24, Paneru[2, 4]);
        ColorChange(Button25, Paneru[2, 5]);
        ColorChange(Button26, Paneru[2, 6]);
        ColorChange(Button30, Paneru[3, 0]);
        ColorChange(Button31, Paneru[3, 1]);
        ColorChange(Button32, Paneru[3, 2]);
        ColorChange(Button33, Paneru[3, 3]);
        ColorChange(Button34, Paneru[3, 4]);
        ColorChange(Button35, Paneru[3, 5]);
        ColorChange(Button36, Paneru[3, 6]);
        ColorChange(Button40, Paneru[4, 0]);
        ColorChange(Button41, Paneru[4, 1]);
        ColorChange(Button42, Paneru[4, 2]);
        ColorChange(Button43, Paneru[4, 3]);
        ColorChange(Button44, Paneru[4, 4]);
        ColorChange(Button45, Paneru[4, 5]);
        ColorChange(Button46, Paneru[4, 6]);
        ColorChange(Button50, Paneru[5, 0]);
        ColorChange(Button51, Paneru[5, 1]);
        ColorChange(Button52, Paneru[5, 2]);
        ColorChange(Button53, Paneru[5, 3]);
        ColorChange(Button54, Paneru[5, 4]);
        ColorChange(Button55, Paneru[5, 5]);
        ColorChange(Button56, Paneru[5, 6]);
        ColorChange(Button60, Paneru[6, 0]);
        ColorChange(Button61, Paneru[6, 1]);
        ColorChange(Button62, Paneru[6, 2]);
        ColorChange(Button63, Paneru[6, 3]);
        ColorChange(Button64, Paneru[6, 4]);
        ColorChange(Button65, Paneru[6, 5]);
        ColorChange(Button66, Paneru[6, 6]);
        KesikataColorChange(JyuujikesiButton, isJyuujikesiButton);
        KesikataColorChange(KurosukesiButton, isKurosukesiButton);
        KesikataColorChange(RasenkesiButton, isRasenkesiButton);

    }

        //十字消しボタンを押した場合の処理
        public void GetJyuujikesiButtonDown()
    {
        this.isKurosukesiButton = false;
        this.isRasenkesiButton = false;
        this.isJyuujikesiButton = true;
    }
    //クロス消しボタンを押した場合の処理
    public void GetKurosukesiButtonDown()
    {
        this.isJyuujikesiButton = false;
        this.isRasenkesiButton = false;
        this.isKurosukesiButton = true;
    }
    //螺旋消しボタンを押した場合の処理
    public void GetRasenkesiButtonDown()
    {
        this.isJyuujikesiButton = false;
        this.isKurosukesiButton = false;
        this.isRasenkesiButton = true;
    }

    //5x5足し算
    void Toitasizann(int Tasix, int Tasiy)
    {

        int Tasik = 0;
        int Tasil = 0;

        for (int Tasii = Tasix - 2; Tasii < Tasix + 3; Tasii++)
        {
            for (int Tasij = Tasiy - 2; Tasij < Tasiy + 3; Tasij++)
            {
                if (0 <= Tasii && Tasii <= 6 && 0 <= Tasij && Tasij <= 6)
                {
                    Paneru[Tasii, Tasij] += toi[Tasik, Tasil];
                    Tasik++;
                }
            }
            Tasik = 0;
            Tasil++;
        }
        Tasik = 0;
        Tasil = 0;
    }

    //問題作成1セット
    void Toisakusei()
    {
        //問題配置行
        toigyou = Random.Range(1, Paneru.GetLength(0)-1);
        //問題配置列
        toiretu = Random.Range(1, Paneru.GetLength(1)-1);
        //問題作成パターン3種類
        toikata = Random.Range(1, 4);
        //問題マス数 (3～5マス)
        toisum = Random.Range(3, 6);
        int toisumnow = 0;
        //toi初期化
        for (int Seti = 0; Seti < toi.GetLength(0); Seti++)
        {
            for (int Setj = 0; Setj < toi.GetLength(1); Setj++)
            {
                toi[Seti, Setj] = 0;
            }
        }

        //問題マス数になるまで配置を決める
        while (toisumnow < toisum)
        {
            toisumnow = 0;
            int Setx = Random.Range(1, 10);
            if (toikata == 1)
            {
                Toisakuseijyuuji(Setx);
            }
            else if (toikata == 2)
            {
                Toisakuseikurosu(Setx);
            }
            else
            {
                Toisakuseirasen(Setx);
            }
            //問の合計を計算
            for (int Seti = 0; Seti < toi.GetLength(0); Seti++)
            {
                for (int Setj = 0; Setj < toi.GetLength(1); Setj++)
                {
                    toisumnow += toi[Seti, Setj];
                }
            }
        }
    }

    //問作成十字
    void Toisakuseijyuuji(int x)
    {
        if (x == 1)
        {
            if (toi[0, 2] == 0)
            {
                toi[0, 2]++;
            }
        }
        if (x == 2)
        {
            if (toi[1, 2] == 0)
            {
                toi[1, 2]++;
            }
        }
        if (x == 3)
        {
            if (toi[2, 0] == 0)
            {
                toi[2, 0]++;
            }
        }
        if (x == 4)
        {
            if (toi[2, 1] == 0)
            {
                toi[2, 1]++;
            }
        }
        if (x == 5)
        {
            if (toi[2, 2] == 0)
            {
                toi[2, 2]++;
            }
        }
        if (x == 6)
        {
            if (toi[2, 3] == 0)
            {
                toi[2, 3]++;
            }
        }
        if (x == 7)
        {
            if (toi[2, 4] == 0)
            {
                toi[2, 4]++;
            }
        }
        if (x == 8)
        {
            if (toi[3, 2] == 0)
            {
                toi[3, 2]++;
            }
        }
        if (x == 9)
        {
            if (toi[4, 2] == 0)
            {
                toi[4, 2]++;
            }
        }

    }
    //問作成クロス
    void Toisakuseikurosu(int x)
    {
        if (x == 1)
        {
            if (toi[0, 0] == 0)
            {
                toi[0, 0]++;
            }
        }
        if (x == 2)
        {
            if (toi[0, 4] == 0)
            {
                toi[0, 4]++;
            }
        }
        if (x == 3)
        {
            if (toi[1, 1] == 0)
            {
                toi[1, 1]++;
            }
        }
        if (x == 4)
        {
            if (toi[1, 3] == 0)
            {
                toi[1, 3]++;
            }
        }
        if (x == 5)
        {
            if (toi[2, 2] == 0)
            {
                toi[2, 2]++;
            }
        }
        if (x == 6)
        {
            if (toi[3, 1] == 0)
            {
                toi[3, 1]++;
            }
        }
        if (x == 7)
        {
            if (toi[3, 3] == 0)
            {
                toi[3, 3]++;
            }
        }
        if (x == 8)
        {
            if (toi[4, 0] == 0)
            {
                toi[4, 0]++;
            }
        }
        if (x == 9)
        {
            if (toi[4, 4] == 0)
            {
                toi[4, 4]++;
            }
        }

    }

    //問作成螺旋
    void Toisakuseirasen(int x)
    {
        if (x == 1)
        {
            if (toi[0, 0] == 0)
            {
                toi[0, 0]++;
            }
        }
        if (x == 2)
        {
            if (toi[0, 1] == 0)
            {
                toi[0, 1]++;
            }
        }
        if (x == 3)
        {
            if (toi[0, 4] == 0)
            {
                toi[0, 4]++;
            }
        }
        if (x == 4)
        {
            if (toi[1, 4] == 0)
            {
                toi[1, 4]++;
            }
        }
        if (x == 5)
        {
            if (toi[2, 2] == 0)
            {
                toi[2, 2]++;
            }
        }
        if (x == 6)
        {
            if (toi[3, 0] == 0)
            {
                toi[3, 0]++;
            }
        }
        if (x == 7)
        {
            if (toi[4, 0] == 0)
            {
                toi[4, 0]++;
            }
        }
        if (x == 8)
        {
            if (toi[4, 3] == 0)
            {
                toi[4, 3]++;
            }
        }
        if (x == 9)
        {
            if (toi[4, 4] == 0)
            {
                toi[4, 4]++;
            }
        }

    }
    //十字消し関数
    void Jyuujikesi(int Jkesix, int Jkesiy)
    {
        int Jkesik = 0;
        int Jkesil = 0;

        for (int Jkesii = Jkesix - 2; Jkesii < Jkesix + 3; Jkesii++)
        {
            for (int Jkesij = Jkesiy - 2; Jkesij < Jkesiy + 3; Jkesij++)
            {
                if (0 <= Jkesii && Jkesii < Paneru.GetLength(0) && 0 <= Jkesij && Jkesij < Paneru.GetLength(1))
                {
                    if (Paneru[Jkesii, Jkesij] > 0)
                    {
                        Paneru[Jkesii, Jkesij] -= jyuuji[Jkesik, Jkesil];
                        Jkesik++;
                    }
                }
            }
            Jkesik = 0;
            Jkesil++;
        }
        Jkesik = 0;
        Jkesil = 0;
    }
    void Kurosukesi(int Kkesix, int Kkesiy)
    {
        int Kkesik = 0;
        int Kkesil = 0;

        for (int Kkesii = Kkesix - 2; Kkesii < Kkesix + 3; Kkesii++)
        {
            for (int Kkesij = Kkesiy - 2; Kkesij < Kkesiy + 3; Kkesij++)
            {
                if (0 <= Kkesii && Kkesii < Paneru.GetLength(0) && 0 <= Kkesij && Kkesij < Paneru.GetLength(1))
                {
                    if (Paneru[Kkesii, Kkesij] > 0)
                    {
                        Paneru[Kkesii, Kkesij] -= kurosu[Kkesik, Kkesil];
                        Kkesik++;
                    }
                }
            }
            Kkesik = 0;
            Kkesil++;
        }
        Kkesik = 0;
        Kkesil = 0;
    }
    void Rasenkesi(int Rkesix, int Rkesiy)
    {
        int Rkesik = 0;
        int Rkesil = 0;

        for (int Rkesii = Rkesix - 2; Rkesii < Rkesix + 3; Rkesii++)
        {
            for (int Rkesij = Rkesiy - 2; Rkesij < Rkesiy + 3; Rkesij++)
            {
                if (0 <= Rkesii && Rkesii < Paneru.GetLength(0) && 0 <= Rkesij && Rkesij < Paneru.GetLength(1))
                {
                    if (Paneru[Rkesii, Rkesij] > 0)
                    {
                        Paneru[Rkesii, Rkesij] -= rasen[Rkesik, Rkesil];
                        Rkesik++;
                    }
                }
            }
            Rkesik = 0;
            Rkesil++;
        }
        Rkesik = 0;
        Rkesil = 0;
    }

    //Button00を押したら消し方に応じた(0,0)中心の処理をする
    public void GetButton00Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(0, 0);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(0, 0);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(0, 0);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton01Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(0, 1);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(0, 1);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(0, 1);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton02Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(0, 2);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(0, 2);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(0, 2);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton03Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(0, 3);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(0, 3);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(0, 3);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton04Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(0, 4);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(0, 4);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(0, 4);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton05Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(0, 5);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(0, 5);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(0, 5);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton06Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(0, 6);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(0, 6);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(0, 6);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton10Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(1, 0);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(1, 0);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(1, 0);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton11Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(1, 1);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(1, 1);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(1, 1);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton12Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(1, 2);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(1, 2);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(1, 2);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton13Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(1, 3);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(1, 3);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(1, 3);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton14Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(1, 4);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(1, 4);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(1, 4);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton15Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(1, 5);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(1, 5);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(1, 5);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton16Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(1, 6);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(1, 6);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(1, 6);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton20Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(2, 0);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(2, 0);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(2, 0);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton21Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(2, 1);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(2, 1);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(2, 1);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton22Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(2, 2);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(2, 2);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(2, 2);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton23Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(2, 3);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(2, 3);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(2, 3);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton24Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(2, 4);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(2, 4);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(2, 4);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton25Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(2, 5);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(2, 5);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(2, 5);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton26Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(2, 6);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(2, 6);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(2, 6);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton30Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(3, 0);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(3, 0);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(3, 0);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton31Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(3, 1);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(3, 1);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(3, 1);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton32Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(3, 2);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(3, 2);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(3, 2);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton33Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(3, 3);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(3, 3);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(3, 3);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton34Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(3, 4);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(3, 4);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(3, 4);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton35Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(3, 5);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(3, 5);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(3, 5);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton36Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(3, 6);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(3, 6);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(3, 6);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton40Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(4, 0);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(4, 0);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(4, 0);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton41Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(4, 1);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(4, 1);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(4, 1);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton42Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(4, 2);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(4, 2);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(4, 2);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton43Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(4, 3);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(4, 3);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(4, 3);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton44Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(4, 4);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(4, 4);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(4, 4);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton45Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(4, 5);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(4, 5);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(4, 5);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton46Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(4, 6);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(4, 6);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(4, 6);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton50Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(5, 0);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(5, 0);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(5, 0);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton51Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(5, 1);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(5, 1);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(5, 1);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton52Down()
    {
        if (this.isJyuujikesiButton == true)
        { 
            Jyuujikesi(5, 2);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(5, 2);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(5, 2);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton53Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(5, 3);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(5, 3);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(5, 3);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton54Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(5, 4);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(5, 4);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(5, 4);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton55Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(5, 5);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(5, 5);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(5, 5);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton56Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(5, 6);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(5, 6);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(5, 6);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton60Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(6, 0);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(6, 0);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(6, 0);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton61Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(6, 1);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(6, 1);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(6, 1);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton62Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(6, 2);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(6, 2);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(6, 2);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton63Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(6, 3);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(6, 3);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(6, 3);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton64Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(6, 4);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(6, 4);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(6, 4);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton65Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(6, 5);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(6, 5);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(6, 5);
            this.isRasenkesiButton = false;
        }
    }
    public void GetButton66Down()
    {
        if (this.isJyuujikesiButton == true)
        {
            Jyuujikesi(6, 6);
            this.isJyuujikesiButton = false;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kurosukesi(6, 6);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Rasenkesi(6, 6);
            this.isRasenkesiButton = false;
        }
    }

    //ボタンの色変更
    void ColorChange(GameObject color, int colorx)
    {
        if(colorx==0)
        {
            color.GetComponent<Image>().color = Color.white;
        }
        if (colorx == 1)
        {
            color.GetComponent<Image>().color = Color.red;
        }
        if (colorx == 2)
        {
            color.GetComponent<Image>().color = Color.yellow;
        }
        if (colorx == 3)
        {
            color.GetComponent<Image>().color = Color.green;
        }

    }
    //消し方ボタンの色変更
    void KesikataColorChange(GameObject color, bool colorx)
    {
        if(colorx == true)
        {
            color.GetComponent<Image>().color = Color.red;
        }
        else if(colorx == false)
        {
            color.GetComponent<Image>().color = Color.white;
        }
    }
}
