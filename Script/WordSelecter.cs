using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WordSelecter : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    AudioSource pi;

    //ダメ
    const int nameLength = 4;
    //これダメ
    const int wordsWidth = 10;
    const int wordsHight = 6;

    [SerializeField]
    Toggle[] words;

    [SerializeField]
    Toggle[] myName;

    private int index;
    private int x;
    private int y;

    string GetSelectedWord()
    {
        string selectedWord = GetComponent<ToggleGroup>().ActiveToggles()
            .First().GetComponentsInChildren<Text>()
            .First(t => t.name == "Label").text;

        return selectedWord;
    }

    void CreateSelectedNameWindow()
    {
        GameObject window = Instantiate(obj);
        window.transform.SetParent(gameObject.transform.parent.gameObject.transform, false);

        string selectedName = "";
        for (int i = 0; i < myName.Length; i++)
        {
            if (myName[i].GetComponentInChildren<Text>().text == "*")
                myName[i].GetComponentInChildren<Text>().text = "";
            selectedName += myName[i].GetComponentInChildren<Text>().text;
        }

        selectedName += "ではじめます。";

        TextController.str = selectedName;

        UIManager.preb = UIManager.now;
        UIManager.now = window;
    }

    // Use this for initialization
    void Start()
    {
        pi = gameObject.GetComponent<AudioSource>();
        UIManager.now = this.gameObject;

        index = 0;
        x = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.now.name == this.name)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                x = (++x) % wordsWidth;
                if (words[x + y * wordsWidth].name == "NotWord")
                    ++x;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                x = (--x + wordsWidth) % wordsWidth;
                if (words[x + y * wordsWidth].name == "NotWord")
                    --x;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                y = (++y) % wordsHight;
                if (words[x + y * wordsWidth].name == "NotWord")
                    y = (++y) % wordsHight;//怪しい
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                y = (--y + wordsHight) % wordsHight;
                if (words[x + y * wordsWidth].name == "NotWord")
                    y = (--y + wordsHight) % wordsHight;//怪しい
            }
            else if (Input.GetKeyDown(KeyCode.Return) && index < nameLength)
            {
                pi.Play();
                string str = GetSelectedWord();

                //きつい
                if (str == "゜")
                {
                    if (index > 0)
                    {
                        Text prev = myName[index - 1].GetComponentInChildren<Text>();
                        if (prev.text == "は")
                            prev.text = "ぱ";
                        else if (prev.text == "ひ")
                            prev.text = "ぴ";
                        else if (prev.text == "ふ")
                            prev.text = "ぷ";
                        else if (prev.text == "へ")
                            prev.text = "ぺ";
                        else if (prev.text == "ほ")
                            prev.text = "ぽ";
                    }
                }
                else if (str == "゛")
                {
                    if (index > 0)
                    {
                        Text prev = myName[index - 1].GetComponentInChildren<Text>();

                        if (prev.text == "か")
                            prev.text = "が";
                        else if (prev.text == "き")
                            prev.text = "ぎ";
                        else if (prev.text == "く")
                            prev.text = "ぐ";
                        else if (prev.text == "け")
                            prev.text = "げ";
                        else if (prev.text == "こ")
                            prev.text = "ご";
                        else if (prev.text == "さ")
                            prev.text = "ざ";
                        else if (prev.text == "し")
                            prev.text = "じ";
                        else if (prev.text == "す")
                            prev.text = "ず";
                        else if (prev.text == "せ")
                            prev.text = "ぜ";
                        else if (prev.text == "そ")
                            prev.text = "ぞ";
                        else if (prev.text == "た")
                            prev.text = "だ";
                        else if (prev.text == "ち")
                            prev.text = "ぢ";
                        else if (prev.text == "つ")
                            prev.text = "づ";
                        else if (prev.text == "て")
                            prev.text = "で";
                        else if (prev.text == "と")
                            prev.text = "ど";
                        else if (prev.text == "は")
                            prev.text = "ば";
                        else if (prev.text == "ひ")
                            prev.text = "び";
                        else if (prev.text == "ふ")
                            prev.text = "ぶ";
                        else if (prev.text == "へ")
                            prev.text = "べ";
                        else if (prev.text == "ほ")
                            prev.text = "ぼ";
                    }
                }
                else if (str == "もどる")
                {
                    --index;
                    myName[index].GetComponentInChildren<Text>().text = "*";
                }
                else if (str == "おわり")
                {
                    CreateSelectedNameWindow();
                }
                else
                {
                    myName[index].GetComponentInChildren<Text>().text = str;
                    ++index;
                    if (index == nameLength)
                    {
                        --index;
                        CreateSelectedNameWindow();
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.B) && index > 0)
            {
                pi.Play();
                --index;
                myName[index].GetComponentInChildren<Text>().text = "*";
            }

            words[x + y * wordsWidth].isOn = true;
            myName[index].isOn = true;
            Debug.Log(words[x + y * wordsWidth].GetComponentInChildren<Text>().text);
        }
    }
}