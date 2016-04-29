using System;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;
using Microsoft.SharePoint.Navigation;



namespace DemoSEO.Features.Props
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("d547e8bc-1f1c-4660-b1f4-de73361ffcac")]
    public class PropsEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = (SPSite) properties.Feature.Parent;

            using (SPWeb web= site.RootWeb)
            {
                SPListItem welcomePage = web.GetListItem(web.RootFolder.WelcomePage);
                welcomePage["SeoBrowserTitle"] = Resources.SeoBrowserTitle;
                welcomePage["SeoMetaDescription"]= Resources.SeoDescription;
                welcomePage["SeoKeywords"] = Resources.SeoKeywords;
                welcomePage["SeoRobotsNoIndex"] =false.ToString();
                welcomePage.SystemUpdate();

                TaxonomySession taxSession= new TaxonomySession(site, updateCache:true);

                TermStore termStore = taxSession.DefaultSiteCollectionTermStore;

                Group termGroup = termStore.GetSiteCollectionGroup(site, true);

                foreach (TermSet termSet in termGroup.TermSets)
                {
                    NavigationTermSet navigationTermSet= 
                }

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
