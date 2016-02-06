﻿using UnityEngine;
using System.Collections;

public class cameraControll : MonoBehaviour {

    class graphV
    {
        public int x, z, n, en;
        public int[] e;
    }

	// Use this for initialization
	void Start () {
        g = new graphV[1024];
        ax = 0;
        az = 0;
        bx = 0;
        bz = 0;
        k = 0;
	}

    int ci = 0;
    public int ax, az, bx, bz, k;
    const float SL = 0.5f;
    GameObject last, last2;
    int gV = 0;
    graphV[] g;

    public void UseWalls()
    {
        ci = 0;
        k = 0;
        ax = 0;
        az = 0;
        bx = 0;
        bz = 0;
        Del();
    }

    public void Del()
    {
        if (last != null)
        {
            GameObject.Destroy(last);
        }
        if (last2 != null)
        {
            GameObject.Destroy(last2);
        }
    }

    public void UseDoors()
    {
        ci = 1;
        k = 0;
        ax = 0;
        az = 0;
        bx = 0;
        bz = 0;
        Del();
    }

    public void UseGraph()
    {
        ci = 2;
        k = 0;
        ax = 0;
        az = 0;
        bx = 0;
        bz = 0;
        Del();
    }

    void countWall()
    {
        last = null;
        last2 = null;
        if (k == 0)
        {
            Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit help;
            if (Physics.Raycast(myray, out help))
            {
                ax = Mathf.RoundToInt(help.point.x);
                if ((ax % 5 - 1) % 5 == 0)
                    ax--;
                else if ((ax % 5 - 2) % 5 == 0)
                    ax -= 2;
                else if ((ax % 5 + 2) % 5 == 0)
                    ax += 2;
                else if ((ax % 5 + 1) % 5 == 0)
                    ax++;
                else if ((ax % 5 + 3) % 5 == 0)
                    ax += 3;
                az = Mathf.RoundToInt(help.point.z);
                if ((az % 5 - 1) % 5 == 0)
                    az--;
                else if ((az % 5 - 2) % 5 == 0)
                    az -= 2;
                else if ((az % 5 + 2) % 5 == 0)
                    az += 2;
                else if ((az % 5 + 1) % 5 == 0)
                    az++;
                else if ((az % 5 + 3) % 5 == 0)
                    az += 3;
            }
        }
        else
        {
            Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit help;
            if (Physics.Raycast(myray, out help))
            {
                bx = Mathf.RoundToInt(help.point.x);
                if ((bx % 5 - 1) % 5 == 0)
                    bx--;
                else if ((bx % 5 - 2) % 5 == 0)
                    bx -= 2;
                else if ((bx % 5 + 2) % 5 == 0)
                    bx += 2;
                else if ((bx % 5 + 1) % 5 == 0)
                    bx++;
                else if ((bx % 5 + 3) % 5 == 0)
                    bx += 3;
                bz = Mathf.RoundToInt(help.point.z);
                if ((bz % 5 - 1) % 5 == 0)
                    bz--;
                else if ((bz % 5 - 2) % 5 == 0)
                    bz -= 2;
                else if ((bz % 5 + 2) % 5 == 0)
                    bz += 2;
                else if ((bz % 5 + 1) % 5 == 0)
                    bz++;
                else if ((bz % 5 + 3) % 5 == 0)
                    bz += 3;
                if (Mathf.Abs(bx - ax) < Mathf.Abs(bz - az))
                {
                    bx = ax;
                }
                else
                {
                    bz = az;
                }
            }
        }
        k++;
        if (k == 2)
        {
            k = 0;
            float aax = ax;
            float aaz = az;
            float bbx = bx;
            float bbz = bz;
            var W = GameObject.Instantiate(GameObject.Find("/Wall"));
            W.transform.position = new Vector3((aax + bbx) / 2, 0, (aaz + bbz) / 2);
            if (ax == bx)
                W.transform.localScale = new Vector3(0.1f, 6, Mathf.Abs(bz - az));
            else
                W.transform.localScale = new Vector3(Mathf.Abs(bx - ax), 6, 0.1f);
        }
    }

    void countGraph()
    {
        last = null;
        last2 = null;
        if (k == 0)
        {
            Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit help;
            if (Physics.Raycast(myray, out help))
            {
                ax = Mathf.RoundToInt(help.point.x);
                if ((ax % 5 - 1) % 5 == 0)
                    ax--;
                else if ((ax % 5 - 2) % 5 == 0)
                    ax -= 2;
                else if ((ax % 5 + 2) % 5 == 0)
                    ax += 2;
                else if ((ax % 5 + 1) % 5 == 0)
                    ax++;
                else if ((ax % 5 + 3) % 5 == 0)
                    ax += 3;
                az = Mathf.RoundToInt(help.point.z);
                if ((az % 5 - 1) % 5 == 0)
                    az--;
                else if ((az % 5 - 2) % 5 == 0)
                    az -= 2;
                else if ((az % 5 + 2) % 5 == 0)
                    az += 2;
                else if ((az % 5 + 1) % 5 == 0)
                    az++;
                else if ((az % 5 + 3) % 5 == 0)
                    az += 3;
            }
        }
        else
        {
            Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit help;
            if (Physics.Raycast(myray, out help))
            {
                bx = Mathf.RoundToInt(help.point.x);
                if ((bx % 5 - 1) % 5 == 0)
                    bx--;
                else if ((bx % 5 - 2) % 5 == 0)
                    bx -= 2;
                else if ((bx % 5 + 2) % 5 == 0)
                    bx += 2;
                else if ((bx % 5 + 1) % 5 == 0)
                    bx++;
                else if ((bx % 5 + 3) % 5 == 0)
                    bx += 3;
                bz = Mathf.RoundToInt(help.point.z);
                if ((bz % 5 - 1) % 5 == 0)
                    bz--;
                else if ((bz % 5 - 2) % 5 == 0)
                    bz -= 2;
                else if ((bz % 5 + 2) % 5 == 0)
                    bz += 2;
                else if ((bz % 5 + 1) % 5 == 0)
                    bz++;
                else if ((bz % 5 + 3) % 5 == 0)
                    bz += 3;
                if (Mathf.Abs(bx - ax) < Mathf.Abs(bz - az))
                {
                    bx = ax;
                }
                else
                {
                    bz = az;
                }
            }
        }
        k++;
        if (k == 2)
        {
            k = 0;
            float aax = ax;
            float aaz = az;
            float bbx = bx;
            float bbz = bz;
            var W = GameObject.Instantiate(GameObject.Find("/GraphVisual"));
            W.transform.position = new Vector3((aax + bbx) / 2, 0, (aaz + bbz) / 2);
            if (ax == bx)
                W.transform.localScale = new Vector3(0.1f, 6, Mathf.Abs(bz - az));
            else
                W.transform.localScale = new Vector3(Mathf.Abs(bx - ax), 6, 0.1f);
            graphV a = new graphV();
            graphV b = new graphV();
            int ak = gV;
            int bk = gV;
            if (gV != 0)
            {
                for (int i = 0; i < gV; i++)
                {
                    if (g[i].x == ax && g[i].z == az)
                    {
                        a = g[i];
                    }
                    if (g[i].x == bx && g[i].z == bz)
                    {
                        b = g[i];
                    }
                }
            }
            if(ak == gV)
            {
                if(bk == gV)
                {
                    bk++;
                }
                a = new graphV();
                a.x = ax;
                a.z = az;
                a.n = gV;
                a.en = 0;
                a.e = new int[1024];
                gV++;
            }
            if(bk == gV)
            {
                b.x = ax;
                b.z = az;
                b.n = gV;
                b.en = 0;
                b.e = new int[1024];
                gV++;
            }
            a.e[a.en] = b.n;
            b.e[b.en] = a.n;
        }
    }

    void countDoor()
    {
        Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit help;
        if (Physics.Raycast(myray, out help))
        {
            ax = Mathf.RoundToInt(help.point.x);
            if ((ax % 5 - 1) % 5 == 0)
                ax--;
            else if ((ax % 5 - 2) % 5 == 0)
                ax -= 2;
            else if ((ax % 5 + 2) % 5 == 0)
                ax += 2;
            else if ((ax % 5 + 1) % 5 == 0)
                ax++;
            else if ((ax % 5 + 3) % 5 == 0)
                ax += 3;
            az = Mathf.RoundToInt(help.point.z);
            if ((az % 5 - 1) % 5 == 0)
                az--;
            else if ((az % 5 - 2) % 5 == 0)
                az -= 2;
            else if ((az % 5 + 2) % 5 == 0)
                az += 2;
            else if ((az % 5 + 1) % 5 == 0)
                az++;
            else if ((az % 5 + 3) % 5 == 0)
                az += 3;
        }
        if (k == 0)
        {
            var W = GameObject.Instantiate(GameObject.Find("/Wall"));
            last = W;
            W.transform.position = new Vector3(ax - 3.5f, 0, az);
            W.transform.localScale = new Vector3(3, 6, 0.1f);
            W = GameObject.Instantiate(GameObject.Find("/Wall"));
            W.transform.position = new Vector3(ax + 3.5f, 0, az);
            W.transform.localScale = new Vector3(3, 6, 0.1f);
            last2 = W;
        }
        else
        {
            var W = GameObject.Instantiate(GameObject.Find("/Wall"));
            last = W;
            W.transform.position = new Vector3(ax, 0, az - 3.5f);
            W.transform.localScale = new Vector3(0.1f, 6, 3);
            W = GameObject.Instantiate(GameObject.Find("/Wall"));
            W.transform.position = new Vector3(ax, 0, az + 3.5f);
            W.transform.localScale = new Vector3(0.1f, 6, 3);
            last2 = W;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0) * SL;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0) * SL;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, 1) * SL;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -1) * SL;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && ci == 1)
            k = (k + 1) % 2;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (ci == 0)
            {
                countWall();
            }
            else if(ci == 1)
            {
                countDoor();
            }
            else if (ci == 2)
            {
                countGraph();
            }
        }
    }
}
