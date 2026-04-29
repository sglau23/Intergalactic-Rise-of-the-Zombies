using UnityEngine;

public class TickUpdates : MonoBehaviour
{
    float timer = 0f;

    void Start()
    {
        for (int i = 0; i < GlobalVariables.capsuleCount.Length; i++)
        {
            GlobalVariables.capsuleCount[i] = 0;
        }
        for (int i = 0; i < GlobalVariables.capsulePS.Length; i++)
        {
            GlobalVariables.capsulePS[i] = 0;
        }
        for (int i = 0; i < GlobalVariables.capsuleGens.Length; i++)
        {
            GlobalVariables.capsuleGens[i] = new GlobalVariables.CapsuleGen { count = 0, ps = 1, price = 100, upgradePrice = 1000 };
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0f;
            for (int i = 0; i < GlobalVariables.capsuleCount.Length; i++)
            {
                GlobalVariables.capsuleCount[i] += GlobalVariables.capsulePS[i];
            }
        }
    }
}