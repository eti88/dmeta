using CsvHelper;
using Dmeta.Map;
using Dmeta.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Dmeta.Components
{
    public class Processing
    {
        private const string EXE = @"exiftool(-k).exe";
        private const string JSONNAME = "metadata.json";

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Processing()
        {
            if (!File.Exists(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, EXE)))
            {
                logger.Error(string.Format("{0} non trovato, vedi Readme github", EXE));
                throw new FileNotFoundException("exiftool exe not found!");
            }
        }

        public void InjectMetadata(string outputdir, string filename = JSONNAME)
        {
            try
            {
                ProcessStartInfo processinfo = new ProcessStartInfo();
                processinfo.FileName = "exif.bat";
                processinfo.Arguments = string.Format("-charset UTF8 -json={0} -overwrite_original \"{1}\"", filename, outputdir);
                processinfo.RedirectStandardOutput = false;
                processinfo.UseShellExecute = true;
                processinfo.CreateNoWindow = false;
                

                using (Process p = new Process())
                {
                    p.StartInfo = processinfo;
                    p.Start();
                    p.WaitForExit();
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }

        /// <summary>
        /// Genera il file Json Contenente le informazioni per i metadati relativi ad ogni file
        /// </summary>
        /// <param name="backgroundWorker"></param>
        /// <param name="pathcsv"></param>
        /// <param name="pathoutput"></param>
        public bool JsonGeneartion(BackgroundWorker backgroundWorker, string pathcsv, string pathoutput, ref List<string> images)
        {
            List<ItcpMeta> metaImages = new List<ItcpMeta>();
            List<Information> infos = new List<Information>();
            // carica le info basi
            Metadata m = LoadBaseInfo();
            // Associa ad ogni record csv le info di base e inseriscile nella lista
            using (var sr = new StreamReader(pathcsv))
            {
                var reader = new CsvReader(sr);
                reader.Configuration.AllowComments = false;
                reader.Configuration.BufferSize = 4096;
                reader.Configuration.Delimiter = ";";
                reader.Configuration.IgnoreQuotes = true;
                reader.Configuration.RegisterClassMap<InformationMap>();
                infos = reader.GetRecords<Information>().ToList();
            }

            if (infos == null || infos.Count() == 0)
            {
                Console.WriteLine("Caricamento csv fallito");
                return false;
            }

            // Associare path immagini ai records
            for (int x = 0; x < infos.Count; x++)
            {
                for(int z = 0; z < images.Count; z++)
                {
                    if (Path.GetFileNameWithoutExtension(infos[x].Image).Equals(Path.GetFileNameWithoutExtension(images[z])))
                    {
                        infos[x].PathImage = images[z];
                        images.RemoveAt(z);
                        break;
                    }
                }
            }

            // Calcolo la proporzione di incremento
            int dayscan = 1500;
            DateTime date = new DateTime(2017, 06, 30);

            for (int i = 0; i < infos.Count; i++)
            {
                // i % j = data + 1
                // La data di partenza + da inserie nel modello (add)
                // inserire nel modello il valore j cioè ogni quanti documenti incrementare la data (add)
                if (i % dayscan == 0)
                {
                    date.AddDays(1);
                    if (date.DayOfWeek == DayOfWeek.Saturday)
                        date.AddDays(2);
                    else if (date.DayOfWeek == DayOfWeek.Sunday)
                        date.AddDays(1);
                }
                    

                try
                {
                    var merged = new ItcpMeta
                    {
                        SourceFile = infos[i].PathImage,
                        Creator = m.ContactData.Creator,
                        AuthorsPosition = m.ContactData.JobTitle,
                        Headline = m.ContactData.Title,
                        ImageDescription = m.ContactData.Description,
                        Keywords = m.ContactData.Keywords,
                        DescriptionWriter = m.ContactData.Creator,
                        DateCreated = m.ImageData.CreatedAt.ToString("dd/MM/yyyy"),
                        Location = infos[i].Location,
                        City = infos[i].City,
                        State = m.ImageData.City,
                        Country = m.ImageData.Provence,
                        CountryCode = m.ImageData.ISOCounrty,
                        Title = Path.GetFileNameWithoutExtension(infos[i].Image),
                        TransmissionReference = m.ConditionsData.JobIdentifier,
                        Instructions = m.ConditionsData.Instructions,
                        Credit = m.ConditionsData.Provider,
                        Source = infos[i].Origin,
                        Copyrights = m.ConditionsData.Copyright,
                        UsageTerms = m.ConditionsData.UsageTerms
                    };

                    if (merged == null)
                    {
                        logger.Error(infos[i].Image + " created object null");
                        throw new Exception(infos[i].Image + " created object null");
                    }
                        

                    metaImages.Add(merged);
                    if(backgroundWorker != null)
                        backgroundWorker.ReportProgress(i);
                }
                catch (Exception e)
                {
                    logger.Error(e);
                }
            }

            if (metaImages.Count == 0)
            {
                return false;
            }
            File.WriteAllText(Path.Combine(pathoutput, JSONNAME), JsonConvert.SerializeObject(metaImages));
            return true;
        }

        private Metadata LoadBaseInfo()
        {
            return Metadata.LoadModel(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "meta.json"));
        }

        
    }
}
