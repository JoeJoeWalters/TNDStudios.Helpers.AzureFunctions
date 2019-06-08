using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNDStudios.Helpers.AzureFunctions.Testing.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Get the shortened system type string from a given type
        /// </summary>
        /// <param name="typeOf">The system type</param>
        /// <returns>The shortened string version for use for comparison</returns>
        public static String ShortName(this Type typeOf)
            => (((Boolean)typeOf?.Name?.Contains('.')) ?
                    typeOf?.Name?.Split('.').Reverse().First() : 
                    (typeOf?.Name ?? String.Empty))
                .ToLower().Trim();
                
    }
}
