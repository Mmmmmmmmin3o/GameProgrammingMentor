using UnityEngine;
using TMPro;

public class PlayerScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 점수 표시용 UI
    public TextMeshProUGUI keyText;   // 키 아이템 표시용 UI
    private int score = 0;            // 점수 변수
    private int keyCount = 0;         // 키 개수 변수

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            score += 100;
            scoreText.text = $"Score: {score}";

            ItemEffect item = other.GetComponent<ItemEffect>();
            if (item != null)
            {
                item.OnDeath();
            }
        }

        if (other.CompareTag("Key"))
        {
            keyCount++;
            keyText.text = $"Key {keyCount}/4";

            KeyEffect keyEff = other.GetComponent<KeyEffect>();
            if (keyEff != null)
            {
                keyEff.OnDeath();
            }
        }
    }
}
