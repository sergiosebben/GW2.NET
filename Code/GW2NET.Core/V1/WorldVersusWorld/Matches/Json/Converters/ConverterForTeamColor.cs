﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForTeamColor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="TeamColor" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Matches.Json.Converters
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="TeamColor"/>.</summary>
    internal sealed class ConverterForTeamColor : IConverter<string, TeamColor>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="TeamColor"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public TeamColor Convert(string value)
        {
            Contract.Requires(value != null);
            TeamColor teamColor;
            if (!Enum.TryParse(value, true, out teamColor))
            {
                return TeamColor.Unknown;
            }

            return teamColor;
        }
    }
}