using UnityEngine;
using UnityEngine.SceneManagement;

public class GodModeMenu : MonoBehaviour
{
    public bool godModeOn;
    public GameObject godModeMenu;
    public Player player;
    public GameObject dialogueTriggers;
    [SerializeField] private AudioSource menuButtonsSounds;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    private void Start()
    {
        dialogueTriggers = GameObject.FindGameObjectWithTag("DialogueTriggers");
        godModeOn = false;
        godModeMenu.SetActive(false);
    }

    public void ShowGodModeMenu()
    {
        if (!godModeOn)
        {
            godModeMenu.SetActive(!godModeMenu.activeSelf);
            
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
        }
    }
    
    public void Continue()
    {
        ShowGodModeMenu();
        menuButtonsSounds.Play();
    }
    
    public void Increase()
    {
        menuButtonsSounds.Play();
        player.GetComponent<Player>().playerSpeed = 20f;
        player.GetComponent<Player>().abilityToDash = true;
        player.GetComponent<Player>().abilityToSprint = true;
        //player.GetComponent<Player>().jumpForce = 6f;
        player.GetComponent<Player>().whatIsGrounded = LayerMask.NameToLayer("UI");
    }
    
    public void Decrease()
    {
        menuButtonsSounds.Play();
        player.GetComponent<Player>().playerSpeed = 5f;
        //player.GetComponent<Player>().jumpForce = 4f;
        player.GetComponent<Player>().whatIsGrounded = LayerMask.GetMask("Ground");
    }

    public void RemoveDialogues()
    {
        menuButtonsSounds.Play();
        Destroy(dialogueTriggers);
    }

    public void RestartLevel()
    {
        menuButtonsSounds.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}