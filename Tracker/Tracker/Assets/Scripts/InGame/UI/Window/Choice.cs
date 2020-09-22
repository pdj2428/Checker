using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    public GameObject _pannel;
    public Animator[] animator;
    public GameObject pannel;
    public GameObject[] choiceButtons;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public void Hospital()
    {
        pannel.SetActive(true);
        if (GameManager.day >= 1 && animator[0].GetBool("Check"))
        {
            animator[0].SetBool("Check", false);
            animator[0].SetBool("UnCheck", true);
        }
        if (GameManager.day >= 3 && animator[1].GetBool("Check"))
        {
            animator[1].SetBool("Check", false);
            animator[1].SetBool("CheckOut", true);
        }
        if (GameManager.day >= 4 && animator[2].GetBool("BloodTest"))
        {
            animator[2].SetBool("CheckBloodTestTable", false);
            animator[2].SetBool("PutBloodTestTable", false);
            animator[2].SetBool("BloodTest", false);
            animator[2].SetBool("ChangeSyringe", true);
        }
        if(GameManager.day >= 5 && animator[3].GetBool("GetIDCard"))
        {
            animator[3].SetBool("GetIDCard", false);
            animator[3].SetBool("TakeBackIDCard", true);
        }
        
        Invoke("ClosePannel", 5);

        GameObject nextMan = MoveQueue();

        nextMan.transform.DOMove(nextMan.transform.position - new Vector3(50, -50), 10);

        choiceButtons[0].SetActive(false);
        choiceButtons[1].SetActive(false);
    }

    public void Pass()
    {
        pannel.SetActive(true);
        if (GameManager.day >= 1 && animator[0].GetBool("Check"))
        {
            animator[0].SetBool("Check", false);
            animator[0].SetBool("UnCheck", true);
        }
        if (GameManager.day >= 3 && animator[1].GetBool("Check"))
        {
            animator[1].SetBool("Check", false);
            animator[1].SetBool("CheckOut", true);
        }
        if (GameManager.day >= 4 && animator[2].GetBool("BloodTest"))
        {
            animator[2].SetBool("CheckBloodTestTable", false);
            animator[2].SetBool("PutBloodTestTable", false);
            animator[2].SetBool("BloodTest", false);
            animator[2].SetBool("ChangeSyringe", true);
        }
        if (GameManager.day >= 5 && animator[3].GetBool("GetIDCard"))
        {
            animator[3].SetBool("GetIDCard", false);
            animator[3].SetBool("TakeBackIDCard", true);
        }

        Invoke("ClosePannel", 5);

        GameObject nextMan = MoveQueue();

        nextMan.transform.DOMove(nextMan.transform.position + Vector3.right * 10, 5);

        choiceButtons[0].SetActive(false);
        choiceButtons[1].SetActive(false);
    }

    private void ClosePannel()
    {
        pannel.SetActive(false);
    }

    public GameObject MoveQueue()
    {
        GameObject firstMan = GameManager.characterQueue[0];
        GameManager.characterQueue.Remove(firstMan);

        firstMan.transform.DOMove(Vector3.zero, 1).OnComplete(MoveOthers);
        return firstMan;
    }

    void MoveOthers()
    {
        for (int i = 0; i < GameManager.characterQueue.Count; i++)
        {
            Transform m = GameManager.characterQueue[i].transform;
            m.DOMove(m.transform.position + Vector3.right * 4, 4);
        }

        if(GameManager.day == 8 && GameManager.nowPeopleNum == 10)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            _pannel.SetActive(true);
            animator[4].SetBool("FadeIn", true);
            Invoke("Ending", 7);
        }
    }

    private void Ending()
    {
        SceneManager.LoadScene("Ending");
    }
}
