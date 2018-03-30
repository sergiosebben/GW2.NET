﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRarityConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="ItemRarity" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Converters
{
    using System;
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="string" /> to objects of type <see cref="ItemRarity" />.</summary>
    public sealed class ItemRarityConverter : IConverter<string, ItemRarity>
    {
        /// <summary>Converts the given object of type <see cref="string" /> to an object of type <see cref="ItemRarity" />.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public ItemRarity Convert(string value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            ItemRarity result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            Debug.Assert(false, "Unknown ItemRarity: " + value);
            return default(ItemRarity);
        }
    }
}