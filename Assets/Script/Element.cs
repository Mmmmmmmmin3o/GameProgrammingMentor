using UnityEngine;

public class Element : MonoBehaviour
{
    
    public Sprite[] ChangeSpriteArray = null;
    private SpriteRenderer m_SpriteRender = null;

    protected GridManager GridLinkManager = null;

    [SerializeField]

    private bool m_ISMine = false;
    public bool ISMine
    {
        get { return m_ISMine; }
        set { m_ISMine = value; }
    }

    public void SetElementDatas(bool p_isMine)
    {
        m_ISMine = p_isMine;
    }

    void SetChangeTexture(int p_index)
    {
        m_SpriteRender.sprite = ChangeSpriteArray[p_index];
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_SpriteRender = this.GetComponent<SpriteRenderer>();
        GridLinkManager = GameObject.FindFirstObjectByType<GridManager>();
        //FindObjectOfType 권장되지 않아서 오류 뜨는것, 무시 가능
        //SetChangeTexture(0);
    }

    void OnMouseDown()
    {
       Debug.Log("Tile Clicked :"+ this.name);

        if (m_ISMine)
        {
            //게임오버
        }
        else
        {
            int x = (int)this.transform.localPosition.x;
            int y = (int)this.transform.localPosition.y;
            //주변 지뢰 개수
            //int rountminecount=GridLinkManager.GetRountMines(1,1);
            SetChangeTexture(GridLinkManager.GetRountMines(x, y));
        }
    }

}
