using System.Collections.Generic;
using Scene.Stages;
using UnityEngine;

namespace Scene
{
    public class Loop : MonoBehaviour
    {
        [SerializeField] private Settings _settings;
        
        private List<IStage> _stages;
        private IStage       _currentStage;

        private void Awake()
        {
            _stages = new List<IStage>();

            CreateStages();
        }

        private void CreateStages()
        {
            var factory = new Factory();

            foreach (var stageType in _settings.StagesOrder)
            {
                var stage = factory.Create(stageType);
                _stages.Add(stage);
            }
        }
    }
}