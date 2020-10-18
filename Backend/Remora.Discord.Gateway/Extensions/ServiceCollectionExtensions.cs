//
//  ServiceCollectionExtensions.cs
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

using System;
using System.Linq;
using System.Net.WebSockets;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Remora.Discord.Gateway.Responders;
using Remora.Discord.Gateway.Transport;
using Remora.Discord.Rest.Extensions;

namespace Remora.Discord.Gateway.Extensions
{
    /// <summary>
    /// Defines extension methods for the <see cref="IServiceCollection"/> class.
    /// </summary>
    [PublicAPI]
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services required by the Discord Gateway system.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="token">A function that retrieves the bot token.</param>
        /// <returns>The service collection, with the services added.</returns>
        public static IServiceCollection AddDiscordGateway
        (
            this IServiceCollection serviceCollection,
            Func<string> token
        )
        {
            serviceCollection
                .AddDiscordRest(token)
                .AddSingleton<Random>()
                .AddTransient<ClientWebSocket>()
                .AddSingleton<IPayloadTransportService, WebSocketPayloadTransportService>()
                .AddSingleton<DiscordGatewayClient>();

            return serviceCollection;
        }

        /// <summary>
        /// Adds a responder to the service collection. This method registers the responder as being available for all
        /// <see cref="IResponder{T}"/> implementations it supports.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <typeparam name="TResponder">The concrete responder type.</typeparam>
        /// <returns>The service collection, with the responder added.</returns>
        public static IServiceCollection AddResponder<TResponder>
        (
            this IServiceCollection serviceCollection
        )
            where TResponder : IResponder
        {
            var responderTypeInterfaces = typeof(TResponder).GetInterfaces();
            var responderInterfaces = responderTypeInterfaces.Where
            (
                r => r.IsGenericType && r.GetGenericTypeDefinition() == typeof(IResponder<>)
            );

            foreach (var responderInterface in responderInterfaces)
            {
                serviceCollection.AddScoped(responderInterface, typeof(TResponder));
            }

            return serviceCollection;
        }
    }
}
