using UnityEngine;
using System.Collections.Generic;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private Solitaire solitaire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<string> deck=Solitaire.GenerateDeck();
        solitaire = Object.FindFirstObjectByType<Solitaire>();

        int i = 0;
        foreach(string card in deck)
        {
            if (this.name == card)
            {
                cardFace = solitaire.cardFaces[i];
                break;
            }
            i++;
        }
        spriteRenderer=GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectable != null && spriteRenderer != null)
        {
            if (selectable.faceUp)
            {
                spriteRenderer.sprite = cardFace;
            }
            else
            {
                spriteRenderer.sprite = cardBack;
            }
        }
    }

}
