//-----------------------------------------------------------------------
// <copyright file="DocumentSession.cs" company="Hibernating Rhinos LTD">
//     Copyright (c) Hibernating Rhinos LTD. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Raven.Client.Documents.Session.Loaders;

namespace Raven.Client.Documents.Session
{
    /// <summary>
    /// Implements Unit of Work for accessing the RavenDB server
    /// </summary>
    public partial class DocumentSession
    {
        /// <summary>
        /// Begin a load while including the specified path
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public ILoaderWithInclude<T> Include<T>(Expression<Func<T, string>> path)
        {
            return new MultiLoaderWithInclude<T>(this).Include(path);
        }

        /// <summary>
        /// Begin a load while including the specified path
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public ILoaderWithInclude<T> Include<T, TInclude>(Expression<Func<T, string>> path)
        {
            return new MultiLoaderWithInclude<T>(this).Include<TInclude>(path);
        }

        public ILoaderWithInclude<T> Include<T, TInclude>(Expression<Func<T, Guid>> path)
        {
            return new MultiLoaderWithInclude<T>(this).Include<TInclude>(path);
        }

        /// <summary>
        /// Begin a load while including the specified path
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public ILoaderWithInclude<T> Include<T>(Expression<Func<T, IEnumerable<string>>> path)
        {
            return new MultiLoaderWithInclude<T>(this).Include(path);
        }

        /// <summary>
        /// Begin a load while including the specified path
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public ILoaderWithInclude<T> Include<T, TInclude>(Expression<Func<T, IEnumerable<string>>> path)
        {
            return new MultiLoaderWithInclude<T>(this).Include<TInclude>(path);
        }

        /// <summary>
        /// Begin a load while including the specified path
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public ILoaderWithInclude<object> Include(string path)
        {
            return new MultiLoaderWithInclude<object>(this).Include(path);
        }
    }
}
