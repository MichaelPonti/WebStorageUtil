using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUtil.Services.Settings
{
	class FileSettingsService : ISettingsService
	{
		private string _nominalFilename = null;
		private string _fullFilename = null;


		public FileSettingsService(string nominalFilename = null)
		{
			_nominalFilename = nominalFilename ?? "settings.json";
		}


		public string SettingsDirectory
		{
			get
			{
				if (String.IsNullOrWhiteSpace(_fullFilename))
					return null;

				return Path.GetDirectoryName(_fullFilename);
			}
		}

		public async Task InitializeAsync()
		{
			_fullFilename = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

			_fullFilename = Path.Combine(_fullFilename, "brainbucketsoftware.com");
			if (!Directory.Exists(_fullFilename))
				Directory.CreateDirectory(_fullFilename);

			_fullFilename = Path.Combine(_fullFilename, "storageutil");
			if (!Directory.Exists(_fullFilename))
				Directory.CreateDirectory(_fullFilename);

			_fullFilename = Path.Combine(_fullFilename, _nominalFilename);

			if (!File.Exists(_fullFilename))
				await InitializeFileAsync();
		}

		private async Task InitializeFileAsync()
		{
			SettingsData d = new SettingsData();
			d.FileTypes.Add(new FileSetting(".js", "application/javascript"));
			d.FileTypes.Add(new FileSetting(".png", "image/png"));
			d.FileTypes.Add(new FileSetting(".jpg", "image/jpg"));
			d.FileTypes.Add(new FileSetting(".css", "text/css"));
			d.FileTypes.Add(new FileSetting(".html", "text/html"));
			d.FileTypes.Add(new FileSetting(".htm", "text/html"));
			await SaveSettingsAsync(d);
		}


		public async Task<SettingsData> ReadSettingsAsync()
		{
			if (!File.Exists(_fullFilename))
				return new SettingsData();

			using (StreamReader r = new StreamReader(_fullFilename))
			{
				string s = await r.ReadToEndAsync();
				var ret = JsonConvert.DeserializeObject<SettingsData>(s);
				r.Close();
				return ret;
			}
		}

		public async Task SaveSettingsAsync(SettingsData data)
		{
			try
			{
				using (StreamWriter w = new StreamWriter(_fullFilename, false, Encoding.UTF8))
				{
					string s = JsonConvert.SerializeObject(data);
					await w.WriteAsync(s);
					w.Close();
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.ToString());
			}
		}
	}
}
