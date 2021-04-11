using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flip.GameMechanics
{
    public abstract class BaseReversibleObject : MonoBehaviour, IReversible
    {
        public abstract void Reverse();
    }
}

