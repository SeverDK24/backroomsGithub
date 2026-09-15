using UnityEngine;
using UnityEngine.UI;

public class TextWriting : MonoBehaviour
{
    Text text1;
    Text text2;

    GameObject buton;

    GameObject buton2;
    Image buttonImage2;
    Text buttonText2;

    GameObject photo;
    Image photoImage;

    string text1Full;
    string text2Full;

    Image buttonImage;
    Text buttonText;

    int letter = 0;
    float timer = 0;
    float wait = 0;

    bool second = false;

    void Start()
    {
        text1 = GameObject.FindGameObjectWithTag("Text1").GetComponent<Text>();
        text2 = GameObject.FindGameObjectWithTag("Text2").GetComponent<Text>();

        buton = GameObject.FindGameObjectWithTag("Buton");
        buton2 = GameObject.FindGameObjectWithTag("Buton2");

        photo = GameObject.FindGameObjectWithTag("Photo");
        photoImage = photo.GetComponent<Image>();

        buttonImage2 = buton2.GetComponent<Image>();
        buttonText2 = buton2.GetComponentInChildren<Text>();

        buttonImage = buton.GetComponent<Image>();
        buttonText = buton.GetComponentInChildren<Text>();

        text1Full = text1.text;
        text2Full = text2.text;

        text1.text = "";
        text2.text = "";

        Color color = buttonImage.color;
        color.a = 0;
        buttonImage.color = color;

        Color color2 = buttonImage2.color;
        color2.a = 0;
        buttonImage2.color = color2;

        Color textColor2 = buttonText2.color;
        textColor2.a = 0;
        buttonText2.color = textColor2;

        Color textColor = buttonText.color;
        textColor.a = 0;
        buttonText.color = textColor;

        Color photoColor = photoImage.color;
        photoColor.a = 0;
        photoImage.color = photoColor;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.09f)
        {
            timer = 0;

            if (!second)
            {
                if (letter < text1Full.Length)
                {
                    text1.text += text1Full[letter];
                    letter++;
                }
                else
                {
                    wait += 0.05f;

                    if (wait >= 0.05)
                    {
                        second = true;
                        letter = 0;

                        buton.SetActive(true);
                    }
                }
            }
            else
            {
                if (letter < text2Full.Length)
                {
                    text2.text += text2Full[letter];
                    letter++;
                }
            }
        }

        // Плавное появление кнопки
        if (second)
        {
            Color color = buttonImage.color;

            if (color.a < 1)
            {
                color.a += Time.deltaTime;
                buttonImage.color = color;
            }

            // Плавное появление текста внутри кнопки
            Color textColor = buttonText.color;

            if (textColor.a < 1)
            {
                textColor.a += Time.deltaTime;
                buttonText.color = textColor;
            }

            Color photoColor = photoImage.color;

            if (photoColor.a < 1)
            {
                photoColor.a += Time.deltaTime;
                photoImage.color = photoColor;
            }

            Color color2 = buttonImage2.color;

            if (color2.a < 1)
            {
                color2.a += Time.deltaTime;
                buttonImage2.color = color2;
            }

            Color textColor2 = buttonText2.color;

            if (textColor2.a < 1)
            {
                textColor2.a += Time.deltaTime;
                buttonText2.color = textColor2;
            }
        }

    }
}
