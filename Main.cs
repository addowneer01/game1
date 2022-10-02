using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Rigidbody player;
    public colisia colis;
    public GameObject panelMenu;
    public GameObject panelRes;
    public GameObject panelPause;
    public Text score;
    public Text scoreMoney;
    public Text scoreRes;
    public Text scoreRecordText;
    public GameObject[] ground;
    public GameObject ground0;
    public GameObject pointSpawnPlayer;
    public GameObject ButR;
    public GameObject ButL;
    public GameObject ButJ;
    public GameObject ButP;

    public int scoreInt;
    public bool gameMode;
    int numberGr = 1, scoreRecord;
    public int money;
    public GameObject[] grounds;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        colis = GameObject.FindGameObjectWithTag("Player").GetComponent<colisia>();
        score.text = "";
        scoreRecordText.text = "";
        scoreMoney.text = "";
        gameMode = false;
        panelMenu.SetActive(true);
        panelRes.SetActive(false);
        panelPause.SetActive(false);
        scoreRecord = PlayerPrefs.GetInt("Record");
        money = PlayerPrefs.GetInt("money");
        ButR.SetActive(false);
        ButL.SetActive(false);
        ButJ.SetActive(false);
        ButP.SetActive(false);
    }

    void Update() 
    {
        if (gameMode == true && player.transform.position.y >= 0) { 
            scoreInt  = System.Convert.ToInt32((Mathf.Round(player.transform.position.z)-5)/10);
            score.text = scoreInt.ToString();
            scoreMoney.text = money.ToString();
            if (scoreRecord < scoreInt) { scoreRecord = scoreInt; }
            scoreRecordText.text = System.Convert.ToString(scoreRecord);
        }
        
    }
    private void FixedUpdate()
    {
        if (Mathf.Round(player.transform.position.z) / 250 == numberGr)
        {
            Transform position = ground0.transform;
            position.transform.position = new Vector3(0,0,375+250*numberGr);
            Instantiate(ground[0], position.transform);
            ground0.transform.DetachChildren();
            numberGr += 1;
        }
    }
    public void res()
    {
        gameMode = false;
        panelRes.SetActive(true);
        ButR.SetActive(false);
        ButL.SetActive(false);
        ButJ.SetActive(false);
        ButP.SetActive(false);
        Cursor.visible = true;
        score.text = "";
        scoreRecordText.text = "";
        scoreMoney.text = "";
        scoreRes.text = "—чет: " + scoreInt;
        Time.timeScale = 0;
        if (scoreInt == scoreRecord)
        {
            scoreRecord = scoreInt;
            PlayerPrefs.SetInt("Record", scoreRecord);
            PlayerPrefs.Save();
        }
    }
    public void ButPlay()
    {
        grounds = GameObject.FindGameObjectsWithTag("ground");
        for (int i = 0;i < grounds.Length; i++)
        {
            grounds[i].GetComponent<levelSpawn>().refresh();
        }
        player.transform.position = pointSpawnPlayer.transform.position;
        player.AddForce(0, 0, -player.velocity.z, ForceMode.VelocityChange);
        player.AddForce(0, -player.velocity.y, 0, ForceMode.VelocityChange);
        player.AddForce(-player.velocity.x, 0, 0, ForceMode.VelocityChange);
        Time.timeScale = 1;
        panelMenu.SetActive(false);
        panelRes.SetActive(false);
        panelPause.SetActive(false);
        gameMode = true;
        ButR.SetActive(true);
        ButL.SetActive(true);
        ButJ.SetActive(true);
        ButP.SetActive(true);
    }
    public void ButMenu()
    {
        score.text = "";
        scoreRecordText.text = "";
        scoreMoney.text = "";
        panelRes.SetActive(false);
        panelMenu.SetActive(true);
        panelPause.SetActive(false);
    }
    public void ButPause()
    {
        ButR.SetActive(false);
        ButL.SetActive(false);
        ButJ.SetActive(false);
        ButP.SetActive(false);
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }
    public void ButResume()
    {
        ButR.SetActive(true);
        ButL.SetActive(true);
        ButJ.SetActive(true);
        ButP.SetActive(true);
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}