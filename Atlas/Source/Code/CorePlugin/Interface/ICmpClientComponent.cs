using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Atlas.Interface
{
    public interface ICmpClientComponent
    {
        void OnRemoteActivate();

        void OnRemoteDeactivate();

        void Update(object newValue);
    }
}
