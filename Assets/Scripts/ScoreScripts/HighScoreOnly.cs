using UnityEngine;
using TMPro;

public class HighScoreOnly : MonoBehaviour
{
    public TextMeshProUGUI highScoreText_Pro;
    private void Update()
    {
        highScoreText_Pro.text = "Best Time\n" + PlayerPrefs.GetString("BestTime", "0 : 0 : 0");
    }
}
