using Ae.Gengo.Client.Entities;
using System;
using System.Diagnostics;

namespace Ae.Gengo.Client
{
    [DebuggerDisplay("{Error.Message,nq}")]
    public sealed class GengoExceptionV2 : Exception
    {
        public GengoExceptionV2()
        {
            // For unit testing
        }

        public GengoExceptionV2(OperationError error)
            : base($"Error from Gengo API: {error?.Message}")
        {
            Error = error;
        }

        public OperationError Error { get; }
    }
}
