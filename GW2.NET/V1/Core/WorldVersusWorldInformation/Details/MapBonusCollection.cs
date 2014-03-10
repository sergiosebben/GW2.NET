﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapBonusCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of World versus World map bonuses.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Details
{
    using System.Collections.Generic;

    /// <summary>
    ///     Represents a collection of World versus World map bonuses.
    /// </summary>
    public class MapBonusCollection : JsonList<MapBonus>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MapBonusCollection" /> class.
        /// </summary>
        public MapBonusCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapBonusCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public MapBonusCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapBonusCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public MapBonusCollection(IEnumerable<MapBonus> collection)
            : base(collection)
        {
        }
    }
}