using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDarkAttackPrefab : MonoBehaviour
{
    [SerializeField] private GameObject darkAttackPrefab;
    public void instantiateDarkAttack()
    {
        GameObject attack = Instantiate(darkAttackPrefab);
    }
}
