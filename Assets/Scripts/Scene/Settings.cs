using System.Collections.Generic;
using Scene.Stages;
using UnityEngine;

namespace Scene
{
    [CreateAssetMenu(fileName = "SceneSettings", menuName = "Road/SceneSettings", order = 0)]
    public class Settings : ScriptableObject
    {
        [field: SerializeField]
        public List<StageType> StagesOrder;
    }
}