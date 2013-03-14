﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using TypeLite;
using TypeLite.Tests.TestModels;

namespace TypeLite.Tests {
	public class TsGeneratorTests {

		#region Generate tests

		[Fact]
		public void WhenModelContainsReference_ReferenceIsAddedToOutput() {
			var model = new TsModel();
			model.References.Add("knockout.d.ts");

			var target = new TsGenerator();
			var script = target.Generate(model);

			Assert.Contains("/// <reference path=\"knockout.d.ts\" />", script);
		}

		[Fact]
		public void WhenClassIsIgnored_InterfaceForClassIsntGenerated() {
			var builder = new TsModelBuilder();
			builder.Add<Address>();
			var model = builder.Build();
			model.Classes.Single().IsIgnored = true;

			var target = new TsGenerator();
			var script = target.Generate(model);

			Assert.True(string.IsNullOrWhiteSpace(script));
		}

		[Fact]
		public void WhenPropertyIsIgnored_PropertyIsExcludedFromInterface() {
			var builder = new TsModelBuilder();
			builder.Add<Address>();
			var model = builder.Build();
			model.Classes.Single().Properties.Where(p => p.Name == "Street").Single().IsIgnored = true;

			var target = new TsGenerator();
			var script = target.Generate(model);

			Assert.False(script.Contains("Street"));
		}

		#endregion
	}
}