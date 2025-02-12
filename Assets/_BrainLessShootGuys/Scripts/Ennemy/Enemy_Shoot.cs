using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Shoot : AEnnemy
{
    public List<Weapon> weaponsCanUse;

    public Weapon weaponEquip;

    public override void Start()
    {
        base.Start();
        weaponEquip = Instantiate(weaponsCanUse[Random.Range(0, weaponsCanUse.Count)]);
        weaponEquip.weaponType = Instantiate(weaponEquip.weaponType);
        weaponEquip.transform.SetParent(_weaponAnchor);
        weaponEquip.transform.localPosition = Vector3.zero;
        weaponEquip.transform.localRotation = Quaternion.identity;
        weaponEquip.transform.localScale = Vector3.one;
        weaponEquip.entityUse = this;
        weaponEquip.Init();
    }
    public override void Attaque()
    {
        transform.LookAt(_player.transform);
        weaponEquip.Shoot();
    }

    public override void Chase()
    {

    }
}
