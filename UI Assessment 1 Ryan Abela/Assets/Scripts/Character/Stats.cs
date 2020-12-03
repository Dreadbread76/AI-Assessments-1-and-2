using System;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : Life
{
    #region Structs
    [Serializable]
    public struct StatBlock
    {
        public string name;
        public Text nameDisplay;
        public int value;
        public int tempValue;
        public GameObject plusButton;
        public GameObject minusButton;
    }
    #endregion
    #region Variables
    public StatBlock[] charStats = new StatBlock[6];
    #endregion
}

