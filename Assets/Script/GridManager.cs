using System.CodeDom.Compiler;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    
    public Element CloneBlock = null;

    public int WidthBlock = 10;
    public int HeightBlock = 13;

    public Element[,] ElementArray = null; // new Element[WidthBlock, HeighrBlock];


    void Awake()
    {
        ElementArray = new Element[WidthBlock, HeightBlock];
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void GenaratorMineSweeper()
    {
        GameObject copyobj = null;
        Vector3 temppos = Vector3.zero;
        for(int yy=0; yy< HeightBlock; ++yy)
        {
            for(int xx=0; xx< WidthBlock; ++xx)
            {
                copyobj = GameObject.Instantiate(CloneBlock.gameObject);
                copyobj.transform.SetParent(this.transform);
                temppos.Set(xx, yy, 0);
                copyobj.transform.localPosition = temppos;
                copyobj.name = "CloneBlock_" + xx.ToString() + "_" + yy.ToString();
            }
        }


    }
    void Start()
    {
        GenaratorMineSweeper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
