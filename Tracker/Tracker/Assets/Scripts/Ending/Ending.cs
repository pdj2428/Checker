using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Text[] text;
    public Sprite[] SpriteRenderer;
    public GameObject[] _image;
    public Image[] image;
    private int endingNum;

    private int clickCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        _image[0].SetActive(false);
        _image[1].SetActive(false);

        if(PlayerPrefs.GetInt("FromMenu") != 1)
        {
            if (PlayerPrefs.GetInt("GoHospitalHuman") + PlayerPrefs.GetInt("PassedAbnormalHuman") <= 10)
            {
                PlayerPrefs.SetInt("SelectEnding", 1);
            }
            else if (PlayerPrefs.GetInt("GoHospitalHuman") + PlayerPrefs.GetInt("PassedAbnormalHuman") <= 50)
            {
                PlayerPrefs.SetInt("SelectEnding", 2);
            }
            else if (PlayerPrefs.GetInt("GoHospitalHuman") + PlayerPrefs.GetInt("PassedAbnormalHuman") > 50)
            {
                PlayerPrefs.SetInt("SelectEnding", 3);
            }
        }

        if (PlayerPrefs.GetInt("SelectEnding") == 1)
        {
            endingNum = 1;
            PlayerPrefs.SetInt("Ending1", 1);

            text[0].text = "갑작스러운 죽음에 당황하셨지만, 죽음은 예고하고 찾아오지 않습니다.\n당신의 죽음은 많은 사람들에게 충격을 안겨줬습니다.\n파란색 바이러스의 첫 죽음, 그것이 당신이 된 것입니다.\n이로써 색과 바이러스의 증상은 상관이 없다는 것이 증명되었습니다.\n당신의 인생은... 어땠을까요?";
        }
        else if (PlayerPrefs.GetInt("SelectEnding") == 2)
        {
            _image[3].SetActive(true);
            endingNum = 2;
            PlayerPrefs.SetInt("Ending2", 1);
            text[0].text = "갑작스러운 죽음에 당황하셨지만, 죽음은 예고하고 찾아오지 않습니다.\n당신의 죽음은 의미가 없었습니다.\n파란색 바이러스의 첫 죽음, 그것이 당신이 된 것입니다.\n하지만 그 누구도 관심이 없었습니다.\n총리의 죽음과는 다르군요.";
        }
        else if (PlayerPrefs.GetInt("SelectEnding") == 3)
        {
            endingNum = 3;
            PlayerPrefs.SetInt("Ending3", 1);
            text[0].text = "갑작스러운 죽음에 당황하셨지만, 죽음은 예고하고 찾아오지 않습니다.\n당신의 죽음은 많은 사람들에게 충격을 안겨줬습니다.\n파란색 바이러스의 첫 죽음, 그것이 당신이 된 것입니다.\n이로써 색과 바이러스의 증상은 상관이 없다는 것이 증명되었습니다.\n당신의 인생은... 어땠을까요?";
        }
    }

    private void Update()
    {
        if( Input.GetMouseButtonDown(0) && endingNum != 2)
        {
            clickCount++;            
        }
        if (clickCount == 1)
        {
            _image[2].SetActive(false);
            _image[0].SetActive(true);
            if (endingNum == 1)
            {
                image[0].sprite = SpriteRenderer[1];

                text[1].text = "당신은 미디어의 영향을 받지 않은 유일한 사람이었습니다.\n\n색이아닌, 증상으로 사람을 구분하였군요.\n\n당신의 많은 사람들에게 안식을 주었습니다.\n\n많은 사람들이 당신의 죽음을 추모했습니다.";
            }
            else if (endingNum == 3)
            {
                image[0].sprite = SpriteRenderer[0];
                text[1].text = "당신은 미디어의 영향을 가장 크게 받았습니다.\n\n색으로만 사람을 구분하고, 차별한 사람입니다.\n\n당신의 죽음으로 인해 많은 사람들이 분노하였습니다.\n\n하지만 정부는 당신과 관계 없다고 하는군요.";
            }
        }
        else if (clickCount == 2)
        {
            PlayerPrefs.SetInt("FromMenu", 0);
            PlayerPrefs.SetInt("GoHospitalHuman", 0);
            PlayerPrefs.SetInt("PassedAbnormalHuman", 0);
            PlayerPrefs.SetInt("SelectEnding", 0);
            _image[1].SetActive(true);
            _image[3].SetActive(true);
            if (endingNum == 1)
            {
                image[1].sprite = SpriteRenderer[2];
                text[2].text = "n총리를 죽인 범인은 의료진이었습니다.\n\n차별을 만드는 세상을 증오했던 한 국가 의료진이, 일을 터트린 것이죠\n\n그는 구속 되었고, 한 명이 더 구속됐습니다\n\n바로 끔찍한 흑인 혐오자 김태상 교수입니다.";
            }
            else if (endingNum == 3)
            {
                image[1].sprite = SpriteRenderer[2];
                text[2].text = "n총리를 죽인 범인은 의료진이었습니다.\n차별을 만드는 세상을 증오했던 한 국가 의료진이, 일을 터트린 것이죠\n그는 구속 되었고, 한 명이 더 구속됐습니다\n바로 끔찍한 흑인 혐오자 김태상 교수입니다.\n이들은 미디어와 SNS가 지배한 세상에 살고 있습니다.\n선동과 날조, 끝나지 않는 사상검증\n그렇게 그들은 손가락으로 수많은 유명인들을 죽였습니다.\n이렇게 절망적이고 폭력적인 세상은 더 없습니다.\n하지만 걱정마세요, 우리랑은 상관없는 세상이니까요.";
            }
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
}
