using System.Collections.Generic;
using SceneLoop.Stages;
using UnityEngine;

namespace SceneLoop
{
    [CreateAssetMenu(fileName = "SceneSettings", menuName = "Road/SceneSettings", order = 0)]
    public class Settings : ScriptableObject
    {
        [field: SerializeField]
        public List<StageType> StagesOrder { get; private set; }
        [field: SerializeField]
        public bool ShowLogs { get; private set; }
    }
}