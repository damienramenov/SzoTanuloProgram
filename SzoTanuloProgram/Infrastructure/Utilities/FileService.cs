using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SzoTanuloProgram.Infrastructure.Utilities.Enums;

namespace SzoTanuloProgram
{
    /// <summary>
    /// Ahhoz, hogy megfelelően működjön, minden 'Resources\*' útvonal alatt tárolt fájl át kell, hogy másolódjon a kimeneti könyvtárba!
    /// </summary>
    public static class FileService
    {
        private static readonly string _rootFolder = Application.StartupPath;
        private static readonly string _resourceFolder = $@"{_rootFolder}\Infrastructure\Resources\";

        private static readonly string _imagesFolder = $@"{_resourceFolder}\Images";
        private static readonly string _szojegyzekekFolder = $@"{_resourceFolder}\Szojegyzekek";

        public static string GetSzojegyzekFile(SzojegyzekType e, int unit)
        {
            var displayName = EnumHelper.GetDisplayValue(e);

            return GetFilePathSafely(_szojegyzekekFolder, $@"{displayName}\{displayName}_{unit}.txt");
        }

        public static string GetImageFile(ImageType e, string nameSpecified)
            => GetFilePathSafely(_imagesFolder, $@"{EnumHelper.GetDisplayValue(e)}\{nameSpecified}");

        public static string GetRandomLoaderImageFilePath()
        {
            var filePathsInImagesFolder = Directory.GetFiles($@"{_imagesFolder}\Loader\");

            if (filePathsInImagesFolder != null && filePathsInImagesFolder.Length > 1)
            {
                var randomIndex = new Random().Next(0, filePathsInImagesFolder.Length);

                return filePathsInImagesFolder[randomIndex];
            }

            return string.Empty;
        }

        private static string GetFilePathSafely(string rootPath, string nameWithFileExtension)
        {
            var actualFilePath = Path.Combine(rootPath, nameWithFileExtension);

            if (!File.Exists(actualFilePath))
            {
                return string.Empty;
            }

            return actualFilePath;
        }

        public static string ValidateFilePathAsSzojegyzek(string filePath)
        {
            bool isTxtFile = filePath.Contains(".txt");

            if (!isTxtFile)
            {
                return "Csak '*.txt' kiterjesztésű fájlok tölthetőek be!";
            }

            var sr = new StreamReader(filePath);
            var errorText = string.Empty;
            var readLineCounter = 0;

            while (!sr.EndOfStream)
            {
                readLineCounter++;

                var currentLine = sr.ReadLine();

                var seperator = '|';
                var hasSeperator = currentLine.Contains(seperator);
                if (!hasSeperator)
                {
                    errorText = $"A kiválasztott szöveges fájl ('{filePath}') nem tartalmazza " +
                                $"az elválasztó karaktert ('{seperator}') a(z) '{readLineCounter}'. sorban!";

                    break;
                }

                var splittedLine = currentLine.Split(seperator);
                if (splittedLine.Length != 2)
                {
                    errorText = $"A kiválasztott szöveges fájlon ('{filePath}') belül a(z) '{readLineCounter}'. sorban " +
                                $"nem csak két szó és egy elválasztó karakter található!";
                }
                else if (splittedLine[0].Trim().Length < 1 || splittedLine[1].Trim().Length < 1)
                {
                    errorText = $"A kiválasztott szöveges fájlon ('{filePath}') belül a(z) '{readLineCounter}'. sorban " +
                                $"hiányzik legalább az egyik kifejezés!";
                }
            }

            return errorText;
        }

        public static string GetSzojegyzekFilePathFromButtonName(Button button)
        {
            var buttonName = button.Name;

            var szojegyzekSzama = int.Parse(new string(buttonName.Where(c => char.IsDigit(c)).ToArray()));

            SzojegyzekType szojegyzekType;

            if (buttonName.StartsWith("btnElementary"))
            {
                szojegyzekType = SzojegyzekType.Elementary;
            }
            else if (buttonName.StartsWith("btnIntermedate"))
            {
                szojegyzekType = SzojegyzekType.Intermediate;
            }
            else if (buttonName.StartsWith("btnPreIntermediate"))
            {
                szojegyzekType = SzojegyzekType.PreIntermediate;
            }
            else
            {
                szojegyzekType = SzojegyzekType.Proficiency;
            }

            return GetSzojegyzekFile(szojegyzekType, szojegyzekSzama);
        }
    }
}
