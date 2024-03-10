using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEmoji : MonoBehaviour
{
    [SerializeField]private Sprite[] _emojies;
    private Image _this;
    void Start()
    {
        _this = GetComponent<Image>();
        int rnd = Random.Range(0, _emojies.Length);
        _this.sprite = _emojies[rnd];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
