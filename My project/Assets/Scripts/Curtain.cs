using TMPro;
using UnityEngine;


public class Curtain : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textOnCurtain;

    public void ChangeText(string text)
    {
        textOnCurtain.text = text;
    }
}
