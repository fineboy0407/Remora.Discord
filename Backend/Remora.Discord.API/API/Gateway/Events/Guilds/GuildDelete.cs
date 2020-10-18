//
//  GuildDelete.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2017 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using JetBrains.Annotations;
using Remora.Discord.API.Abstractions.Gateway.Events;
using Remora.Discord.API.Objects;
using Remora.Discord.Core;

namespace Remora.Discord.API.Gateway.Events
{
    /// <inheritdoc cref="IGuildDelete"/>
    [PublicAPI]
    public class GuildDelete : UnavailableGuild, IGuildDelete
    {
        /// <inheritdoc cref="UnavailableGuild" />
        public GuildDelete(Snowflake guildID, Optional<bool> isUnavailable)
            : base(guildID, isUnavailable)
        {
        }
    }
}
