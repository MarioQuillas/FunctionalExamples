﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NullReferencesDemo.Common
{
    public class ServiceLocator<TKey, TService>
    {
        private IList<Tuple<Func<TKey, bool>, Func<TKey, TService>>> Mappings { get; } =
            new List<Tuple<Func<TKey, bool>, Func<TKey, TService>>>();

        public TService LocateServiceFor(TKey key)
        {
            return Mappings.Where(mapping => mapping.Item1(key)).Select(mapping => mapping.Item2).First()(key);
        }

        public void RegisterService(Func<TKey, bool> selector, Func<TKey, TService> serviceFactory)
        {
            Mappings.Add(Tuple.Create(selector, serviceFactory));
        }
    }
}