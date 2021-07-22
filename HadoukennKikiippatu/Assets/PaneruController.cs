using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaneruController : MonoBehaviour
{
    int[,] Paneru = new int[7,7];

    //�\������
    int[,] jyuuji = new int[,] { { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 }, { 1, 1, 1, 1, 1 }, { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 } };
    //�N���X����
    int[,] kurosu = new int[,] { { 1, 0, 0, 0, 1 }, { 0, 1, 0, 1, 0 }, { 0, 0, 1, 0, 0 }, { 0, 1, 0, 1, 0 }, { 1, 0, 0, 0, 1 } };
    //��������
    int[,] rasen = new int[,] { { 1, 1, 0, 0, 1 }, { 0, 0, 0, 0, 1 }, { 0, 0, 1, 0, 0 }, { 1, 0, 0, 0, 0 }, { 1, 0, 0, 1, 1 } };

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


    // Start is called before the first frame update
    void Start()
    {
        //�p�l���̏�����
        for (int i = 0; i < Paneru.GetLength(0); i++)
        {
            for (int j = 0; j < Paneru.GetLength(1); j++)
            {
                Paneru[i, j] = 0;
            }
        }


        //��Փx���̉񐔖��𑫂�
        for(int t=0; t< toihard; t++)
        {
            Toisakusei();
            Toitasizann(toigyou, toiretu);
        }



        

        for (int i = 0; i < Paneru.GetLength(0); i++)
        {
            for (int j = 0; j < Paneru.GetLength(0); j++)
            {
                Debug.Log(Paneru[i, j]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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

    //5x5�����Z
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
}
