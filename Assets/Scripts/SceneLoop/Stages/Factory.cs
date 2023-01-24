using UnityEngine;

namespace SceneLoop.Stages
{
    public class Factory
    {
        public IStage Create(StageType type)
        {
            switch (type)
            {
                case StageType.Preparation:
                    return new Preparation();
                case StageType.Game:
                    return new Game();
                case StageType.Termination:
                    return new Termination();
                default:
                    Debug.LogError($"Can't create IStage for type {type}");
                    return null;
            }
        }
    }
}