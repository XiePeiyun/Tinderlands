using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;
using Random = UnityEngine.Random;

public class EndUI : MonoBehaviour
{
    public OutButton outButton;
    public StayButton stayButton;
    public BurnButton burnButton;
    public static EndUI instance { get; private set; }

}
