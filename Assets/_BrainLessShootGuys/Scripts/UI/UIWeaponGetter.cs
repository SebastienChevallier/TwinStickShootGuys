using UnityEngine;

public class UIWeaponGetter : MonoBehaviour
{
    public PlayerMovement player;
    private Weapon weapon;

    public void UpdateWeaponUI()
    {
        weapon = player._weapon;
    }
}
