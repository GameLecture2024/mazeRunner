using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitItem : MonoBehaviour
{
    public string ItemName;
    public bool isActivate;
    // �浹�� �ϱ� ���ؼ� �ۼ��� �̺�Ʈ �ڵ�

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) // �÷��̾ �� �����۰� �浹�� �� �ִ�.
        {
            //Destroy(gameObject);       // ExitItem ������Ʈ ������ �ִ� �������� ����?         
            gameObject.SetActive(false);
            isActivate = true;
            GameManager.Instance.GetKey();
        }
    }
}
