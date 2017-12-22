using ModuleTracking;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularityWithMef.Desktop
{   
    [Export(typeof(IModuleTracker))]
    public class ModuleTracker
    {
        private readonly ModuleTrackingState moduleATrackingState;

        public ModuleTracker()
        {
            // These states are defined specifically for the desktop version of the quickstart.
            this.moduleATrackingState = new ModuleTrackingState
            {
                ModuleName = WellKnownModuleNames.ModuleA,
                ExpectedDiscoveryMethod = DiscoveryMethod.ApplicationReference,
                ExpectedInitializationMode = InitializationMode.WhenAvailable,
                ExpectedDownloadTiming = DownloadTiming.WithApplication,
                ConfiguredDependencies = WellKnownModuleNames.ModuleD,
            };
        }

        public ModuleTrackingState ModuleATrackingState
        {
            get { return this.moduleATrackingState; }
        }
    }
}
