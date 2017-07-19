using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmeta.Models
{
    /// <summary>
    /// Modelli di metadati per ExifTool
    /// </summary>
    public class ItcpMeta
    {
        [JsonProperty("SourceFile")]
        public string SourceFile { get; set; }

        [JsonProperty("Creator")]
        public string Creator { get; set; }

        [JsonProperty("AuthorsPosition")]
        public string AuthorsPosition { get; set; }

        [JsonProperty("Headline")]
        public string Headline { get; set; }

        [JsonProperty("ImageDescription")]
        public string ImageDescription { get; set; }

        [JsonProperty("Keywords")]
        public string Keywords { get; set; }

        [JsonProperty("Writer-Editor")]
        public string DescriptionWriter { get; set; }

        [JsonProperty("DateCreated")]
        public string DateCreated { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("TransmissionReference")]
        public string TransmissionReference { get; set; }

        [JsonProperty("Instructions")]
        public string Instructions { get; set; }

        [JsonProperty("Credit")]
        public string Credit { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("Copyright")]
        public string Copyrights { get; set; }

        [JsonProperty("UsageTerms")]
        public string UsageTerms { get; set; }

        [JsonProperty("CodedCharacterSet")]
        public string CodedCharacterSet { get { return "UTF8"; } }

        [JsonProperty("FileCreateDate")]
        public string FileCreateDate { get { return DateCreated + " 00:00:00+00:00"; } }

        [JsonProperty("CreateDate")]
        public string CreateDate { get { return DateCreated + " 00:00:00+00:00"; } }

        [JsonProperty("MetadataDate")]
        public string MetadataDate { get { return DateCreated + " 00:00:00+00:00"; } }
    }
}
