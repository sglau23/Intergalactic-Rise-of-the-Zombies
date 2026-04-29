using UnityEngine;

public class GlobalVariables
{
    public struct CapsuleGen
    {
        public int count;
        public int ps;
        public int price;
        public int upgradePrice;
    }

    public static int[] capsuleCount = new int[13];
    public static int[] capsulePS = new int[13];
    public static CapsuleGen[] capsuleGens = new CapsuleGen[13];

    public static void UpdateProduction()
    {
        for (int i = 0; i < capsuleCount.Length; i++)
        {
            capsulePS[i] = capsuleGens[i].count * capsuleGens[i].ps;
        }
    }
    
}
