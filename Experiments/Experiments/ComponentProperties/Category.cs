﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Experiments.ComponentProperties
{
    public class Category
        : INameValueProperty
    {
        public string Name => "CATEGORIES";

        /// <summary>
        /// A Category's Value is always null because Categories are where the notional values go.
        /// </summary>
        public string Value => null;

        public IReadOnlyList<string> Categories { get; }
        public IReadOnlyList<string> Properties { get; }

        /// <summary>
        /// Category constructor. Categories that are null or whitespace will be filtered out.
        /// </summary>
        /// <param name="comparerOverride">Default StringComparer is OrdinalIgnoreCase. This comparer has no effect on how the additional properties are
        /// de-duplicated or ordered.</param>
        public Category(IEnumerable<string> categories, StringComparer comparerOverride, IEnumerable<string> additionalProperties = null)
        {
            Categories = SerializationUtilities.GetNormalizedStringCollection(categories, comparerOverride);
            Properties = SerializationUtilities.GetNormalizedStringCollection(additionalProperties);
        }

        public Category(IEnumerable<string> categories)
            : this(categories, StringComparer.OrdinalIgnoreCase) { }

        public override string ToString()
        {
            if (Categories == null)
            {
                return "";
            }

            var builder = new StringBuilder();
            builder.Append($"{Name}:");
            builder.Append(string.Join(",", Categories));
            builder.Append("\r\n");
            return builder.ToString();
        }
    }
}