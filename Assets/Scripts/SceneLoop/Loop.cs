using System.Collections.Generic;
using SceneLoop.Stages;
using UnityEngine;

namespace SceneLoop
{
    public class Loop : MonoBehaviour
    {
        [SerializeField] private Settings _settings;

        private Dictionary<StageType, IStage> _stages;

        private void Awake()
        {
            _stages = new Dictionary<StageType, IStage>();

            CreateStages();
        }

        private void CreateStages()
        {
            var factory = new Factory();

            foreach (var stageType in _settings.StagesOrder)
            {
                var stage = factory.Create(stageType);
                _stages.Add(stageType, stage);
            }
        }
    }
}