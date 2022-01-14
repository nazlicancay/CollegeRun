using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    public bool GameStarted = false;
    public bool GameEnded;
    public List<GameObject> GoodCollactables = new List<GameObject>();
    public List<GameObject> BadCollactables = new List<GameObject>();
    [SerializeField] private bool once = true;
    [SerializeField] private TextMeshProUGUI Starttext;
     public TextMeshProUGUI FailText;
     public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && once)
        {
            GameStarted = true;
            once = false;
            Starttext.gameObject.SetActive(false);
            anim.SetTrigger(Animator.StringToHash("walkTrigger"));
            Debug.Log(anim.GetBool("walk"));
        }
    }

    public void ColorCollactables(Color color)
    {
        for (int i = 0; i < GoodCollactables.Count; i++)
        {
           MeshRenderer col = GoodCollactables[i].GetComponent<MeshRenderer>();
           col.material.color = color;
        }
    }
}
