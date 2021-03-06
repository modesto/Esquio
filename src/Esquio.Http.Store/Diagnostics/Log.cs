﻿using Microsoft.Extensions.Logging;
using System;

namespace Esquio.Http.Store.Diagnostics
{
    static class Log
    {
        public static void FindFeature(ILogger logger, string featureName, string productName, string deploymentName)
        {
            _findFeature(logger, featureName, productName, deploymentName, null);
        }

        public static void FindFeatureFromCache(ILogger logger, string cacheEntry)
        {
            _findFeatureFromCache(logger, cacheEntry, null);
        }

        public static void FeatureIsOnCache(ILogger logger, string cacheEntry)
        {
            _featureIsOnCache(logger, cacheEntry, null);
        }

        public static void FindFeatureFromStore(ILogger logger, string featureName, string productName, string deploymentName)
        {
            _findFeatureFromStore(logger, featureName, productName, deploymentName, null);
        }

        public static void FeatureNotExist(ILogger logger, string featureName, string productName, string deploymentName)
        {
            _featureNotExist(logger, featureName, productName, deploymentName, null);
        }

        public static void FeatureIsNotOnCache(ILogger logger, string cacheEntry)
        {
            _featureIsNotOnCache(logger, cacheEntry, null);
        }

        public static void StoreRequestFailed(ILogger logger, string request, int statusCode)
        {
            _storeRequestFailed(logger, request, statusCode, null);
        }

        public static void DistributedCacheIsNotConfigured(ILogger logger)
        {
            _distributedStoreIsNotConfigured(logger, null);
        }

        private static readonly Action<ILogger, string, string, string, Exception> _findFeature = LoggerMessage.Define<string, string, string>(
            LogLevel.Information,
            EventIds.FindFeature,
            "Http store trying to find feature with name {featureName} for product {productName}({deploymentName}).");

        private static readonly Action<ILogger, string, Exception> _findFeatureFromCache = LoggerMessage.Define<string>(
           LogLevel.Information,
           EventIds.FindFeatureFromCache,
           "Finding feature from configured cache using entry {cacheEntry}.");

        private static readonly Action<ILogger, string, Exception> _featureIsOnCache = LoggerMessage.Define<string>(
           LogLevel.Debug,
           EventIds.FeatureIsOnCache,
           "Feature with cache key {cacheEntry} exist on cache and is used.");

        private static readonly Action<ILogger, string, Exception> _featureIsNotOnCache = LoggerMessage.Define<string>(
           LogLevel.Debug,
           EventIds.FeatureIsNotOnCache,
           "Feature with cache key {cacheEntry} does not exist on cache");

        private static readonly Action<ILogger, string, string, string, Exception> _findFeatureFromStore = LoggerMessage.Define<string, string, string>(
          LogLevel.Information,
          EventIds.FindFeatureFromStore,
          "Finding feature from store with name {featureName} for product {productName}({deploymentName}).");

        private static readonly Action<ILogger, string, string, string, Exception> _featureNotExist = LoggerMessage.Define<string, string, string>(
            LogLevel.Warning,
            EventIds.FeatureNotExist,
            "Feature with name {featureName} for product {productName}({deploymentName}) does not exist on the store.");

        private static readonly Action<ILogger, string, int, Exception> _storeRequestFailed = LoggerMessage.Define<string, int>(
          LogLevel.Error,
          EventIds.StoreRequestFailed,
          "Request GET to Http store {request} throw with status code {statusCode}.");

        private static readonly Action<ILogger, Exception> _distributedStoreIsNotConfigured = LoggerMessage.Define(
          LogLevel.Error,
          EventIds.DistributedCacheIsNotRegistered,
          "Store is configured to use cache (CacheEnabled is true) but the service IDistributedCache is not registered.");

    }
}
