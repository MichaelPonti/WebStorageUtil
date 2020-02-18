using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorageUtil.ViewModels;

namespace StorageUtil.Tests
{
	[TestClass]
	public class MimeTypeViewModelTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			string fileType = ".js";
			string mimeType = "application/javascript";

			var item = new MimeTypeItemViewModel(fileType, mimeType);
			Assert.AreEqual<string>(fileType, item.FileExtension, "File extension wrong");
			Assert.AreEqual<string>(mimeType, item.MimeType, "mime wrong");
		}
	}
}
