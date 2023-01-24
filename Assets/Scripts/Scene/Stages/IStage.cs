namespace Scene.Stages
{
    public interface IStage
    {
        bool IsComplete { get; }

        void Start();
        void Finish();
    }
}