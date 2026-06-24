using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Element CloneTile = null;

    public int WidthBlock = 10;
    public int HeightBlock = 13;

    public Element[,] ElementArray = null;

    void Awake()
    {
        ElementArray = new Element[WidthBlock, HeightBlock];
    }

    Element CloneElement(int p_x, int p_y, float tileWidth, float tileHeight)
    {
        GameObject copyobj = GameObject.Instantiate(CloneTile.gameObject);
        copyobj.transform.SetParent(this.transform);

        Vector3 temppos = new Vector3(p_x * tileWidth, p_y * tileHeight, 0);
        copyobj.transform.localPosition = temppos;

        copyobj.name = "CloneTile_" + p_x.ToString() + "_" + p_y.ToString();

        return copyobj.GetComponent<Element>();
    }

    void GeneratorMineSweeper()
    {
        float tileWidth = CloneTile.GetComponent<SpriteRenderer>().bounds.size.x;
        float tileHeight = CloneTile.GetComponent<SpriteRenderer>().bounds.size.y;

        for (int yy = 0; yy < HeightBlock; ++yy)
        {
            for (int xx = 0; xx < WidthBlock; ++xx)
            {
                ElementArray[xx, yy] = CloneElement(xx, yy, tileWidth, tileHeight);
            }
        }
    }

    bool GetMineAt(int p_x, int p_y)
    {
        if ((p_x > 0 && p_x < WidthBlock) && (p_y > 0 && p_y < HeightBlock))
        {
            return ElementArray[p_x, p_y].ISMine;
        }
        return false;
    }

    public int GetRountMines(int p_x, int p_y)
    {
        int outcount = 0;

        // 상단
        if (GetMineAt(p_x - 1, p_y + 1)) { ++outcount; }
        if (GetMineAt(p_x, p_y + 1)) { ++outcount; }
        if (GetMineAt(p_x + 1, p_y + 1)) { ++outcount; }

        // 중단
        if (GetMineAt(p_x - 1, p_y)) { ++outcount; }
        if (GetMineAt(p_x + 1, p_y)) { ++outcount; }

        // 하단
        if (GetMineAt(p_x - 1, p_y - 1)) { ++outcount; }
        if (GetMineAt(p_x, p_y - 1)) { ++outcount; }
        if (GetMineAt(p_x + 1, p_y - 1)) { ++outcount; }

        return outcount;
    }

    void Start()
    {
        GeneratorMineSweeper();
    }
}
