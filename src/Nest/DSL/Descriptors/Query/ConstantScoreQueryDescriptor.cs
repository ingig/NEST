﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Nest
{
  public class ConstantScoreQueryDescriptor<T>  where T : class
	{
		[JsonProperty(PropertyName = "query")]
		internal QueryDescriptor<T> _Query { get; set; }

		[JsonProperty(PropertyName = "filter")]
		internal FilterDescriptor<T> _Filter { get; set; }

		[JsonProperty(PropertyName = "boost")]
		internal double? _Boost { get; set; }

    public ConstantScoreQueryDescriptor<T> Query(Func<QueryDescriptor<T>, BaseQuery> querySelector)
		{
			querySelector.ThrowIfNull("querySelector");
			this._Filter = null;
			var query = new QueryDescriptor<T>();
			querySelector(query);

			this._Query = query;
			return this;
		}

    public ConstantScoreQueryDescriptor<T> Filter(Func<FilterDescriptor<T>, BaseFilter> filterSelector)
		{
			filterSelector.ThrowIfNull("filterSelector");
			this._Query = null;
			var filter = new FilterDescriptor<T>();
			filterSelector(filter);

			this._Filter = filter;
			return this;
		}

		public ConstantScoreQueryDescriptor<T> Boost(double boost)
		{
			boost.ThrowIfNull("boostFactor");
			this._Boost = boost;
			return this;
		}
	}
}
