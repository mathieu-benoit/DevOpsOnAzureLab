namespace MainWebApplication.Services
{
    public class AdditionService : IAdditionService
    {
        public int Add(int x, int y)
        {
            return y + y;
        }
    }
}
