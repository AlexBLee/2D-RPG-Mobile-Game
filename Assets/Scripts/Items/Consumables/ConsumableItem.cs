﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : Item
{    
    // for the potion list to tell if already in a button
    [HideInInspector] public bool marked = false;
    
    public virtual void ConsumeEffect(CharacterEntity character) {}
}
