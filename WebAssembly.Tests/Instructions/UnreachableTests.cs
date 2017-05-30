﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAssembly.Instructions
{
	/// <summary>
	/// Tests the <see cref="Unreachable"/> instruction.
	/// </summary>
	[TestClass]
	public class UnreachableTests
	{
		/// <summary>
		/// Tests compilation and execution of the <see cref="Unreachable"/> instruction.
		/// </summary>
		[TestMethod]
		public void Unreachable_Compiled()
		{
			ExceptionAssert.Expect<Compiled.UnreachableException>(() => AssemblyBuilder.CreateInstance<dynamic>("Test", null, new Unreachable(), new End()).Test());
		}
	}
}