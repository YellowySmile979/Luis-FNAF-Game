using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAnimatronic : MonoBehaviour
{
    [Header("Animatronic Data")]
    public ScriptableAnimatronic animatronicData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void AnimatronicBehaviour()
    {

    }
}
