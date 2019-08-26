// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Global

using System;

namespace Saxxon.Xml
{
    internal static class Assert
    {
        public static void NotNull(object subject, string name)
        {
            if (subject == null)
                throw new ArgumentNullException(name);
        }

        public static void NotNullOrEmpty(string subject, string name)
        {
            NotNull(subject, name);

            if (subject == string.Empty)
                throw new ArgumentException("Argument cannot be empty", name);
        }
    }
}