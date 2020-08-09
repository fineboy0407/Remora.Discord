//
//  SampleObjectDataSource.cs
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

using System.Diagnostics;
using Xunit;

namespace Remora.Discord.API.Tests.Services
{
    /// <summary>
    /// Represents a source of sample data for an xUnit test.
    /// </summary>
    /// <typeparam name="TData">The data type.</typeparam>
    public class SampleObjectDataSource<TData> : TheoryData<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleObjectDataSource{TData}"/> class.
        /// </summary>
        public SampleObjectDataSource()
        {
            var sampleData = new SampleDataService();

            var getSamples = sampleData.GetSampleObjectDataSet<TData>();
            if (!getSamples.IsSuccess)
            {
                throw new SkipException();
            }

            foreach (var sample in getSamples.Entity)
            {
                Add(sample);
            }
        }
    }
}
