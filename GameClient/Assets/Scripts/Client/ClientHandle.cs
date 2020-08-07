using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"接收服务器消息{_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();

        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Debug.Log($"Spawn id:{_id}");
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.instance.SpawnPlayer(_id,_username,_position,_rotation);
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Debug.Log($"PlayerPosition id:{_id}");
        var _position = _packet.ReadVector3();

        if (GameManager.players.ContainsKey(_id))//防止id有了，物体还没有spawn
            GameManager.players[_id].transform.position = _position;
        
    }

    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Debug.Log($"PlayerRotation id:{_id}");
        var _rotation = _packet.ReadQuaternion();

        if (GameManager.players.ContainsKey(_id))//防止id有了，物体还没有spawn
            GameManager.players[_id].transform.rotation = _rotation;
        
    }
}
