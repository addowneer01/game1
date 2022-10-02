using UnityEngine;

public class colisia : MonoBehaviour
{
    public bool JmpC;
    public Main Main;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "money")
        {
            Main.money += 1;
            PlayerPrefs.SetInt("money", Main.money);
            PlayerPrefs.Save();
        }

        if (collision.gameObject.tag == "Respawn")
        {
            Main.res();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            JmpC = true;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        JmpC = false;
    }
}