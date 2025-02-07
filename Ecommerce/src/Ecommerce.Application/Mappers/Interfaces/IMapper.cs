namespace Ecommerce.Application.Mappers.Interfaces
{
    public interface IMapper<in TSource, TDestination>
    {
        TDestination Map(TSource source);

        IEnumerable<TDestination> Map(IEnumerable<TSource> source);
    }
}