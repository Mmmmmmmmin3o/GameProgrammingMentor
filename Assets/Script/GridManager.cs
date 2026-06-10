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

    void CloneElement(int p_x, int p_y, float tileWidth, float tileHeight)
    {
        GameObject copyobj = GameObject.Instantiate(CloneTile.gameObject);
        copyobj.transform.SetParent(this.transform);

        // 타일 크기만큼 곱해주기
        Vector3 temppos= new Vector3(p_x * tileWidth, p_y * tileHeight, 0);
        copyobj.transform.localPosition = temppos;

        copyobj.name = "CloneTile_" + p_x.ToString() + "_" + p_y.ToString();
    }
    
    void GenaratorMineSweeper()
    {

        // 프리팹의 실제 월드 크기 가져오기
        float tileWidth = CloneTile.GetComponent<SpriteRenderer>().bounds.size.x;
        float tileHeight = CloneTile.GetComponent<SpriteRenderer>().bounds.size.y;

        for (int yy = 0; yy < HeightBlock; ++yy)
        {
            for (int xx = 0; xx < WidthBlock; ++xx)
            {
                CloneElement(xx, yy, tileWidth, tileHeight);
            }
        }
    }

    void Start()
    {
        GenaratorMineSweeper();
    }
}
