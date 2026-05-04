using UnityEngine;

public class TickUpdates : MonoBehaviour
{

    [System.Serializable]
    public struct CylinderData
    {
        public Transform cylinder;
        public float heightMultiplier;
        public ParticleSystem particles; 
        [HideInInspector] public float baseY;
        [HideInInspector] public bool reachMax;
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
            GlobalVariables.capsulePS[i] = 0;
        }
        for (int i = 0; i < GlobalVariables.capsuleGens.Length; i++)
        {
            GlobalVariables.capsuleGens[i] = new GlobalVariables.CapsuleGen { count = 0, ps = 1, price = 100, upgradePrice = 1000 };
        }
        for (int i = 0; i < cylinders.Length; i++)
        {
            cylinders[i].baseY = cylinders[i].cylinder.position.y - cylinders[i].cylinder.localScale.y;
            cylinders[i].heightMultiplier = 0.0025f; // Adjust this value to control how much the cylinder grows per capsule
            cylinders[i].reachMax = false; 
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
            float cappedCount = Mathf.Min(GlobalVariables.capsuleCount[i], 150);
            float newScaleY = Mathf.Max(0.01f, cappedCount * cylinders[i].heightMultiplier);

            Vector3 scale = cylinders[i].cylinder.localScale;
            scale.y = newScaleY;
            cylinders[i].cylinder.localScale = scale;

            Vector3 pos = cylinders[i].cylinder.position;
            pos.y = cylinders[i].baseY + newScaleY;
            cylinders[i].cylinder.position = pos;
            if (!cylinders[i].reachMax &&
                GlobalVariables.capsuleCount[i] >= 150)
            {
                cylinders[i].reachMax = true;

                Vector3 topPos = cylinders[i].cylinder.position;
                topPos.y += cylinders[i].cylinder.localScale.y;

                cylinders[i].particles.transform.position = topPos;
                cylinders[i].particles.Play();
            }
        }
        
            }
}