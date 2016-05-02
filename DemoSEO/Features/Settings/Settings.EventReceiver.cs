using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using Microsoft.SharePoint;

namespace DemoSEO.Features.Settings
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("b4efe1ba-8767-488f-8f65-705e605031e3")]
    public class SettingsEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = (SPSite)properties.Feature.Parent;
            using (SPWeb web = site.RootWeb)
            {
                //activar sitemap generation feature and configure robot exclusion

                Guid featureId = new Guid("77FC9E13-E99A-4BD3-9438-A3F69670ED97");

                if (site.Features[featureId] == null)
                {
                    site.Features.Add(featureId);
                }

                StringBuilder robots = new StringBuilder();

                robots.AppendLine("User-agent: *");
                robots.AppendLine("Disallow: /_layouts/");
                robots.AppendLine("Disallow: /vti_bin/");
                robots.AppendLine("Disallow: /_catalogs/");
                robots.AppendLine("Disallow: /legal/");
                web.SetProperty("xmlsitemaprobotstxtpropertyname", robots.ToString());

                string newCustomMeta = "<meta name=\'msvalidate.01\' content=\'0123456789ABCDEF0123456789ABCDEF\'/>";
                web.SetProperty("seoincludecustommetatagpropertyname ", true.ToString());
                web.SetProperty("seocustommetatagpropertyname", newCustomMeta);

                web.SetProperty("seoenablecanonicallinkparameterspropertyname", true.ToString());
                web.SetProperty("seocanonicallinkparameterlistpropertyname", "category");
                
                web.Update();
                

            }

        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
