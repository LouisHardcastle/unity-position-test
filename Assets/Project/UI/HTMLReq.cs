using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HTMLReq 
{
    public string result; 
  public IEnumerator SendRequest(string Url)
    {
        UnityWebRequest request = UnityWebRequest.Get(Url);
      
        yield return request.SendWebRequest();
        result = request.downloadHandler.text;
        Debug.Log(result);
       
    }
}
