using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Solitaire solitaire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        solitaire = FindFirstObjectByType<Solitaire>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseClick();
    }

    void GetMouseClick()
    {
        if(Input.GetMouseButtonDown(0)) // 0은 왼쪽 마우스 버튼
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                if (hit.collider.CompareTag("Deck"))
                {
                    Deck();
                }
                else if (hit.collider.CompareTag("Card"))
                {
                    Card();
                }
                else if(hit.collider.CompareTag("Top"))
                {
                    Top();
                }
                else if (hit.collider.CompareTag("Bottom"))
                {
                    Bottom();
                }
            }
        }
    }

    void Deck()
    {
        solitaire.DealFromDeck();
    }
    void Card()
    {
    }
    void Top()
    {
    }
    void Bottom()
    {
    }
}
