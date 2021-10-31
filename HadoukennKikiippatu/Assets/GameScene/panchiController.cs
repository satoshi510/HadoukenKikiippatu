using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panchiController : MonoBehaviour
{

    GameObject panchi;
    GameObject Circle1;
    GameObject Circle2;
    GameObject Circle3;
    GameObject Circle4;
    bool action = false;
    float timer = 0;

    //消し方
    bool jyuuji = false;
    bool kurosu = false;
    bool rasen = false;

    //座標決定用変数
    int zahyoux = 0;
    int zahyouy = 0;

    // Start is called before the first frame update
    void Start()
    {
        panchi = GameObject.Find("panchi");
        Circle1 = GameObject.Find("Circle1");
        Circle2 = GameObject.Find("Circle2");
        Circle3 = GameObject.Find("Circle3");
        Circle4 = GameObject.Find("Circle4");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(action == false)
        {
            this.panchi.GetComponent<SpriteRenderer>().enabled = false;
            this.Circle1.GetComponent<SpriteRenderer>().enabled = false;
            this.Circle2.GetComponent<SpriteRenderer>().enabled = false;
            this.Circle3.GetComponent<SpriteRenderer>().enabled = false;
            this.Circle4.GetComponent<SpriteRenderer>().enabled = false;
            timer = 0;
        }

        if(action == true)
        {
            
            if(jyuuji == true)
            {
                this.panchi.GetComponent<Transform>().position = new Vector3(1.2f * zahyoux, 1.2f * zahyouy, 0);
                this.Circle1.GetComponent<Transform>().position = new Vector3(1.2f * (zahyoux + 1) + 3 * timer, 1.2f * zahyouy, 0);
                this.Circle1.GetComponent<Transform>().localScale = new Vector3(1 + 5 * timer, 0.5f, 0);
                this.Circle1.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
                this.Circle2.GetComponent<Transform>().position = new Vector3(1.2f * (zahyoux - 1) - 3 * timer, 1.2f * zahyouy, 0);
                this.Circle2.GetComponent<Transform>().localScale = new Vector3(1 + 5 * timer, 0.5f, 0);
                this.Circle2.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
                this.Circle3.GetComponent<Transform>().position = new Vector3(1.2f * zahyoux, 1.2f * (zahyouy + 1) + 3 * timer, 0);
                this.Circle3.GetComponent<Transform>().localScale = new Vector3(0.5f, 1 + 5 * timer, 0);
                this.Circle3.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
                this.Circle4.GetComponent<Transform>().position = new Vector3(1.2f * zahyoux, 1.2f * (zahyouy - 1) - 3 * timer, 0);
                this.Circle4.GetComponent<Transform>().localScale = new Vector3(0.5f, 1 + 5 * timer, 0);
                this.Circle4.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            }

            if (kurosu == true)
             {
                this.panchi.GetComponent<Transform>().position = new Vector3(1.2f * zahyoux, 1.2f * zahyouy, 0);
                this.Circle1.GetComponent<Transform>().position = new Vector3(1.2f * (zahyoux + 1) + 3 * timer, 1.2f * (zahyouy + 1) + 3 * timer, 0);
                this.Circle1.GetComponent<Transform>().localScale = new Vector3(1 + 5 * timer, 0.5f, 0);
                this.Circle1.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 45);
                this.Circle2.GetComponent<Transform>().position = new Vector3(1.2f * (zahyoux - 1) - 3 * timer, 1.2f * (zahyouy - 1) - 3 * timer, 0);
                this.Circle2.GetComponent<Transform>().localScale = new Vector3(1 + 5 * timer, 0.5f, 0);
                this.Circle2.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 45);
                this.Circle3.GetComponent<Transform>().position = new Vector3(1.2f * (zahyoux + 1) + 3 * timer, 1.2f * (zahyouy - 1) - 3 * timer, 0);
                this.Circle3.GetComponent<Transform>().localScale = new Vector3(0.5f, 1 + 5 * timer, 0);
                this.Circle3.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 45);
                this.Circle4.GetComponent<Transform>().position = new Vector3(1.2f * (zahyoux - 1) - 3 * timer, 1.2f * (zahyouy + 1) + 3 * timer, 0);
                this.Circle4.GetComponent<Transform>().localScale = new Vector3(0.5f, 1 + 5 * timer, 0);
                this.Circle4.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 45);
            }
            
            if(rasen == true)
            {
                this.panchi.GetComponent<Transform>().position = new Vector3(1.2f * zahyoux, 1.2f * zahyouy, 0);
                this.Circle1.GetComponent<Transform>().position = new Vector3(1.2f * (zahyoux + 1) + 6 * timer, 1.2f * (zahyouy + 0.5f) + 6 * timer, 0);
                this.Circle1.GetComponent<Transform>().localScale = new Vector3(1 + 5 * timer, 0.5f, 0);
                this.Circle1.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0 + timer * 450);
                this.Circle2.GetComponent<Transform>().position = new Vector3(1.2f * (zahyoux - 1) - 6 * timer, 1.2f * (zahyouy - 0.5f) - 6 * timer, 0);
                this.Circle2.GetComponent<Transform>().localScale = new Vector3(1 + 5 * timer, 1 / 2, 0);
                this.Circle2.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0 + timer * 450);
                this.Circle3.GetComponent<Transform>().position = new Vector3(1.2f * (zahyoux + 0.5f) + 6 * timer, 1.2f * (zahyouy - 1) - 6 * timer, 0);
                this.Circle3.GetComponent<Transform>().localScale = new Vector3(0.5f, 1 + 5 * timer, 0);
                this.Circle3.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0 + timer * 450);
                this.Circle4.GetComponent<Transform>().position = new Vector3(1.2f * (zahyoux - 0.5f) - 6 * timer, 1.2f * (zahyouy + 1) + 6 * timer, 0);
                this.Circle4.GetComponent<Transform>().localScale = new Vector3(0.5f, 1 + 5 * timer, 0);
                this.Circle4.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0 + timer * 450);

            }

            this.panchi.GetComponent<SpriteRenderer>().enabled = true;
            this.Circle1.GetComponent<SpriteRenderer>().enabled = true;
            this.Circle2.GetComponent<SpriteRenderer>().enabled = true;
            this.Circle3.GetComponent<SpriteRenderer>().enabled = true;
            this.Circle4.GetComponent<SpriteRenderer>().enabled = true;

            if(timer > 0.2)
            {
                action = false;
                jyuuji = false;
                kurosu = false;
                rasen = false;
            }

        }

    }


    //PaneruControllerから引き出す用 変数は座標
    public void jyuujiAction(int x, int y)
    {
        zahyoux = x-3;
        zahyouy = 3-y;
        jyuuji = true;
        action = true;
    }

    public void kurosuAction(int x, int y)
    {
        zahyoux = x-3;
        zahyouy = 3-y;
        kurosu = true;
        action = true;
    }
    public void rasenAction(int x, int y)
    {
        zahyoux = x-3;
        zahyouy = y-3;
        rasen = true;
        action = true;
    }
}
