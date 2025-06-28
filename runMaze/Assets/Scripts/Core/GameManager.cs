using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<ExitItem> exitItems = new List<ExitItem>();
    public List<GameObject> lockedWall = new List<GameObject>();

    // Ż�� �������� ��� Ȱ��ȭ ���� �� CanExit�� Ȱ��ȭ ��Ų��.
    public bool CanExit = false;
    public TextMeshProUGUI getItemList; // ������ �������� �̸��� ����ϴ� UI
    public TextMeshProUGUI openDoor;    // openDoor.text = "��� ���� ���Ƚ��ϴ�.";
    private void Start()
    {
        Instance = this;
    }

    // ȹ���� �� �ִ� �����ۿ���, ȹ���� �������� UI�� ����ϴ� �ڵ�
    public void UpdateItem()
    {
        getItemList.text = "ȹ���� ������ ����Ʈ: ";

        for(int i=0; i < exitItems.Count; i++)
        {
            if (exitItems[i].isActivate == true)
            {
                getItemList.text += exitItems[i].ItemName;
                getItemList.text += " , ";
            }
        }
    }

    // ��� Ű�� Ȱ��ȭ�� true�̸� CanExit�� true�� �����Ѵ�.
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

        if(CanExit)  // ��� ���� �����ּ���.
        {
            foreach(GameObject g in lockedWall)
               g.SetActive(false);
       

            openDoor.text = "��� ���� ���Ƚ��ϴ�.";
        }
    }
}
