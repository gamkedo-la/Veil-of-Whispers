using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject>weaponLogic = new List<GameObject>();

    public void EnablePunchR()
    {
        weaponLogic[3].SetActive(true);
    }

    public void EnablePunchL()
    {
        weaponLogic[2].SetActive(true);
    }

    public void EnableKickR()
    {
        weaponLogic[1].SetActive(true);
    }

    public void EnableKickL()
    {
        weaponLogic[0].SetActive(true);
    }

    public void EnableEnemyWeapon()
    {
        weaponLogic[0].SetActive(true);
    }

    public void DisableEnemyWeapon()
    {
        weaponLogic[0].SetActive(true);
    }
    public void DisablePunchR()
    {
        weaponLogic[3].SetActive(false);
    }

    public void DisablePunchL()
    {
        weaponLogic[2].SetActive(false);
    }

    public void DisableKickR()
    {
        weaponLogic[1].SetActive(false);
    }

    public void DisableKickL()
    {
        weaponLogic[0].SetActive(false);
    }
}
