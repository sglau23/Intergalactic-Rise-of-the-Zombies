using UnityEngine;

public class TickUpdates : MonoBehaviour
{

    [System.Serializable]
    public struct CylinderData
    {
        public Transform cylinder;
        public float heightMultiplier;
        [HideInInspector] public float baseY;
    }
    public CylinderData[] cylinders = new CylinderData[13];

    float timer = 0f;

    void Start()
    {
        for (int i = 0; i < GlobalVariables.capsuleCount.Length; i++)
        {
            GlobalVariables.capsuleCount[i] = 0;
        }
        for (int i = 0; i < GlobalVariables.capsulePS.Length; i++)
        {
            GlobalVariables.capsulePS[i] = 25;
        }
        for (int i = 0; i < GlobalVariables.capsuleGens.Length; i++)
        {
            GlobalVariables.capsuleGens[i] = new GlobalVariables.CapsuleGen { count = 0, ps = 1, price = 100, upgradePrice = 1000 };
        }
        for (int i = 0; i < cylinders.Length; i++)
        {
            cylinders[i].baseY = cylinders[i].cylinder.position.y - cylinders[i].cylinder.localScale.y;
            cylinders[i].heightMultiplier = 0.0025f; // Adjust this value to control how much the cylinder grows per capsule
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

        for (int i = 0; i < cylinders.Length; i++)
        {
            float cappedCount = Mathf.Min(GlobalVariables.capsuleCount[i], 1000);
            float newScaleY = Mathf.Max(0.01f, cappedCount * cylinders[i].heightMultiplier);

            Vector3 scale = cylinders[i].cylinder.localScale;
            scale.y = newScaleY;
            cylinders[i].cylinder.localScale = scale;

            Vector3 pos = cylinders[i].cylinder.position;
            pos.y = cylinders[i].baseY + newScaleY;
            cylinders[i].cylinder.position = pos;
        }
    }
}