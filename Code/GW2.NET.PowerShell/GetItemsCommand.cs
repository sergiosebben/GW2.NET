﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetItemsCommand.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the Get-Item command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.PS.Commands
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Net;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Items;

    /// <summary>Represents the Get-Item command.</summary>
    [Cmdlet(VerbsCommon.Get, "Items")]
    public class GetItemsCommand : ServiceCmdlet
    {
        /// <summary>The service.</summary>
        private IItemService service;

        /// <summary>Gets or sets the culture.</summary>
        [Parameter(Position = 1)]
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the identifier.</summary>
        [Parameter(Position = 0)]
        public int[] Id { get; set; }

        /// <summary>Provides a one-time, preprocessing functionality for the cmdlet.</summary>
        /// <param name="serviceClient">A service client.</param>
        protected override void BeginProcessing(IServiceClient serviceClient)
        {
            this.service = new ItemService(serviceClient);
        }

        /// <summary>Provides a record-by-record processing functionality for the cmdlet.</summary>
        protected override void ProcessRecord()
        {
            var ids = this.Id;
            if (ids == null)
            {
                this.WriteItemsDiscovered();
            }
            else
            {
                this.WriteItemDetails(ids);
            }
        }

        /// <summary>Writes a collection of item details for the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        private void WriteItemDetails(IList<int> identifiers)
        {
            var culture = this.Culture ?? CultureInfo.GetCultureInfo("en");
            var progressRecord = new ProgressRecord(0, "Retrieving item details.", string.Format("Item 1 of {0}", identifiers.Count)) { RecordType = ProgressRecordType.Processing };
            for (int i = 0; i < identifiers.Count; i++)
            {
                var id = identifiers[i];
                progressRecord.CurrentOperation = string.Format("/v1/item_details.json?lang={1}&item_id={0}", id, culture.TwoLetterISOLanguageName);
                progressRecord.StatusDescription = string.Format("Item {0} of {1}", i + 1, identifiers.Count);
                progressRecord.PercentComplete = (int)(((double)i / (double)identifiers.Count) * 100D);
                this.WriteProgress(progressRecord);
                try
                {
                    this.WriteObject(this.service.GetItemDetails(id, culture));
                }
                catch (ServiceException serviceException)
                {
                    this.WriteError(new ErrorRecord(serviceException, "ItemNotFound", ErrorCategory.ObjectNotFound, id));
                }
                catch (WebException webException)
                {
                    this.ThrowTerminatingError(new ErrorRecord(webException, "ConnectionError", ErrorCategory.ConnectionError, id));
                }
            }
            progressRecord.RecordType = ProgressRecordType.Completed;
            this.WriteProgress(progressRecord);
        }

        /// <summary>Writes a collection of identifiers of discovered items.</summary>
        private void WriteItemsDiscovered()
        {
            this.WriteObject(this.service.GetItems());
        }
    }
}