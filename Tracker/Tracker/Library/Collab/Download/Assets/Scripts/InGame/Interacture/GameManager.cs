using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 컬러 넘버 : 0 = 파, 1 = 빨, 2 = 노, 3 = 초, 4 = 보, 5 = 맛이 간 색, 6 = 알고보니 착했던 색 
    public static int day;
    public static int maxPeopleNum;
    public static int nowPeopleNum;
    public static int[] queuePeopleNum;

    public Animator fade;
    public GameObject fadePannel;

    public GameObject xRay;
    public Image xRayTableMainImage;
    public Sprite[] xRayTableImages;

    public GameObject vital;
    public Text[] vitalText;

    public GameObject IDCard;
    public Animator IDCardAnimator;
    public Image[] IDCardMainImage;
    public Sprite[] IDCardSD;
    public Sprite[] IDCardImage;
    public Text IDCardText;

    public Sprite[] directiveSprites;
    public Image directivePaper;
    public Text directiveText;

    public Text[] sns;

    public GameObject bloodTest;
    public Text[] bloodTestText;
    
    public GameObject[] Spawner;
    public GameObject[] Character = new GameObject[5];

    private void Start()
    {
        fade.SetBool("IsRunning", true);
        Destroy(fadePannel, 1);
        if(day == 0)
        {
            PlayerPrefs.SetInt("PassedAbnormalHuman", 0);
            PlayerPrefs.SetInt("Day", 0);
            newDay();
        }
        else
        {
            day--;
            newDay();
        }
    }

    public void newDay()
    {
        //다음 날
        PlayerPrefs.SetInt("Day", PlayerPrefs.GetInt("PassedAbnormalHuman") + 1);
        day = PlayerPrefs.GetInt("Day");

        //사람 수 세팅
        nowPeopleNum = 0;
        maxPeopleNum = day * 10 + 30;

        //비정상자 뽑기
        SelectAbnormalPeople();

        //장비 세팅
        EquipmenSetting();

        //지령서, sns내용 세팅
        SetDirective_SNSTexts();

        //플레이어 세팅
        SetPlayer();
    }

    //비정상자 뽑기
    private void SelectAbnormalPeople()
    {
        int abnormalNum;
        queuePeopleNum = new int[maxPeopleNum];
        for (int i = 0; i < maxPeopleNum / (10 * day); i++)
        {
            abnormalNum = Random.Range(1, maxPeopleNum);
            if (queuePeopleNum[abnormalNum] != 0) i--;
            else
            {
                if (day <= 4)
                    queuePeopleNum[abnormalNum] = Random.Range(1, day);
                else
                    queuePeopleNum[abnormalNum] = 5;
            }
        }
        if(day >= 5)
        {
            for (int i = 0; i < 2 * day; i++)
            {
                abnormalNum = Random.Range(1, maxPeopleNum);
                if (queuePeopleNum[abnormalNum] != 0) i--;
                else
                {
                    queuePeopleNum[abnormalNum] = 6;
                }
            }
        }
    }

    //장비 세팅
    private void EquipmenSetting()
    {
        if (day == 1 || day == 2)
        {
            vital.SetActive(true);
        }
        else if (day == 3)
        {
            vital.SetActive(true);
            xRay.SetActive(true);
        }        
        else if (day == 4)
        {
            vital.SetActive(true);
            xRay.SetActive(true);
            bloodTest.SetActive(true);
        }
        else if (day >= 5)
        {
            vital.SetActive(true);
            xRay.SetActive(true);
            bloodTest.SetActive(true);
            IDCard.SetActive(true);
        }
    }

    //지령서, sns내용 세팅
    private void SetDirective_SNSTexts()
    {
        directivePaper.sprite = directiveSprites[day - 1];
        if (day == 1)
        {
            directiveText.text = "안녕하신가, 검문관. 총리일세\n요즘 세상이 어수선한 건 알고 있을거야. 빨간색의 바이러스가 퍼졌다는 얘기가 인터넷을 가득 채웠어.\n파랑색만 보던 사람들이 갑작스레 빨간색을 보게 되니 놀라는 것은 당연하지. 나도 적잖이 당황했네.\n미디어를 확인해보니, 그들의 증상은 체온과 맥박 수가 비정상적으로 높다고 하네.\n오늘부터 바이탈체크를 통해 체온이 37.5도 이상이거나 맥박수가 120 이상일 때 병원으로 이송시키게.\n패드로 SNS를 확인할 수 있네. 미디어로부터 많은 정보를 얻을 수 있을거야.\n감염자를 볼 수 있는 검문소의 가림막을 통해 통과 여부를 알려 줄 수 있다네.\n국민을 위하여 힘 써주시게";
            sns[0].text = "";
            sns[1].text = "";
            sns[2].text = "";
        }
        else if (day == 2)
        {
            directiveText.text = "안녕하신가, 검문관. 총리일세\n새로운 일은 적응이 되어가나? 적응이 안됐다면 안타깝군.\n노란색의 바이러스도 퍼진 모양이야. 증상에 대한 자세한 설명은 미디어를 확인하면 알 수 있네.\n오늘부터는 혈압과 호흡 수 까지 확인해야 하네.혈압이 150 이상이거나 호흡 수가 40 이상일 때 병원으로 이송시키게.\n현재로서는 이게 최선일세, 의료진이 치료법을 내지 못하는 이상, 자네가 우리의 목숨을 책임지는 걸세.\n나라를 위하여 힘 써주시게";
            sns[0].text = "";
            sns[1].text = "";
            sns[2].text = "";
        }
        else if (day == 3)
        {
            directiveText.text = "안녕하신가, 검문관. 총리일세\n안좋은 소식만 전하게 되는군. 이러다가 세상이 망하지는 않을까 싶네.\n오늘 새벽, 노란색의 감염자가 도시에 들어오려다가 잡혔네. 발견 당시에 가슴 통증을 앓고 있더군.\n최대한 단속시켰지만 기자들이 이미 퍼트려버렸네.아침부터 떠들썩해.\n오늘 발견된 감염자는 폐에 이상이 있을 것으로 의료진들이 예상하더군.\n오늘부터 검문소 상단에 배치된 엑스레이를 사용해 폐에 이상있는 감염자는 병원으로 이송시켜주게.\n정말 어쩌다가 이렇게 됐는지, 파란색인 우리만 피해를 보는군.\n우리를 위하여 힘 써주시게";
            sns[0].text = "";
            sns[1].text = "";
            sns[2].text = "";
        }
        else if (day == 4)
        {
            directiveText.text = " 안녕하신가, 검문관. 총리일세\n무능한 의료진이 한 건 해냈네.초록색의 감염자에 대해 들어본 적 있나?\n 2일 전에 가족 전체가 초록색인 가정을 발견하고, 그들의 대한 검사를 한 결과, 채혈을 통해 정밀 검사를 할 수 있다는 걸 알게됐네.\n오늘부터는 혈액검사로도 확인할 수 있게 됐네.\nHBC수치 20000이상, RBC수치 300만 이하, HB수치 20 이상일 때 병원으로 이송 시켜주게.\n귀찮겠지만, 초록색 감염자를 볼 때는 항상 확인해야하네.\n파란색을 위하여 힘 써주시게.";
            sns[0].text = "";
            sns[1].text = "";
            sns[2].text = "";
        }
        else if (day == 5)
        {
            directiveText.text = "안녕하신가, 검문관. 총리일세\n오늘 올라온 기사를 읽어보았나? 충격적인 내용이 담겨 있으니 꼭 읽어봐야 할걸세.\n오늘부터는 주민등록증을 검사해, 감염 이전에 흑인이었던 이들의 출입을 제한해주게.\n기사에 따르면 그들은 모두 위험한 감염자로 변했거나, 그럴 가능성이 높다고 하더군.\n백인을 위하여 힘 써주시게";
            sns[0].text = "";
            sns[1].text = "";
            sns[2].text = "";
        }
        else if (day == 6)
        {
            directiveText.text = "안녕하신가, 검문관. 총리일세\n혹시 검문관, B구역에 거주하고 있지는 않겠지? 점점 바이러스의 대란이 끝나가는 것 같네.\nB구역에서부터 바이러스가 퍼져나갔다는 기사를 접했어.지금 B구역 출신의 감염자들은 모두 이상증세가 있을 것이라고 전문가들이 얘기하고 있네.\n오늘부터는 주민등록증에서 B구역 출신인 감염자들을 병원으로 이송하게.\n그들은 이상증세가 있을 테니 말이야.\nA구역을 위하여 힘 써주시게";
            sns[0].text = "";
            sns[1].text = "";
            sns[2].text = "";
        }
        else if (day == 7)
        {
            directiveText.text = "검문관, 부탁이 있네. 나 총리일세\n내 딸이 빨간색 감염자가 됐네. 그리고 아직 도시를 들어오지 못했어.\n아직 딸은 주민등록증을 발급받지 못해 신원파악을 할 수도 없네.\n그래서 말인데, 오늘만 빨간색 감염자를 모두 받아주는 건 어떤가? 성공하고 싶지 않나?\n나를 위하여 힘 써주시게";
            sns[0].text = "";
            sns[1].text = "";
            sns[2].text = "";
        }
        else if (day == 8)
        {
            directiveText.text = "안녕하십니까, 검문관님. 국가소속 의료진입니다.\n당신이 꼭 알아야 하는 사실이 있습니다.\n오늘 최대한 빠르게 찾아뵙겠습니다.\n";
            sns[0].text = "";
            sns[1].text = "";
            sns[2].text = "";
        }
    }

    //플레이어 세팅
    private void SetPlayer()
    {
        Spawner = new GameObject[maxPeopleNum];
        for (int i = 0; i < maxPeopleNum; i++)
        {
            GameObject abnormalHuman = Instantiate(Character[queuePeopleNum[i]], Spawner[i].transform.position, Spawner[i].transform.rotation);
        }
    }
        
    //캐릭터 구현
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (day == 1 || day == 2)
        {
            VitalCheck(queuePeopleNum[nowPeopleNum]);
        }
        else if (day == 3)
        {
            VitalCheck(queuePeopleNum[nowPeopleNum]);
            XRayCheck(queuePeopleNum[nowPeopleNum]);
        }
        else if (day == 4)
        {
            VitalCheck(queuePeopleNum[nowPeopleNum]);
            XRayCheck(queuePeopleNum[nowPeopleNum]);
            BloodTestCheck(queuePeopleNum[nowPeopleNum]);
        }
        else if (day >= 5)
        {
            int randomDiseaseNum = Random.Range(1, 7);
            if (randomDiseaseNum == 1) VitalCheck(queuePeopleNum[nowPeopleNum]);
            else if (randomDiseaseNum == 2) XRayCheck(queuePeopleNum[nowPeopleNum]);
            else if (randomDiseaseNum == 3) BloodTestCheck(queuePeopleNum[nowPeopleNum]);
            else if (randomDiseaseNum == 4)
            {
                VitalCheck(queuePeopleNum[nowPeopleNum]);
                XRayCheck(queuePeopleNum[nowPeopleNum]);
            }
            else if (randomDiseaseNum == 5)
            {
                XRayCheck(queuePeopleNum[nowPeopleNum]);
                BloodTestCheck(queuePeopleNum[nowPeopleNum]);
            }
            else if (randomDiseaseNum == 6)
            {
                VitalCheck(queuePeopleNum[nowPeopleNum]);
                BloodTestCheck(queuePeopleNum[nowPeopleNum]);
            }
            else if (randomDiseaseNum == 7)
            {
                VitalCheck(queuePeopleNum[nowPeopleNum]);
                BloodTestCheck(queuePeopleNum[nowPeopleNum]);
                XRayCheck(queuePeopleNum[nowPeopleNum]);
            }
        }
        nowPeopleNum++;
    }

    //바이탈 체크
    private void VitalCheck(int colorNum)
    {
        float[] vitalText = new float[4];

        if (colorNum == 1 || colorNum == 5)
        {
            vitalText[0] = Random.Range(375, 390) * 0.1f;
            vitalText[1] = Random.Range(1200, 1400) * 0.1f;
            vitalText[2] = Random.Range(700, 1300) * 0.1f;
            vitalText[3] = Random.Range(120, 300) * 0.1f;
        }
        else if (colorNum == 2)
        {
            vitalText[0] = Random.Range(360, 370) * 0.1f;
            vitalText[1] = Random.Range(600, 1100) * 0.1f;
            vitalText[2] = Random.Range(1500, 1800) * 0.1f;
            vitalText[3] = Random.Range(400, 500) * 0.1f;
        }
        else
        {
            vitalText[0] = Random.Range(360, 370) * 0.1f;
            vitalText[1] = Random.Range(600, 1100) * 0.1f;
            vitalText[2] = Random.Range(700, 1300) * 0.1f;
            vitalText[3] = Random.Range(120, 300) * 0.1f;
        }
        for(int i = 0; i < 4; i++) this.vitalText[i].text = vitalText[i].ToString();       
    }

    //엑스레이 체크
    private void XRayCheck(int colorNum)
    {
         if(colorNum == 2 || colorNum == 5) xRayTableMainImage.sprite = xRayTableImages[1];
         else xRayTableMainImage.sprite = xRayTableImages[0];
    }

    //체혈 검사
    private void BloodTestCheck(int colorNum)
    {
        float[] bloodTestText = new float[4];
        if (colorNum == 3 || colorNum == 5)
        {
            bloodTestText[0] = Random.Range(20, 27) * 0.1f;
            bloodTestText[1] = Random.Range(2000, 3000) * 0.1f;
            bloodTestText[2] = Random.Range(200, 250) * 0.1f;
        }
        else
        {
            bloodTestText[0] = Random.Range(4, 11) * 0.1f;
            bloodTestText[1] = Random.Range(3900, 5500) * 0.1f;
            bloodTestText[2] = Random.Range(130, 170) * 0.1f;
        }
        this.bloodTestText[0].text = bloodTestText[0].ToString() + "만"; 
        this.bloodTestText[1].text = bloodTestText[1].ToString() + "만"; 
        this.bloodTestText[2].text = bloodTestText[2].ToString(); 
    }

    //신분증 검사
    private void IDCardCheck()
    {
        IDCardAnimator.SetBool("GetIDCard", true);
        IDCardAnimator.SetBool("TakeBackIDCard", false);

        int IDCardKind = Random.Range(0,2);
        int live = Random.Range(0, 2);
        IDCardMainImage[0].sprite = IDCardSD[IDCardKind];

        IDCardMainImage[1].sprite = IDCardSD[IDCardKind];

        if(live == 0) IDCardText.text = "A";
        else if(live == 1) IDCardText.text = "B";
        else if(live == 2) IDCardText.text = "C";
    }
}
