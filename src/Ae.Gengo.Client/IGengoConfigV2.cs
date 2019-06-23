namespace Ae.Gengo.Client
{
    /// <summary>
    /// Represents configuration for the Gengo API.
    /// </summary>
    public interface IGengoConfigV2
    {
        /// <summary>
        /// The public key.
        /// </summary>
        string Key { get; }
        /// <summary>
        /// The private (secret) key.
        /// </summary>
        string Secret { get; }
    }
}