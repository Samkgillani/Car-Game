using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] patches,props;
    public GameObject startingPatch,endingPatch;
    Transform spawnPosition;
    GameObject tempPatch;
    int noOfPatches=10;
    private void Start()
    {
        spawnPosition = transform;
        noOfPatches =Mathf.Clamp(MainMenu.levelNum/2,1,10);
        PatchGeneration();
    }
    void PatchGeneration()
    {
        tempPatch = Instantiate(startingPatch, spawnPosition.position, spawnPosition.rotation, transform);
        spawnPosition = tempPatch.GetComponent<PatchData>().nextPosition;
        PropGeneration(tempPatch.GetComponent<PatchData>().propParent);
        for (int i = 0; i < noOfPatches; i++)
        {
            tempPatch=Instantiate(patches[Random.Range(0,patches.Length)], spawnPosition.position, spawnPosition.rotation, transform);
            spawnPosition = tempPatch.GetComponent<PatchData>().nextPosition;
            PropGeneration(tempPatch.GetComponent<PatchData>().propParent);
        }
        tempPatch = Instantiate(endingPatch, spawnPosition.position, spawnPosition.rotation, transform);
        spawnPosition = tempPatch.GetComponent<PatchData>().nextPosition;
        PropGeneration(tempPatch.GetComponent<PatchData>().propParent);
    }
    void PropGeneration(Transform _propsParent)
    {
        int propNum = Random.Range(0, props.Length);
        for (int i = 0; i < _propsParent.childCount; i++)
        {
            Instantiate(props[propNum],_propsParent.GetChild(i).position,_propsParent.GetChild(i).rotation,_propsParent.GetChild(i));
        }
    }
}
