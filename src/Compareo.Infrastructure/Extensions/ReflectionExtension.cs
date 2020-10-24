namespace Compareo.Infrastructure.Extensions
{
    public static class ReflectionExtension
    {
        public static string GetPropertyValue<T>(this T item, string propertyName)
                => item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();
    }
}
