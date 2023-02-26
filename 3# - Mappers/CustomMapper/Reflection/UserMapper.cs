namespace Mappers.CustomMapper.Reflection;

public class Mapper<TSource, TDestination>
{
    public TDestination Map(TSource source)
    {
        var destination = Activator.CreateInstance<TDestination>();

        foreach (var sourceProperty in typeof(TSource).GetProperties())
        {
            var destinationProperty = typeof(TDestination).GetProperty(sourceProperty.Name);

            if (destinationProperty != null)
            {
                destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }

        return destination;
    }

    public List<TDestination> Map(List<TSource> sourceList)
    {
        return sourceList.Select(source => Map(source)).ToList();
    }
}