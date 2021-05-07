using UnityEngine;
using UnityEngine.EventSystems;

public class NodeController : MonoBehaviour
{
    private Renderer render;

    private Color startColor;
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    [Header("Optional")]
    public GameObject turret;

    public Vector3 positionOffset;

    BuildManager buildManager;

    void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset; 
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            render.material.color = hoverColor;
        }
        else
        {
            render.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        } 

        if (!buildManager.CanBuild)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Koyulmaz!");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseExit()
    {
        render.material.color = startColor;
    }

    //void Update()
    //{
        
    //}
}
