using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Store a comment within the Unity inspector about a GameObject
public class Comment : MonoBehaviour
{
    [Tooltip("The comment string (usually a description of this GameObject's function)")]
    [TextAreaAttribute(1, 3)]
    public string comment;
}