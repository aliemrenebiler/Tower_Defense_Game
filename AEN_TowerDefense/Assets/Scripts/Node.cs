using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color acceptHoverColor;
    public Color denyHoverColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    [Header("Others")]
    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    
    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        else if (buildManager.TurretExists && buildManager.HasMoney && turret == null)
        {
            buildManager.BuildTurretOn(this);
        }
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        else if (buildManager.TurretExists && turret == null)
        {
            if(buildManager.HasMoney)
            {
                rend.material.color = acceptHoverColor;
            }
            else
            {
                rend.material.color = denyHoverColor;
            }
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
