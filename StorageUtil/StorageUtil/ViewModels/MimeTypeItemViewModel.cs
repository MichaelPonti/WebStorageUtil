using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.ViewModels
{
	public class MimeTypeItemViewModel : BaseItemViewModel
	{
		public MimeTypeItemViewModel()
		{
		}

		public MimeTypeItemViewModel(string fileExtension, string mimeType)
		{
			_fileExtension = fileExtension;
			_mimeType = mimeType;
		}


		private string _fileExtension = null;
		public string FileExtension
		{
			get => _fileExtension;
			set => SetProperty<string>(ref _fileExtension, value);
		}


		private string _mimeType = null;
		public string MimeType
		{
			get => _mimeType;
			set => SetProperty<string>(ref _mimeType, value);
		}
	}
}
