using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprints standartTurret;
    public TurretBlueprints missleLauncher;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTurret()
    {
        Debug.Log("Standart Turret");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectMissleLauncher()
    {
        Debug.Log("Missile Launcher");
        buildManager.SelectTurretToBuild(missleLauncher);
    }
}
