using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops 
    {
        public string name;
        public GameObject prefab;
        public float dropRate;
    }

    public List<Drops> drops;

    private void OnDestroy()
    {

        if (!gameObject.scene.isLoaded)
            return;

        float rand = Random.Range(0, 100f);
        List<Drops> possibleDrops = new List<Drops>();

        foreach (Drops rate in drops)
        {
            if(rand <= rate.dropRate)
            {
                possibleDrops.Add(rate);
            }
        }

        if(possibleDrops.Count > 0)
        {
            Drops drops = possibleDrops[Random.Range(0, possibleDrops.Count)];
            Instantiate(drops.prefab, transform.position, Quaternion.identity);

        }


    }

}
