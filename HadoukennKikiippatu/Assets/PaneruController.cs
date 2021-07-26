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
    int[,] jyuuji = new int[,] { 
        { 0, 0, 1, 0, 0 }, 
        { 0, 0, 1, 0, 0 }, 
        { 1, 1, 1, 1, 1 }, 
        { 0, 0, 1, 0, 0 }, 
        { 0, 0, 1, 0, 0 } 
    };
    //クロス消し
    int[,] kurosu = new int[,] { 
        { 1, 0, 0, 0, 1 }, 
        { 0, 1, 0, 1, 0 }, 
        { 0, 0, 1, 0, 0 }, 
        { 0, 1, 0, 1, 0 }, 
        { 1, 0, 0, 0, 1 } 
    };
    //螺旋消し
    int[,] rasen = new int[,] { 
        { 1, 1, 0, 0, 1 }, 
        { 0, 0, 0, 0, 1 }, 
        { 0, 0, 1, 0, 0 }, 
        { 1, 0, 0, 0, 0 }, 
        { 1, 0, 0, 1, 1 } 
    };

    //問題作成用配列
    int[,] toi = new int[5, 5];
    //問題難易度初期化
    int toihard = 1;
    //残り操作回数
    int nokorikaisuu = 0;
    //得点
    int score = 0;

    //何問目
    int toikazu = 0;

    //十字消しボタンの判定
    private bool isJyuujikesiButton = false;
    //クロス消しボタンの判定
    private bool isKurosukesiButton = false;
    //螺旋消しボタンの判定
    private bool isRasenkesiButton = false;

    //ボタンのオブジェクト
    GameObject[,] Buttons = new GameObject[7, 7];
    GameObject JyuujikesiButton;
    GameObject KurosukesiButton;
    GameObject RasenkesiButton;

    //何問目かの表示テキスト
    GameObject toikazuText;
    //残り回数の表示テキスト
    GameObject nokorikaisuuText;
    //得点の表示テキスト
    GameObject scoreText;



    // Start is called before the first frame update
    void Start()
    {
        //パネルの初期化
        Panerusyokika();

        //ボタンのオブジェクトを取り込む
        for(int y = 0; y<7; y++ )
        {
            for(int x = 0; x<7; x++)
            {
                Buttons[x, y] = GameObject.Find("Button" + x + y);
            }

        }
        JyuujikesiButton = GameObject.Find("JyuujikesiButton");
        KurosukesiButton = GameObject.Find("KurosukesiButton");
        RasenkesiButton = GameObject.Find("RasenkesiButton");
        //何問目を表示するテキストを取り込む
        this.toikazuText = GameObject.Find("toikazuText");
        //残り回数を表示するテキストを取り込む
        this.nokorikaisuuText = GameObject.Find("nokorikaisuuText");
        //得点を表示するテキストを取り込む
        this.scoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {
            //パネルの合計を計算
            Panerugoukei();
            //正解した時
            if (Panerusum == 0)
            {
                //点数加算
                score += (toihard - 1) * (toihard - 1) * 10;
                //次の問題に進む
                toikazu++;
                //難易度上昇
                if (toihard < 7)
                {
                    toihard++;
                }
                for (int t = 0; t < toihard; t++)
                {
                    Toisakusei();
                }
                nokorikaisuu = toihard;

            }
            //残り回数が先に0になった時(間違ったとき)
            else if (nokorikaisuu == 0)
            {
                Panerusyokika();
                //難易度低下
                if (toihard > 2)
                {
                    toihard--;
                }
                for (int t = 0; t < toihard; t++)
                {
                    Toisakusei();
                }
                nokorikaisuu = toihard;
            }
            //パネルの合計を計算
            Panerugoukei();

        //今の問題数の表示を更新する
        this.toikazuText.GetComponent<Text>().text = toikazu + "問目";
        //今の残り回数の表示を更新する
        this.nokorikaisuuText.GetComponent<Text>().text = "残り" + nokorikaisuu + "回";
        //今の得点の表示を更新する
        this.scoreText.GetComponent<Text>().text = score + "点";

        //パネルの色を更新する
        for (int y = 0; y < 7; y++)
        {
            for (int x = 0; x < 7; x++)
            {
                ColorChange(Buttons[x,y], Paneru[x,y]);
            }
        }
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

    //パネルの初期化
    void Panerusyokika()
    {
        for (int i = 0; i < Paneru.GetLength(0); i++)
        {
            for (int j = 0; j < Paneru.GetLength(1); j++)
            {
                Paneru[i, j] = 0;
            }
        }
    }

    //パネルの合計を計算
    void Panerugoukei()
    {
        //パネルの合計を初期化
        Panerusum = 0;
        //パネルの合計を計算
        for (int y = 0; y < 7; y++)
        {
            for (int x = 0; x < 7; x++)
            {
                Panerusum += Paneru[x, y];
            }
        }
    }

    //問題作成1セット
    void Toisakusei()
    {
        //問題配置行
        int toigyou = Random.Range(1, Paneru.GetLength(0)-1);
        //問題配置列
        int toiretu = Random.Range(1, Paneru.GetLength(1)-1);
        //問題作成パターン3種類
        int toikata = Random.Range(1, 4);
        //問題マス数 (4～6マス)
        int toisum = Random.Range(4, 7);
        //現状のtoiのマスの合計の計算用
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
            else if (toikata == 3)
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

        //作ったtoi配列をPaneruに足す
        int Tasik = 0;
        int Tasil = 0;
        for (int Tasii = toigyou - 2; Tasii < toigyou + 3; Tasii++)
        {
            for (int Tasij = toiretu - 2; Tasij < toiretu + 3; Tasij++)
            {
                if (0 <= Tasii && Tasii <= 6 && 0 <= Tasij && Tasij <= 6)
                {
                    Paneru[Tasii, Tasij] += toi[Tasik, Tasil];
                }
                Tasil++;
            }
            Tasil = 0;
            Tasik++;
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

    //消し関数
    void Kesi(int x, int y, int[,] kesi)
    {

        int k = 0;
        int l = 0;

        for (int i = x - 2; i < x + 3; i++)
        {
            for (int j = y - 2; j < y + 3; j++)
            {
                if (0 <= i && i < Paneru.GetLength(0) && 0 <= j && j < Paneru.GetLength(1))
                {
                    if (Paneru[i, j] > 0)
                    {
                        Paneru[i, j] -= kesi[k, l];
                    }
                }
                l++;
            }
            l = 0;
            k++;
        }
        k = 0;
        l = 0;
    }

    //ボタン処理
    void Buttonsyori(int x,int y)
    {
        if (this.isJyuujikesiButton == true)
        {
            Kesi(x, y,jyuuji);
            this.isJyuujikesiButton = false;
            nokorikaisuu--;
        }
        else if (this.isKurosukesiButton == true)
        {
            Kesi(x, y, kurosu);
            this.isKurosukesiButton = false;
            nokorikaisuu--;
        }
        else if (this.isRasenkesiButton == true)
        {
            Kesi(x, y, rasen);
            this.isRasenkesiButton = false;
            nokorikaisuu--;
        }
    }

    //Button00を押したら消し方に応じた(0,0)中心の処理をする
    public void GetButton00Down()
    {Buttonsyori(0, 0);}
    public void GetButton01Down()
    {Buttonsyori(0, 1);}
    public void GetButton02Down()
    {Buttonsyori(0, 2);}
    public void GetButton03Down()
    {Buttonsyori(0, 3);}
    public void GetButton04Down()
    {Buttonsyori(0, 4);}
    public void GetButton05Down()
    {Buttonsyori(0, 5);}
    public void GetButton06Down()
    {Buttonsyori(0, 6);}
    public void GetButton10Down()
    {Buttonsyori(1, 0);}
    public void GetButton11Down()
    {Buttonsyori(1, 1);}
    public void GetButton12Down()
    {Buttonsyori(1, 2);}
    public void GetButton13Down()
    {Buttonsyori(1, 3);}
    public void GetButton14Down()
    {Buttonsyori(1, 4);}
    public void GetButton15Down()
    { Buttonsyori(1, 5); }
    public void GetButton16Down()
    {Buttonsyori(1, 6);}
    public void GetButton20Down()
    {Buttonsyori(2, 0);}
    public void GetButton21Down()
    {Buttonsyori(2, 1);}
    public void GetButton22Down()
    {Buttonsyori(2, 2);}
    public void GetButton23Down()
    {Buttonsyori(2, 3);}
    public void GetButton24Down()
    {Buttonsyori(2, 4);}
    public void GetButton25Down()
    {Buttonsyori(2, 5);}
    public void GetButton26Down()
    {Buttonsyori(2, 6);}
    public void GetButton30Down()
    {Buttonsyori(3, 0);}
    public void GetButton31Down()
    {Buttonsyori(3, 1);}
    public void GetButton32Down()
    { Buttonsyori(3, 2); }
    public void GetButton33Down()
    {Buttonsyori(3, 3);}
    public void GetButton34Down()
    {Buttonsyori(3, 4);}
    public void GetButton35Down()
    {Buttonsyori(3, 5);}
    public void GetButton36Down()
    {Buttonsyori(3, 6);}
    public void GetButton40Down()
    {Buttonsyori(4, 0);}
    public void GetButton41Down()
    {Buttonsyori(4, 1);}
    public void GetButton42Down()
    {Buttonsyori(4, 2);}
    public void GetButton43Down()
    {Buttonsyori(4, 3);}
    public void GetButton44Down()
    {Buttonsyori(4, 4);}
    public void GetButton45Down()
    {Buttonsyori(4, 5);}
    public void GetButton46Down()
    { Buttonsyori(4, 6);}
    public void GetButton50Down()
    {Buttonsyori(5, 0);}
    public void GetButton51Down()
    {Buttonsyori(5, 1);}
    public void GetButton52Down()
    {Buttonsyori(5, 2);}
    public void GetButton53Down()
    {Buttonsyori(5, 3);}
    public void GetButton54Down()
    {Buttonsyori(5, 4);}
    public void GetButton55Down()
    {Buttonsyori(5, 5);}
    public void GetButton56Down()
    {Buttonsyori(5, 6);}
    public void GetButton60Down()
    {Buttonsyori(6, 0);}
    public void GetButton61Down()
    {Buttonsyori(6, 1);}
    public void GetButton62Down()
    {Buttonsyori(6, 2);}
    public void GetButton63Down()
    {Buttonsyori(6, 3);}
    public void GetButton64Down()
    {Buttonsyori(6, 4);}
    public void GetButton65Down()
    {Buttonsyori(6, 5);}
    public void GetButton66Down()
    {Buttonsyori(6, 6);}

    //パネルの色変更
    void ColorChange(GameObject color, int colorx)
    {
        if(colorx==0)
        {
            color.GetComponent<Image>().color = new Color32(255,255,255,255);
        }
        if (colorx == 1)
        {
            color.GetComponent<Image>().color = new Color32(255,0,0,255);
        }
        if (colorx == 2)
        {
            color.GetComponent<Image>().color = new Color32(255,127,0,255);
        }
        if (colorx == 3)
        {
            color.GetComponent<Image>().color = new Color32 (255,255,0,255);
        }
        if (colorx == 4)
        {
            color.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        }
        if (colorx == 5)
        {
            color.GetComponent<Image>().color = new Color32(0, 255, 255,255);
        }
        if (colorx == 6)
        {
            color.GetComponent<Image>().color = new Color32(0, 0, 255, 255);
        }
        if (colorx == 7)
        {
            color.GetComponent<Image>().color = new Color32(128, 0, 255, 255);
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
