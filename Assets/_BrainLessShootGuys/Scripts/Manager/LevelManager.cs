using BaseTemplate.Behaviours;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    public List<WeaponVisual> weaponVisuals;
    public List<WeaponType> weaponTypes;
    public List<WeaponVisual> weaponVisualsCac;
    public List<ActifSpell> actifSpells;
    [Space(10)]
    public List<Weapon> weaponInMap = new();
    public List<WeaponSpawner> weaponSpawners;
    //public List<WeaponSpawner> allweaponSpawner;
    public int numberOfWeapon;
    public Weapon WeaponTrunk;
    public void Start()
    {
        //Remplacer le 5 par le nombre de spawner
        for (int i = 0; i < numberOfWeapon; i++)
        {
            Weapon weapon = Instantiate(WeaponTrunk);

            WeaponType weaponType = Instantiate(weaponTypes[Random.Range(0, weaponTypes.Count)]);
            weaponType.DefineStats();

            WeaponVisual weaponVisual;
            if (weaponType.isCac)
                weaponVisual = Instantiate(weaponVisualsCac[Random.Range(0, weaponVisualsCac.Count)], weapon.weaponVisualParent);
            else
                weaponVisual = Instantiate(weaponVisuals[Random.Range(0, weaponVisuals.Count)], weapon.weaponVisualParent);
                
                //weaponVisual.transform.rotation = Quaternion.identity;
            //ActifSpell actifSpell = Instantiate(actifSpells[Random.Range(0, actifSpells.Count)]);

            weapon.weaponVisual = weaponVisual;
            weapon.weaponType = weaponType;

            
            weapon.Init();
            //weapon.actifSpell = actifSpell;
            
            weaponInMap.Add(weapon);
            weapon.gameObject.SetActive(false);
        }

        foreach(WeaponSpawner spawner in weaponSpawners)
        {
            spawner.Init();
        }
    }
}
