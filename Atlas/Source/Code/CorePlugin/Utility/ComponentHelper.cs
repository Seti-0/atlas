using Duality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Utility
{
    public static class ComponentHelper
    {
        public static void AddRequirements<T>(GameObject obj)
            where T : Component
        {
            var requirments = Component.RequireMap
                .GetRequirementsToCreate(obj, typeof(T));

            foreach (var requirement in requirments)
                obj.AddComponent(requirement);
        }
    }
}
