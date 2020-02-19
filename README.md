# WebStorageUtil

This is a helper program for use with Azure storage accounts that are used for hosting static or SPA websites. Sometimes when uploading your files, the wrong content type property can be applied. Use the utility AzureStorageUtil command line application to update the content type for each file.

## Build

This was developed in Visual Studio 2019 with .NET framework 4.8. Might redo it in .NET core at some point.

Just clone, restore packages and build.

## Usage

AzureStorageUtil --verbose -c "$web" --connectionString "[your connection string]"

There is a default.json file which contains a map of extension to mime type. You can override with the --config "[path to new json file]"

## Possible Enhancements

- Verbose setting doesn't really change the level of messages.
- Return a status code of 0 if successful, other values for different errors
- Add upload of files as an option
- Finish the WPF application to do the same operation and also upload files


https://stackoverflow.com/questions/10040403/set-content-type-of-media-files-stored-on-blob
