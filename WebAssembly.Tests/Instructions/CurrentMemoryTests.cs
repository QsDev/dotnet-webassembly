﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace WebAssembly.Instructions
{
	/// <summary>
	/// Tests the <see cref="CurrentMemory"/> instruction.
	/// </summary>
	[TestClass]
	public class CurrentMemoryTests
	{
		/// <summary>
		/// Tests compilation and execution of the <see cref="CurrentMemory"/> instruction.
		/// </summary>
		[TestMethod]
		public void CurrentMemory_Compiled()
		{
			var module = new Module();
			module.Types.Add(new Type
			{
				Returns = new[]
				{
					ValueType.Int32,
				},
			});
			module.Functions.Add(new Function
			{
			});
			module.Exports.Add(new Export
			{
				Name = "Test",
			});
			module.Codes.Add(new FunctionBody
			{
				Code = new Instruction[]
				{
					new CurrentMemory(),
					new End(),
				}
			});
			module.Memories.Add(new Memory(1, 1));

			Instance<dynamic> compiled;
			using (var memory = new MemoryStream())
			{
				module.WriteToBinary(memory);
				Assert.AreNotEqual(0, memory.Length);
				memory.Position = 0;

				var maker = Compile.FromBinary<dynamic>(memory);
				Assert.IsNotNull(maker);
				compiled = maker();
			}

			var exports = compiled.Exports;

			Assert.AreEqual<int>(1, exports.Test());
		}
	}
}