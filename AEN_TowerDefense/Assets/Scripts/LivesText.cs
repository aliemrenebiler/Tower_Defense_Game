using UnityEngine;
using UnityEngine.UI;

public class LivesText : MonoBehaviour
{
    public Text livesText;

    void Update()
    {
        livesText.text = PlayerStats.lives.ToString() + " Lives";
    }
}
