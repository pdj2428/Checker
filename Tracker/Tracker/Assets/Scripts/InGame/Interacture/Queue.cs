using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public GameObject manPrefab;

    public int count = 100;

    public List<GameObject> man;

    private void Start()
    {
        man = new List<GameObject>();

        for (int i = 0; i < count;  i++)
        {
            GameObject m = Instantiate(manPrefab);
            man.Add(m);
            m.transform.position = new Vector3( -i - 1, 0, 0);
        }
    }

    public GameObject MoveQueue()
    {
        GameObject firstMan = man[0];
        man.Remove(firstMan);

        firstMan.transform.DOMove(Vector3.zero, 1).OnComplete(MoveOthers);
        return firstMan;
    }

    void MoveOthers()
    {
        for (int i = 0; i < man.Count; i++)
        {
            Transform m = man[i].transform;
            m.DOMove(m.transform.position + Vector3.right, 2);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject nextMan = MoveQueue();

            if (Random.Range(0,2) == 0)
            {
                // Good
                nextMan.transform.DOMove(nextMan.transform.position + Vector3.right * 5, 10);
            }
            else
            {
                // Rejected
                nextMan.transform.DOMove(nextMan.transform.position - Vector3.right * 5, 10);
            }
        }
    }
}
