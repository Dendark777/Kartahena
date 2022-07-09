using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ServerManager : MonoBehaviour
{
    private string _serverPort;
    private string _maxConnection;
    private string _password;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetServerPort(string value)
    {
        _serverPort = value;
    }
    public void SetMaxConnection(string value)
    {
        _maxConnection = value;
    }
    public void SetPassword(string value)
    {
        _password = value;
    }


}
