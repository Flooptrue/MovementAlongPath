using System.Collections;
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
            StartCoroutine(GetRunR(_settings.StagesOrder, _stages));
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

        private IEnumerator GetRunR(List<StageType> stagesOrder, IReadOnlyDictionary<StageType, IStage> stages)
        {
            foreach (var stageType in stagesOrder)
            {
                var currentStage = stages[stageType];
                currentStage.Start();

                while (currentStage.IsComplete == false)
                {
                    yield return null;
                }

                currentStage.Finish();
            }
        }
    }
}