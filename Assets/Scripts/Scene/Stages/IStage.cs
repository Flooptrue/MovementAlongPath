namespace Scene.Stages
{
    public interface IStage
    {
        void Start();
        void Finish();
        bool IsComplete();
    }
}