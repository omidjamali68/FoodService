using System.Reflection;

namespace Food.Application
{
    public class AssemblyReference
    {
        public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
    }
}
