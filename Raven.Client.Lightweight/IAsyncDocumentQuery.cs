﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Raven.Abstractions.Data;

namespace Raven.Client
{
	///<summary>
	/// Asynchronous query against a raven index
	///</summary>
	public interface IAsyncDocumentQuery<T> : IDocumentQueryBase<T, IAsyncDocumentQuery<T>>
	{

		/// <summary>
		/// Selects the specified fields directly from the index
		/// </summary>
		/// <typeparam name="TProjection">The type of the projection.</typeparam>
		/// <param name="fields">The fields.</param>
		IAsyncDocumentQuery<TProjection> SelectFields<TProjection>(params string[] fields);

		/// <summary>
		/// Selects all the projection fields directly from the index
		/// </summary>
		/// <typeparam name="TProjection">The type of the projection.</typeparam>
		IAsyncDocumentQuery<TProjection> SelectFields<TProjection>();

		/// <summary>
		/// Gets the query result
		/// Execute the query the first time that this is called.
		/// </summary>
		/// <value>The query result.</value>
		Task<QueryResult> QueryResultAsync { get; }

		/// <summary>
		/// Gets the query result
		/// </summary>
		/// <value>The query result.</value>
		Task<Tuple<QueryResult, IList<T>>> ToListAsync();


		/// <summary>
		/// Create the index query object for this query
		/// </summary>
		IndexQuery GetIndexQuery(bool isAsync);

		IAsyncDocumentQuery<T> Spatial(Expression<Func<T, object>> path, Func<SpatialCriteriaFactory, SpatialCriteria> clause);

		IAsyncDocumentQuery<T> Spatial(string name, Func<SpatialCriteriaFactory, SpatialCriteria> clause);
	}
}