using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaneruController : MonoBehaviour
{
    //���̃p�l���̏��
    private int[,] Paneru = new int[7,7];
    //�p�l���̍��v
    private int Panerusum = 0;

    //�\������
    private int[,] jyuuji = new int[,] { 
        { 0, 0, 1, 0, 0 }, 
        { 0, 0, 1, 0, 0 }, 
        { 1, 1, 1, 1, 1 }, 
        { 0, 0, 1, 0, 0 }, 
        { 0, 0, 1, 0, 0 } 
    };
    //�N���X����
    private int[,] kurosu = new int[,] { 
        { 1, 0, 0, 0, 1 }, 
        { 0, 1, 0, 1, 0 }, 
        { 0, 0, 1, 0, 0 }, 
        { 0, 1, 0, 1, 0 }, 
        { 1, 0, 0, 0, 1 } 
    };
    //��������
    private int[,] rasen = new int[,] { 
        { 1, 1, 0, 0, 1 }, 
        { 0, 0, 0, 0, 1 }, 
        { 0, 0, 1, 0, 0 }, 
        { 1, 0, 0, 0, 0 }, 
        { 1, 0, 0, 1, 1 } 
    };

    //���쐬�p�z��
    private int[,] toi = new int[5, 5];
    //����Փx������
    private int toihard = 0;
    //�c�葀���
    private int nokorikaisuu = 0;
    //���_
    private int score = 0;

    //��萔
    private int monndaisuu = 3;
    //�����
    private int toikazu = 0;

    //�o�ߎ���
    private float second = 0f;
    private int minite = 0;

    //��Փx�ύX�����i���ԁj
    private float hardtime = 0f;

    //�Q�[����~����
    public bool gamestop = false;
    //�Q�[����~���� (1��ڂ�gamestop = false�������p��2.2)
    private float gamestoptime = 2.2f;

    //�\�������{�^���̔���
    private bool isJyuujikesiButton = false;
    //�N���X�����{�^���̔���
    private bool isKurosukesiButton = false;
    //���������{�^���̔���
    private bool isRasenkesiButton = false;

    //�{�^���̃I�u�W�F�N�g
    GameObject[,] Buttons = new GameObject[7, 7];
    GameObject JyuujikesiButton;
    GameObject KurosukesiButton;
    GameObject RasenkesiButton;

    //����ڂ��̕\���e�L�X�g
    GameObject toikazuText;
    //�c��񐔂̕\���e�L�X�g
    GameObject nokorikaisuuText;
    //���_�̕\���e�L�X�g
    GameObject scoreText;
    //�c�莞�Ԃ̕\���e�L�X�g
    GameObject timeText;



    // Start is called before the first frame update
    void Start()
    {
        //�p�l���̏�����
        Panerusyokika();

        //�{�^���̃I�u�W�F�N�g����荞��
        for(int y = 0; y<7; y++ )
        {
            for(int x = 0; x<7; x++)
            {
                Buttons[x, y] = GameObject.Find("Button" + x + y);
            }

        }
        JyuujikesiButton = GameObject.Find("JyuujikesiButtonBlock");
        KurosukesiButton = GameObject.Find("KurosukesiButtonBlock");
        RasenkesiButton = GameObject.Find("RasenkesiButtonBlock");
        //����ڂ�\������e�L�X�g����荞��
        this.toikazuText = GameObject.Find("toikazuText");
        //�c��񐔂�\������e�L�X�g����荞��
        this.nokorikaisuuText = GameObject.Find("nokorikaisuuText");
        //���_��\������e�L�X�g����荞��
        this.scoreText = GameObject.Find("ScoreText");
        //�c�莞�Ԃ�\������e�L�X�g����荞��
        this.timeText = GameObject.Find("TimeText");

    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[����~���Ԍv��
        gamestoptime += Time.deltaTime; 
        //�p�l���̍��v���v�Z
        Panerugoukei();
        //�Q�[���X�g�b�v
        if((Panerusum ==0 || nokorikaisuu <= 0 )&& toihard !=0 &&gamestop == false && gamestoptime >2.2f)
        {
            gamestop = true;
            gamestoptime = 0;

            for(int y =0; y<7; y++)
            {
                for (int x = 0; x<7; x++)
                {
                    GameObject.Find("Button" + y + x).GetComponent<ButtonController>().ChangeInteractable();
                }
            }
        }

        if (gamestop == false && gamestoptime>1) //�Q�[���X�g�b�vtrue�Ɠ�����true�ɂȂ�Ȃ��悤��time����
        {
            //��Փx�ύX�p�o�ߎ��Ԍv�Z
            hardtime += Time.deltaTime;
            if (toikazu <= monndaisuu)
            {
                //����������
                if (Panerusum == 0)
                {
                    //���̖��ɐi��
                    toikazu++;
                    //�_�����Z
                    score += toihard * toihard * 10;
                    score += nokorikaisuu * 300;

                    //��Փx�㏸
                    if (hardtime < (toihard * 3+2) || toihard == 0)
                    {
                        if (toihard < 7)
                        {
                            toihard++;
                        }
                    }
                    for (int t = 0; t < toihard; t++)
                    {
                        Toisakusei();
                    }
                    nokorikaisuu = toihard;

                }
                //�c��񐔂����0�ɂȂ�����(�Ԉ�����Ƃ�)
                else if (nokorikaisuu <= 0)
                {
                    Panerusyokika();
                    //��Փx�ቺ
                    if (toihard > 1)
                    {
                        toihard--;
                    }
                    for (int t = 0; t < toihard; t++)
                    {
                        Toisakusei();
                    }
                    nokorikaisuu = toihard;
                }
            }
        }
        //�p�l���̍��v���v�Z
        Panerugoukei();

        //�c�莞�Ԃ��v������
        second += Time.deltaTime;
        if(second > 60f)
        {
            minite++;
            second -= 60;
        }
        //��������5��
        this.timeText.GetComponent<Text>().text = (4 - minite) + ":" + (60 - second).ToString("f2");

        //�Ō�̖����I������
        if ( (toikazu >= monndaisuu && Panerusum ==0))
        {
            //�Ō�̖��̓_���𑫂�
            score += toihard * toihard * 10;
            score += nokorikaisuu * 300;
            GameObject.Find("FinishController").GetComponent<FinishController>().Clear(score);
        }
        //�Q�[���I�[�o�[
        else if (minite >= 5)
        {
            GameObject.Find("FinishController").GetComponent<FinishController>().GameOver(score);

        }

        //���̖�萔�̕\�����X�V����
        this.toikazuText.GetComponent<Text>().text = toikazu + "���";
        //���̎c��񐔂̕\�����X�V����
        this.nokorikaisuuText.GetComponent<Text>().text = "�c��" + nokorikaisuu + "��";
        //���̓��_�̕\�����X�V����
        this.scoreText.GetComponent<Text>().text = score + "�_";

        //�p�l���̐F���X�V����
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

        //�\�������{�^�����������ꍇ�̏���
        public void GetJyuujikesiButtonDown()
    {
        this.isKurosukesiButton = false;
        this.isRasenkesiButton = false;
        this.isJyuujikesiButton = true;
    }
    //�N���X�����{�^�����������ꍇ�̏���
    public void GetKurosukesiButtonDown()
    {
        this.isJyuujikesiButton = false;
        this.isRasenkesiButton = false;
        this.isKurosukesiButton = true;
    }
    //���������{�^�����������ꍇ�̏���
    public void GetRasenkesiButtonDown()
    {
        this.isJyuujikesiButton = false;
        this.isKurosukesiButton = false;
        this.isRasenkesiButton = true;
    }

    //�Q�[���X�g�b�v����߂�֐�(ButtonController����Ăяo���p)
    public void SetGamestopfalse()
    {
        gamestop = false;
    }

    //�p�l���̏�����
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

    //�p�l���̍��v���v�Z
    void Panerugoukei()
    {
        //�p�l���̍��v��������
        Panerusum = 0;
        //�p�l���̍��v���v�Z
        for (int y = 0; y < 7; y++)
        {
            for (int x = 0; x < 7; x++)
            {
                Panerusum += Paneru[x, y];
            }
        }
    }

    //���쐬1�Z�b�g
    void Toisakusei()
    {
        //���z�u�s
        int toigyou = Random.Range(1, Paneru.GetLength(0)-1);
        //���z�u��
        int toiretu = Random.Range(1, Paneru.GetLength(1)-1);
        //���쐬�p�^�[��3���
        int toikata = Random.Range(1, 4);
        //���}�X�� (4�`6�}�X)
        int toisum = Random.Range(4, 7);
        //�����toi�̃}�X�̍��v�̌v�Z�p
        int toisumnow = 0;
        //toi������
        for (int Seti = 0; Seti < toi.GetLength(0); Seti++)
        {
            for (int Setj = 0; Setj < toi.GetLength(1); Setj++)
            {
                toi[Seti, Setj] = 0;
            }
        }

        //���}�X���ɂȂ�܂Ŕz�u�����߂�
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
            //��̍��v���v�Z
            for (int Seti = 0; Seti < toi.GetLength(0); Seti++)
            {
                for (int Setj = 0; Setj < toi.GetLength(1); Setj++)
                {
                    toisumnow += toi[Seti, Setj];
                }
            }
        }

        //�����toi�z���Paneru�ɑ���
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

        //��Փx�ύX�p�o�ߎ��ԃ��Z�b�g
        hardtime = 0;
    }

    //��쐬�\��
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
    //��쐬�N���X
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

    //��쐬����
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

    //�����֐�
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

    //�{�^������
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

    //Button00����������������ɉ�����(0,0)���S�̏���������
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

    //�p�l���̐F�ύX
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

        //�������{�^���̐F�ύX
        void KesikataColorChange(GameObject color, bool colorx)
    {
        if(colorx == true)
        {
            color.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if(colorx == false)
        {
            color.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
