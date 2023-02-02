namespace Movement.Conditions
{
    public interface ICondition
    {
        public bool CanMove(State state);
    }
}