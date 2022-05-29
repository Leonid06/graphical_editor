using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;



namespace graphical_editor
{
    
   
    public partial class App : Application
    {
        private string SYNC_FUSION_LICENCSE_KEY = "NjQzNDU0QDMyMzAyZTMxMmUzMEhBNHBrWXhubzA5R2FRdGZtYmd0d2JvdjdnV2lRUDF5TGtQem9nT0pUeTA9";
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SYNC_FUSION_LICENCSE_KEY);
        }
    }
}
