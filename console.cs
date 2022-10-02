using UnityEngine;

public class console : MonoBehaviour
{
    public float speedRL;
    public float speedJ;
    public float speedF;
    public Rigidbody player;
    public Main Main;
    public colisia colis;
    bool spJ, spR, spL, spF;
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();
        Main = GameObject.Find("Main Camera").GetComponent<Main>();
        colis = gameObject.GetComponent<colisia>();
}

    void Update()
    {
        if (gameObject.transform.position.y <= 0)
        {
            Main.res();
        }
        if (Main.gameMode == true)
        {
            /*if (Input.GetKey("d")) spR = true; else spR = false;
            if (Input.GetKey("a")) spL = true; else spL = false;
            if (Input.GetKey("w")) spJ = true; else spJ = false;*/
            spF = true;
        }
        else
        {
            spF = false;
            spR = false;
            spL = false;
            spJ = false;
        }
    }
    private void FixedUpdate()
    {
        if (spF == true) { player.AddForce(0, 0,speedF - player.velocity.z, ForceMode.VelocityChange); }
        if (spR == true && player.velocity.x <= speedRL) { player.AddForce(speedRL * Time.deltaTime * 10, 0, 0, ForceMode.VelocityChange); }
        if (spL == true && player.velocity.x >= -speedRL) { player.AddForce(-speedRL * Time.deltaTime * 10, 0, 0, ForceMode.VelocityChange); }
        if (spJ == true && colis.JmpC == true) { player.AddForce(0, speedJ, 0, ForceMode.VelocityChange); }
        if (spR == spL) { player.AddForce(-(player.velocity.x/speedRL), 0, 0, ForceMode.VelocityChange); }
    }
    public void RD() { spR = true; }
    public void RU() { spR = false; }
    public void LD() { spL = true; }
    public void LU() { spL = false; }
    public void JD() { spJ = true; }
    public void JU() { spJ = false; }
}
