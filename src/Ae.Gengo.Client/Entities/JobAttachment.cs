using System.Runtime.Serialization;

namespace Ae.Gengo.Client.Entities
{
    /// <summary>
    /// An external file providing extra context to a job
    /// </summary>
    [DataContract]
    public sealed class JobAttachment
    {
        /// <summary>
        /// Link to an external file providing extra context to a job. Only accepts public URLs with http(s) scheme.
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }
        /// <summary>
        /// The name of the external file to be attached ex| ‘image.jpg’/’video.mp4’/’audio.mpeg’/...
        /// </summary>
        [DataMember(Name = "filename")]
        public string Filename { get; set; }
        /// <summary>
        /// The following mime types will display a preview to the translator: image/bmp|jpg|jpeg|png|gif, video/mp4, audio/mpeg. Other mime types will display a download link to the translator.
        /// </summary>
        [DataMember(Name = "mime_type")]
        public string MimeType { get; set; }
    }
}
