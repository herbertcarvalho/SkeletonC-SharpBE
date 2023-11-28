namespace Backend.Erp.Skeleton.Application.Extensions
{
    public interface IThrow
    {
    }

    public class Throw : IThrow
    {
        public static IThrow Exception { get; } = new Throw();

        private Throw()
        {
        }
    }
}
