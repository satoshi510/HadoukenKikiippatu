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
            else if (toikata ==3)
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
    //�\�������֐�
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
                    }
                }
                Jkesil++;
            }
            Jkesil = 0;
            Jkesik++;
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
                    }
                }
                Kkesil++;
            }
            Kkesil = 0;
            Kkesik++;
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
                    }
                }
                Rkesil++;
            }
            Rkesil = 0;
            Rkesik++;
        }
        Rkesik = 0;
        Rkesil = 0;
    }

    //Button00����������������ɉ�����(0,0)���S�̏���������
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

    //�{�^���̐F�ύX
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
