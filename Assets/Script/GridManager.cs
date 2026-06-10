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

    void GenaratorMineSweeper()
    {
        GameObject copyobj = null;
        Vector3 temppos = Vector3.zero;

        // 프리팹의 실제 월드 크기 가져오기
        float tileWidth = CloneTile.GetComponent<SpriteRenderer>().bounds.size.x;
        float tileHeight = CloneTile.GetComponent<SpriteRenderer>().bounds.size.y;

        for (int yy = 0; yy < HeightBlock; ++yy)
        {
            for (int xx = 0; xx < WidthBlock; ++xx)
            {
                copyobj = GameObject.Instantiate(CloneTile.gameObject);
                copyobj.transform.SetParent(this.transform);

                // 타일 크기만큼 곱해주기
                temppos.Set(xx * tileWidth, yy * tileHeight, 0);
                copyobj.transform.localPosition = temppos;

                copyobj.name = "CloneTile_" + xx.ToString() + "_" + yy.ToString();
            }
        }
    }

    void Start()
    {
        GenaratorMineSweeper();
    }
}
