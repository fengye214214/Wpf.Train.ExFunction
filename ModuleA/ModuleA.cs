using Prism.Modularity;
using Prism.Mef.Modularity;
using System;
using ModuleTracking;
using Prism.Logging;
using System.ComponentModel.Composition;

namespace ModularityWithMef.Desktop
{
    [ModuleExport(typeof(ModuleA), InitializationMode = InitializationMode.WhenAvailable)]
    public class ModuleA : IModule
    {
        private readonly ILoggerFacade logger;
        private readonly IModuleTracker moduleTracker;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleA"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="moduleTracker">The module tracker.</param>
        [ImportingConstructor]
        public ModuleA(ILoggerFacade logger, IModuleTracker moduleTracker)
        {
            this.logger = logger ?? throw new ArgumentNullException("logger");
            this.moduleTracker = moduleTracker ?? throw new ArgumentNullException("moduleTracker");
            this.moduleTracker.RecordModuleConstructed(WellKnownModuleNames.ModuleA);
        }

        public void Initialize()
        {   
            this.logger.Log("ModuleA demonstrates logging during Initialize().", Category.Info, Priority.Medium);
            this.moduleTracker.RecordModuleInitialized(WellKnownModuleNames.ModuleA);
        }
    }
}
