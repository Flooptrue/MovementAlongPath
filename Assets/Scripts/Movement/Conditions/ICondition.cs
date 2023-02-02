namespace Movement.Conditions
{
    public interface ICondition
    {
        public void CanMove(State state);
    }
}