using UnityEngine;
using Unity.Netcode.Components;

public class NewMonoBehaviourScript : NetworkTransform
{
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }
}
