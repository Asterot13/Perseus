using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTransit : MonoBehaviour
{

    public List<InfoDetails> charactersToScene = new List<InfoDetails>();
    
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
