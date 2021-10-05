using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHP : MonoBehaviour
{
    public int maxHP;

    [SerializeField] int currentHP;


    private void Start()
    {
        currentHP = maxHP;
    }
    public int GetHP()
    {
        return currentHP <= 0 ? 0 : currentHP;
    }

    // Reduce
    public void SetHP(int amount)
    {
        if ((currentHP - Mathf.Abs(amount)) < 0)
        {
            currentHP = 0;
        }

        currentHP -= Mathf.Abs(amount);
    }
}
