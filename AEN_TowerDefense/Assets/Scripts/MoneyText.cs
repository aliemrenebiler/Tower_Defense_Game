using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    public Text moneyText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + PlayerStats.money.ToString();
    }
}
