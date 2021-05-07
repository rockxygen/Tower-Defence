using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Builder var!");
            return;
        }
        instance = this;
    }

    public GameObject standartTurretPF;
    public GameObject missleLauncherPF;

    public GameObject buildEffect;

    private TurretBlueprints turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerInfo.Money >= turretToBuild.cost; } }


    public void SelectTurretToBuild(TurretBlueprints turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(NodeController node)
    {

        if(PlayerInfo.Money < turretToBuild.cost)
        {
            Debug.Log("Paran yetmiyor!");
            return;
        }

        PlayerInfo.Money -= turretToBuild.cost;

        // Create Turret
        GameObject turretCreate = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turretCreate;

        // Create Effect
        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        Debug.Log("Kalan para : " + PlayerInfo.Money);
    }
}
