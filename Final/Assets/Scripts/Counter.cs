using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public int i;
    private TMP_Text tmpText;
    private float timer;

    void Start()
    {
        tmpText = GetComponent<TMP_Text>();
        tmpText.rectTransform.pivot = new Vector2(0, 1);
        tmpText.rectTransform.sizeDelta = new Vector2(400, 100);
        tmpText.text = $"Count: {GlobalVariables.capsuleCount[i]}\nPer Second: {GlobalVariables.capsulePS[i]}\nGenerator Cost: {GlobalVariables.capsuleGens[i].price}\nUpgrade Cost: {GlobalVariables.capsuleGens[i].upgradePrice}";
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0f;
            tmpText.text = $"Count: {GlobalVariables.capsuleCount[i]}\nPer Second: {GlobalVariables.capsulePS[i]}\nGenerator Cost: {GlobalVariables.capsuleGens[i].price}\nUpgrade Cost: {GlobalVariables.capsuleGens[i].upgradePrice}";
        }
    }
}