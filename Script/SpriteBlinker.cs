using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpriteBlinker : MonoBehaviour
{
 
    [SerializeField]
    float time;
    private Image img;

    IEnumerator Blink()
    {
        float alpha = img.color.a;

        while (true)
        {
            alpha *= (-1);
            img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
            yield return new WaitForSeconds(time);

			/*
			if (Input.anyKey) {
				alpha = 1;

				//まとめれそう
				img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
				yield return new WaitForSeconds(1);
			}
			*/
        }
    }

    // Use this for initialization
    void Start()
    {
        img = GetComponent<Image>();
        StartCoroutine("Blink");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
