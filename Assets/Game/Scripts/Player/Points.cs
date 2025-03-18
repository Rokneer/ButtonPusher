using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreTXT;

    [ReadOnly]
    public int ScoreCount = 0;

    public void AddPoint()
    {
        ScoreCount++;
        _scoreTXT.text = ScoreCount.ToString();
    }
}
