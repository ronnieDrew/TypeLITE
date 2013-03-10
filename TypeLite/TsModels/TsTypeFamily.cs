﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLite.TsModels {
	/// <summary>
	/// Represents a type of the TsType
	/// </summary>
	internal enum TsTypeFamily {
		/// <summary>
		/// System type
		/// </summary>
		/// <remarks>
		/// e.g. string, int, ...
		/// </remarks>
		System,

		/// <summary>
		/// Collection
		/// </summary>
		Collection,

		/// <summary>
		/// Class
		/// </summary>
		Class,

		/// <summary>
		/// Other type
		/// </summary>
		Type
	}
}
