﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DddInPractice.Logic.Common
{
    public static class DomainEvents
    {
        private static List<Type> _handlers;

        public static void Dispatch(IDomainEvent domainEvent)
        {
            foreach (var handlerType in _handlers)
            {
                var canHandleEvent =
                    handlerType
                        .GetInterfaces()
                        .Any(
                            x => x.IsGenericType
                                 && x.GetGenericTypeDefinition() == typeof(IHandler<>)
                                 && x.GenericTypeArguments[0] == domainEvent.GetType());

                if (canHandleEvent)
                {
                    dynamic handler = Activator.CreateInstance(handlerType);
                    handler.Handle((dynamic) domainEvent);
                }
            }
        }

        public static void Init()
        {
            _handlers =
                Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Where(
                        x => x.GetInterfaces().Any(
                            y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IHandler<>)))
                    .ToList();
        }
    }
}