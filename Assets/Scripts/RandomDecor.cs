using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDecor : MonoBehaviour
{
    [SerializeField] GameObject[] decorPrefabs;

    DungeonGenerator myGenerator;
    bool isCompleted;
    // Start is called before the first frame update
    void Start()
    {
        myGenerator = GameObject.Find("Generator").GetComponent<DungeonGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCompleted && myGenerator.dungeonState == DungeonState.completed)
        {
            isCompleted = true;
            int decorIndex = Random.Range(0, decorPrefabs.Length);
            GameObject goDecor = Instantiate(decorPrefabs[decorIndex], transform.position, Quaternion.identity, transform) as GameObject;
            goDecor.name = decorPrefabs[decorIndex].name;
        }
    }

}
