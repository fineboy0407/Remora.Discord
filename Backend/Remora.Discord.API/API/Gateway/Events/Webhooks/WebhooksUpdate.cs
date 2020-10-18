//
//  WebhooksUpdate.cs
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
using Remora.Discord.Core;

namespace Remora.Discord.API.Gateway.Events
{
    /// <inheritdoc />
    [PublicAPI]
    public class WebhooksUpdate : IWebhooksUpdate
    {
        /// <inheritdoc/>
        public Snowflake GuildID { get; }

        /// <inheritdoc/>
        public Snowflake ChannelID { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebhooksUpdate"/> class.
        /// </summary>
        /// <param name="guildID">The ID of the guild.</param>
        /// <param name="channelID">The ID of the channel.</param>
        public WebhooksUpdate(Snowflake guildID, Snowflake channelID)
        {
            this.GuildID = guildID;
            this.ChannelID = channelID;
        }
    }
}
