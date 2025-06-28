using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<ExitItem> exitItems = new List<ExitItem>();
    public List<GameObject> lockedWall = new List<GameObject>();

    // 탈출 아이템을 모든 활성화 했을 때 CanExit를 활성화 시킨다.
    public bool CanExit = false;
    public TextMeshProUGUI getItemList; // 소유한 아이템의 이름을 출력하는 UI
    public TextMeshProUGUI openDoor;    // openDoor.text = "모든 문이 열렸습니다.";
    private void Start()
    {
        Instance = this;
    }

    // 획득할 수 있는 아이템에서, 획득한 아이템을 UI에 출력하는 코드
    public void UpdateItem()
    {
        getItemList.text = "획득한 아이템 리스트: ";

        for(int i=0; i < exitItems.Count; i++)
        {
            if (exitItems[i].isActivate == true)
            {
                getItemList.text += exitItems[i].ItemName;
                getItemList.text += " , ";
            }
        }
    }

    // 모든 키의 활성화가 true이면 CanExit를 true로 변경한다.
    public bool GetAllKey()
    {
        for (int i = 0; i < exitItems.Count; i++)
        {
            if(exitItems[i].isActivate == false)
            {
                return false;
            }           
        }
        return true;
    }

    public void GetKey()
    {
        UpdateItem();
        CanExit = GetAllKey();

        if(CanExit)  // 잠긴 문을 열어주세요.
        {
            foreach(GameObject g in lockedWall)
               g.SetActive(false);
       

            openDoor.text = "모든 문이 열렸습니다.";
        }
    }
}
