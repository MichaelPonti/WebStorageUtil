using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.Services.Azure
{
	public interface IAzureBlobService
	{
		void SetConnectionString(string connectionString);
	}
}
