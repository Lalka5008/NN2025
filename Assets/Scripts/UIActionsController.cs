using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIActionsController : MonoBehaviour
{
    public Jump jump;
    public Dash dash;
    public RocketLauncher launcher;
    public Button JumpButton;
    public Button DashButton;
    public Button RocketLaunchButton;
    public float JumpForce;
    public float DashSpeed;


    void Start()
    {
        
    }
    public void LaunchButton()
    {
        launcher.InitiateLauch();
        RocketLaunchButton.interactable = false;
    }
    public void ButtonJump()
    {
        jump.InitiateJump(JumpForce);
        StartCoroutine(Cooldown(5, JumpButton));
    }
    public void ButtonDash()
    {
        dash.InitiateDash(DashSpeed);
        StartCoroutine(Cooldown(5, DashButton));  

    }
    // Update is called once per frame
    void Update()
    {
    }
    
    IEnumerator Cooldown(int seconds, Button button)
    {
        Debug.Log("Кд...");
        button.interactable = false;
        yield return new WaitForSeconds(seconds);
        button.interactable = true;
        Debug.Log("Готово");
    }
}
