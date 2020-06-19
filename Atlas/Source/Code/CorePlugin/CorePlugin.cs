using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duality;
using Duality.Resources;

namespace Soulstone.Duality.Plugins.Atlas
{
	public class AtlasPlugin : CorePlugin
	{
        protected override void InitPlugin()
        {
            AtlasApp.Init();
        }

        protected override void OnBeforeUpdate()
        {
            AtlasApp.Update();
        }

        protected override void OnDisposePlugin()
        {
            AtlasApp.Shutdown();
        }
    }
}
