﻿// <copyright file="IWorldRepository.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Worlds
{
    using GW2NET.Common;

    /// <summary>Provides the interface for repositories that provide localized world details.</summary>
    public interface IWorldRepository : IRepository<int, World>, ILocalizable
    {
    }
}