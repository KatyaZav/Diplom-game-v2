using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Animator _anim;

    public void Init()
    {
        PlayerController.AddedHp += AddHp;
        PlayerController.RemovedHp += RemoveHp;
    }

    private void OnDisable()
    {
        PlayerController.AddedHp -= AddHp;
        PlayerController.RemovedHp -= RemoveHp;        
    }

    void AddHp(int hp)
    {
        text.text = hp.ToString();
    }

    void RemoveHp(int hp)
    {
        text.text = hp.ToString();
        _anim.SetTrigger("destroy");
    }
}
