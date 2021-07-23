using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaneruController : MonoBehaviour
{
    //���̃p�l���̏��
    int[,] Paneru = new int[7,7];
    //�p�l���̍��v
    int Panerusum = 0;

    //�\������
    int[,] jyuuji = new int[,] { 
        { 0, 0, 1, 0, 0 }, 
        { 0, 0, 1, 0, 0 }, 
        { 1, 1, 1, 1, 1 }, 
        { 0, 0, 1, 0, 0 }, 
        { 0, 0, 1, 0, 0 } 
    };
    //�N���X����
    int[,] kurosu = new int[,] { 
        { 1, 0, 0, 0, 1 }, 
        { 0, 1, 0, 1, 0 }, 
        { 0, 0, 1, 0, 0 }, 
        { 0, 1, 0, 1, 0 }, 
        { 1, 0, 0, 0, 1 } 
    };
    //��������
    int[,] rasen = new int[,] { 
        { 1, 1, 0, 0, 1 }, 
        { 0, 0, 0, 0, 1 }, 
        { 0, 0, 1, 0, 0 }, 
        { 1, 0, 0, 0, 0 }, 
        { 1, 0, 0, 1, 1 } 
    };

    //���쐬�p�z��
    int[,] toi = new int[5, 5];
    //���z�u�s
    int toigyou;
    //���z�u��
    int toiretu;
    //���쐬�p�^�[��
    int toikata;
    //���}�X��
    int toisum;
    //����Փx������
    int toihard = 1;

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




    // Start is called before the first frame update
    void Start()
    {
        //�p�l���̏�����
        for (int i = 0; i < Paneru.GetLength(0); i++)
        {
            for (int j = 0; j < Paneru.GetLength(1); j++)
            {
                Paneru[i, j] = 1;
            }
        }

        //�{�^���̃I�u�W�F�N�g����荞��
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


        //��Փx���̉񐔖��𑫂�
        for (int t=0; t< toihard; t++)
        {
            Toisakusei();
            Toitasizann(toigyou, toiretu);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //�p�l���̍��v��������
        Panerusum = 0;


        //�{�^���̐F���X�V����
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

    //5x5toi�����Z
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
                }
                Tasil++;
            }
            Tasil = 0;
            Tasik++;
        }
        Tasik = 0;
        Tasil = 0;
    }

    //���쐬1�Z�b�g
    void Toisakusei()
    {
        //���z�u�s
        toigyou = Random.Range(1, Paneru.GetLength(0)-1);
        //���z�u��
        toiretu = Random.Range(1, Paneru.GetLength(1)-1);
        //���쐬�p�^�[��3���
        toikata = Random.Range(1, 4);
        //���}�X�� (3�`5�}�X)
        toisum = Random.Range(3, 6);
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
        }
        else if (this.isKurosukesiButton == true)
        {
            Kesi(x, y, kurosu);
            this.isKurosukesiButton = false;
        }
        else if (this.isRasenkesiButton == true)
        {
            Kesi(x, y, rasen);
            this.isRasenkesiButton = false;
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
    //�������{�^���̐F�ύX
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
