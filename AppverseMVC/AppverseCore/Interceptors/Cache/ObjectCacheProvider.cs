﻿/*
 Copyright (c) 2014 GFT Appverse, S.L., Sociedad Unipersonal.

 This Source Code Form is subject to the terms of the Appverse Public License
 Version 2.0 (“APL v2.0”). If a copy of the APL was not distributed with this
 file, You can obtain one at http://www.appverse.mobi/licenses/apl_v2.0.pdf. [^]

 Redistribution and use in source and binary forms, with or without modification,
 are permitted provided that the conditions of the AppVerse Public License v2.0
 are met.

 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 DISCLAIMED. EXCEPT IN CASE OF WILLFUL MISCONDUCT OR GROSS NEGLIGENCE, IN NO EVENT
 SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
 INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
 PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT(INCLUDING NEGLIGENCE OR OTHERWISE)
 ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 POSSIBILITY OF SUCH DAMAGE.
 */

using Appverse.Core.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace Appverse.Core.Interceptors.Cache
{
    /// <summary>
    /// Simple cache provider class
    /// </summary>
    public class ObjectCacheProvider : ICacheProvider
    {
        ObjectCache _cache = MemoryCache.Default;

        /// <summary>
        /// Gets the specified cache item using the key.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <returns>
        /// The object cached with the specified key.
        /// </returns>
        public object Get(string cacheKey)
        {
            return _cache.Get(cacheKey);
        }

        /// <summary>
        /// Inserts the specified item into the cache.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="item">The item to cache.</param>
        /// <param name="cacheExpiry">The cache expiry timeout.</param>
        public void Insert(string cacheKey, object item, TimeSpan cacheExpiry)
        {
            CacheItemPolicy itemPolicy = new CacheItemPolicy();
            itemPolicy.AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(cacheExpiry.TotalSeconds);
            _cache.Add(cacheKey, item, itemPolicy);
        }
    }
}
