using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AzureStorageUtil;


namespace AzureStorageUtil.Tests
{
	[TestClass]
	public class MimeTypeTests
	{
		[TestMethod]
		public void TestMethod1()
		{
			string extension = ".js";
			string contentType = "application/javascript";

			MimeType m = new MimeType(extension, contentType);
			Assert.AreEqual<string>(extension, m.Extension, "extension not set properly");
			Assert.AreEqual<string>(contentType, m.Mime, "mime not set properly");
		}
	}
}
