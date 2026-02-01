using UnityEngine;
using UnityEngine.UI;

public class ElementsUI : MonoBehaviour
{
    public Slider sldHealth;
    public Image imgMask1;
    public Image imgMask2;

    void Start()
    {
        this.sldHealth.value = 100;
        SetAlpha(this.imgMask1,1.0f);
        SetAlpha(this.imgMask2,0.1f);
    }

    public float GetHealth() {
        return this.sldHealth.value;
    }
    
    public void SetAlpha(Image img, float alpha)
    {
        Color tempColor = img.color;
        tempColor.a = alpha;
        img.color = tempColor;
    }

    public bool imgMask1On()
    {
        return this.imgMask1.color.a == 1.0f;
    }

    public bool imgMask2On()
    {
        return this.imgMask2.color.a == 1.0f;
    }

    public void changeMasks() {
        if (imgMask1On()) {
            SetAlpha(this.imgMask1,0.1f);
            SetAlpha(this.imgMask2,1.0f);
        } else {
            SetAlpha(this.imgMask1,1.0f);
            SetAlpha(this.imgMask2,0.1f);
        }
    }

    public void changeHealth(float health) {
        this.sldHealth.value += health;
    }
}
