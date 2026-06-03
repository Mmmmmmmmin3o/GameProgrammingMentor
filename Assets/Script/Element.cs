using UnityEngine;

public class Element : MonoBehaviour
{
    
    public Sprite[] ChangeSpriteArray = null;
    private SpriteRenderer m_SpriteRender = null;

    void SetChangeTexture(int p_index)
    {
        m_SpriteRender.sprite = ChangeSpriteArray[p_index];
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_SpriteRender = this.GetComponent<SpriteRenderer>();
        //SetChangeTexture(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
