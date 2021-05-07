using UnityEngine;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{

    public Text liveText;


    void Update()
    {
        liveText.text = PlayerInfo.Lives.ToString() + " DENEME";
    }
}
