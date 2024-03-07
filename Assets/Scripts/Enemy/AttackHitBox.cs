using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    public EnemyStateManager enemy;
    public TMP_Text hpText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit");
            enemy.playerController.hitPoints--;
            hpText.text = $"HP: {enemy.playerController.hitPoints}";
        }
    }
}

