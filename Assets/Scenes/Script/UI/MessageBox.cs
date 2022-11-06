using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    private StringBuilder builder = new StringBuilder();
    private Text messageBox;   

    private bool isShoot;
    private bool isRicochet;
    private bool isMovement;
    private bool isLateralMovement;
    private bool isRotation;
    private int messageCount = 0;

    void Start()
    {
        GlobalEventManager.PlayerShoot.AddListener(IsPlayerShoot);
        GlobalEventManager.Ricochet.AddListener(IsRicochet);
        messageBox = GetComponent<Text>();
    }

    private void Update()
    {
        isMovement = Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0;
        isLateralMovement = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        isRotation = Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0;

        if (isShoot)
        {
            isShoot = false;

            if (isMovement)
                builder.Append("Перемещение+");
            else if (isLateralMovement)
                builder.Append("Боковое движение+");

            if (isRotation)
                builder.Append("Вращение+");

            if(builder.Length>0)
            {
                builder.Append("Выстрел");
                WriteText(builder.ToString());
                builder.Clear();
            }       
        }

        if (isRicochet)
        {
            WriteText("Рикошет!");
            isRicochet = false;
        }
    }

    private void WriteText(string text)
    {
        ClearMessageBox();
        messageBox.text += $"{text}\n";
        messageCount++;
    }

    private void ClearMessageBox()
    {
        if (messageCount >= 5)
        {
            messageCount = 0;
            messageBox.text = "";
        }
    }

    private void IsRicochet()
    {
        isRicochet = true;
    }

    private void IsPlayerShoot()
    {
        isShoot = true;
    }
}
