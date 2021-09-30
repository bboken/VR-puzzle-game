using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicbar : MonoBehaviour
{
    enum Mtype {bgm, Eff};

    public Transform local;
    public Transform startpoint;
    public Transform endpoint;
    public Transform actOj;
    [SerializeField]
    Mtype _type = Mtype.bgm;

    private float s2eDist;
    private float s2aDist;
    public SongManager _sys;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = local.position;
    }

    // Update is called once per frame
    void Update()
    {
        s2eDist = Vector3.Distance(startpoint.position,endpoint.position);
        s2aDist = Vector3.Distance(startpoint.position, actOj.position);
        //Debug.Log(s2aDist / s2eDist);
        if(_type == Mtype.bgm)
        {
            _sys.ChangebgmV(s2aDist / s2eDist);
        }
        if(_type == Mtype.Eff)
        {
            _sys.ChangeEffV(s2aDist / s2eDist);
        }
        
    }
}
