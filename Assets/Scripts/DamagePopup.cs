using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    void Update()
    {
        textMesh.transform.position += new Vector3(0, 80f) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {
            // Start dissapearing
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0)
            {
                // Completely invisible
                Destroy(gameObject);
            }
        }
    }

    //---------------------------------------------------------------------------------------------

    public void Setup(int damage, Vector3 position)
    {
        textMesh = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
        textMesh.SetText(damage.ToString());

        // Position above boss or player
        if(position.x > 0) // Player
        {
            textMesh.transform.position = new Vector3(position.x * 100f, textMesh.transform.position.y, textMesh.transform.position.z);
        }
        else // Boss
        {
            textMesh.transform.position = new Vector3(position.x * -10f, textMesh.transform.position.y, textMesh.transform.position.z);
        }
        textColor = textMesh.color;
        disappearTimer = 1f;
    }

    //---------------------------------------------------------------------------------------------

    public static DamagePopup Create(Vector3 position, int amount)
    {
        Transform dpopup = Instantiate(Definitions.Instance.damagePopupPrefab, position, Quaternion.identity);

        DamagePopup damagePopup = dpopup.GetComponent<DamagePopup>();
        damagePopup.Setup(amount, position);

        return damagePopup;
    }

    // Data ///////////////////////////////////////////////////////////////////////////////////////
    TextMeshProUGUI textMesh;
    public static Transform damagePopupPrefab;
    private float disappearTimer;
    private Color textColor;
}
