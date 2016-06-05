using Microsoft.Win32;
using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fantasy_Grounds_Parser_Tool.Zipper
{
    class ZipClass
    {
        public void ZipFiles(XDocument _one, XDocument _two, string _modName, string _destinationPath, string _imagePath = "", bool _useInstalledPath = false,  bool _isDMOnly = false)
        {
            string zipPath = string.Empty;
            string tempPath = string.Empty;

            try
            {
                if (_useInstalledPath)
                {
                    zipPath = GetRegistryPath();
                }

                if (string.IsNullOrEmpty(zipPath))
                {
                    if (!string.IsNullOrEmpty(_destinationPath))
                    {
                        zipPath = _destinationPath;
                    }
                    else
                        zipPath = Environment.CurrentDirectory;
                }

                // Create a temporary dir
                tempPath = GetTempDirectory();

                // Store the XML's in there
                if (_isDMOnly)
                {
                    _one.Save(tempPath + "\\db.xml");
                }
                else
                    _one.Save(tempPath + "\\common.xml");

                _two.Save(tempPath + "\\definition.xml");

                // Store the image if present
                if (!string.IsNullOrEmpty(_imagePath))
                {
                    File.Copy(_imagePath, tempPath + "\\" + Path.GetFileName(@"C:\BaseCode\Fantasy Grounds Parser\Fantasy Grounds Parser Tool\Fantasy Grounds Parser Tool\bin\Debug\thumbnail.png"));
                }
                // Zip them up
                ZipFile.CreateFromDirectory(tempPath, string.Format("{0}\\{1}.mod", Environment.CurrentDirectory, _modName));

                // Copy the end result to the modules file
                File.Copy(string.Format("{0}\\{1}.mod", Environment.CurrentDirectory, _modName), string.Format("{0}\\{1}", zipPath, Path.GetFileName(string.Format("{0}\\{1}.mod", Environment.CurrentDirectory, _modName))), true);

                // Clean up
                Directory.Delete(tempPath, true);
                File.Delete(string.Format("{0}\\{1}.mod", Environment.CurrentDirectory, _modName));
            }
            catch (Exception ex)
            {
                // Do clean up in case of exception
                if (Directory.Exists(tempPath))
                {
                    Directory.Delete(tempPath, true);
                }
                if (File.Exists(string.Format("{0}\\{1}.mod", Environment.CurrentDirectory, _modName)))
                {
                    File.Delete(string.Format("{0}\\{1}.mod", Environment.CurrentDirectory, _modName));
                }
                throw ex;
            }
        }

        private string GetTempDirectory()
        {
            string path = Path.GetRandomFileName();

            Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), path));

            string _actual = Path.Combine(Path.GetTempPath(), path);

            return _actual;
        }

        private string GetRegistryPath()
        {
            string _dataFolder = string.Empty;

            // Installed Directory for FG
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Fantasy Grounds\2.0");

            if (key != null)
            {
                _dataFolder = string.Format("{0}\\modules",key.GetValue("DataDir").ToString());
                return _dataFolder;
            }
            return null;
        }
    }
}
