﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Linq.Expressions;
using Nest.Resolvers;

namespace Nest
{
	[JsonObject(MemberSerialization=MemberSerialization.OptIn)]
	public class RangeFilterDescriptor<T> : FilterBase where T : class
	{
		[JsonProperty("from")]
		internal object _From { get; set;}
		[JsonProperty("to")]
		internal object _To { get; set; }
		[JsonProperty("include_lower")]
		internal bool? _FromInclusive { get; set; }
		[JsonProperty("include_upper")]
		internal bool? _ToInclusive { get; set; }

		internal string _Field { get; set; }


		public RangeFilterDescriptor<T> OnField(string field)
		{
			this._Field = field;
			return this;
		}
		public RangeFilterDescriptor<T> OnField(Expression<Func<T, object>> objectPath)
		{
			var fieldName = new PropertyNameResolver().Resolve(objectPath);
			return this.OnField(fieldName);
		}
		/// <summary>
		/// Forces the 'From()' to be exclusive (which is inclusive by default).
		/// </summary>
		public RangeFilterDescriptor<T> FromExclusive()
		{
			this._FromInclusive = false;
			return this;
		}
		/// <summary>
		/// Forces the 'To()' to be exclusive (which is inclusive by default).
		/// </summary>
		public RangeFilterDescriptor<T> ToExclusive()
		{
			this._ToInclusive = false;
			return this;
		}

		#region string 
		/// <summary>
		/// The lower bound. Defaults to start from the first.
		/// </summary>
		/// <returns></returns>
		public RangeFilterDescriptor<T> From(string from)
		{
			this._From = from;
			return this;
		}
		
		/// <summary>
		/// The upper bound. Defaults to unbounded.
		/// </summary>
		public RangeFilterDescriptor<T> To(string to)
		{
			this._To = to;
			return this;
		}
		
		/// <summary>
		/// Same as setting from and include_lower to false.
		/// </summary>
		public RangeFilterDescriptor<T> Greater(string from)
		{
			this._From = from;
			this._FromInclusive = false;
			return this;
		}
		/// <summary>
		/// Same as setting from and include_lower to true.
		/// </summary>
		public RangeFilterDescriptor<T> GreaterOrEquals(string from)
		{
			this._From = from;
			this._FromInclusive = true;
			return this;
		}
		/// <summary>
		/// Same as setting to and include_upper to false.
		/// </summary>
		public RangeFilterDescriptor<T> Lower(string to)
		{
			this._To = to;
			this._ToInclusive = false;
			return this;
		}
		/// <summary>
		/// Same as setting to and to_inclusive to true.
		/// </summary>
		public RangeFilterDescriptor<T> LowerOrEquals(string to)
		{
			this._To = to;
			this._ToInclusive = true;
			return this;
		}
		#endregion

		#region int
		/// <summary>
		/// The lower bound. Defaults to start from the first.
		/// </summary>
		/// <returns></returns>
		public RangeFilterDescriptor<T> From(int from)
		{
			this._From = from;
			return this;
		}

		/// <summary>
		/// The upper bound. Defaults to unbounded.
		/// </summary>
		public RangeFilterDescriptor<T> To(int to)
		{
			this._To = to;
			return this;
		}

		/// <summary>
		/// Same as setting from and include_lower to false.
		/// </summary>
		public RangeFilterDescriptor<T> Greater(int from)
		{
			this._From = from;
			this._FromInclusive = false;
			return this;
		}
		/// <summary>
		/// Same as setting from and include_lower to true.
		/// </summary>
		public RangeFilterDescriptor<T> GreaterOrEquals(int from)
		{
			this._From = from;
			this._FromInclusive = true;
			return this;
		}
		/// <summary>
		/// Same as setting to and include_upper to false.
		/// </summary>
		public RangeFilterDescriptor<T> Lower(int to)
		{
			this._To = to;
			this._ToInclusive = false;
			return this;
		}
		/// <summary>
		/// Same as setting to and include_upper to true.
		/// </summary>
		public RangeFilterDescriptor<T> LowerOrEquals(int to)
		{
			this._To = to;
			this._ToInclusive = true;
			return this;
		}
		#endregion	
	
		#region double
		/// <summary>
		/// The lower bound. Defaults to start from the first.
		/// </summary>
		/// <returns></returns>
		public RangeFilterDescriptor<T> From(double from)
		{
			this._From = from;
			return this;
		}

		/// <summary>
		/// The upper bound. Defaults to unbounded.
		/// </summary>
		public RangeFilterDescriptor<T> To(double to)
		{
			this._To = to;
			return this;
		}

		/// <summary>
		/// Same as setting from and include_lower to false.
		/// </summary>
		public RangeFilterDescriptor<T> Greater(double from)
		{
			this._From = from;
			this._FromInclusive = false;
			return this;
		}
		/// <summary>
		/// Same as setting from and include_lower to true.
		/// </summary>
		public RangeFilterDescriptor<T> GreaterOrEquals(double from)
		{
			this._From = from;
			this._FromInclusive = true;
			return this;
		}
		/// <summary>
		/// Same as setting to and include_upper to false.
		/// </summary>
		public RangeFilterDescriptor<T> Lower(double to)
		{
			this._To = to;
			this._ToInclusive = false;
			return this;
		}
		/// <summary>
		/// Same as setting to and include_upper to true.
		/// </summary>
		public RangeFilterDescriptor<T> LowerOrEquals(double to)
		{
			this._To = to;
			this._ToInclusive = true;
			return this;
		}
		#endregion

		#region DateTime
		/// <summary>
		/// The lower bound. Defaults to start from the first.
		/// </summary>
		/// <returns></returns>
		public RangeFilterDescriptor<T> From(DateTime from, string format = "yyyy-MM-dd'T'HH:mm:ss")
		{
			this._From = from.ToString(format);
			return this;
		}

		/// <summary>
		/// The upper bound. Defaults to unbounded.
		/// </summary>
		public RangeFilterDescriptor<T> To(DateTime to, string format = "yyyy-MM-dd'T'HH:mm:ss")
		{
			this._To = to.ToString(format);
			return this;
		}

		/// <summary>
		/// Same as setting from and include_lower to false.
		/// </summary>
		public RangeFilterDescriptor<T> Greater(DateTime from, string format = "yyyy-MM-dd'T'HH:mm:ss")
		{
			this._From = from.ToString(format);
			this._FromInclusive = false;
			return this;
		}
		/// <summary>
		/// Same as setting from and include_lower to true.
		/// </summary>
		public RangeFilterDescriptor<T> GreaterOrEquals(DateTime from, string format = "yyyy-MM-dd'T'HH:mm:ss")
		{
			this._From = from.ToString(format);
			this._FromInclusive = true;
			return this;
		}
		/// <summary>
		/// Same as setting to and include_upper to false.
		/// </summary>
		public RangeFilterDescriptor<T> Lower(DateTime to, string format = "yyyy-MM-dd'T'HH:mm:ss")
		{
			this._To = to.ToString(format);
			this._ToInclusive = false;
			return this;
		}
		/// <summary>
		/// Same as setting to and include_upper to true.
		/// </summary>
		public RangeFilterDescriptor<T> LowerOrEquals(DateTime to, string format = "yyyy-MM-dd'T'HH:mm:ss")
		{
			this._To = to.ToString(format);
			this._ToInclusive = true;
			return this;
		}
		#endregion
	
	}
}
