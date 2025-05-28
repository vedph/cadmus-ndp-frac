using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Configuration;

namespace Cadmus.NdpFrac.Parts;

/// <summary>
/// Codicological fragment rulings part.
/// <para>Tag: <c>it.vedph.ndp.cod-fr-rulings</c>.</para>
/// </summary>
[Tag("it.vedph.ndp.cod-fr-rulings")]
public sealed class CodFrRulingsPart : PartBase
{
    /// <summary>
    /// Gets or sets the entries.
    /// </summary>
    public List<CodFrRuling> Rulings { get; set; } = [];

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins: <c>tot-count</c> and a collection of pins.</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new();

        builder.Set("tot", Rulings?.Count ?? 0, false);

        if (Rulings?.Count > 0)
        {
            foreach (CodFrRuling ruling in Rulings)
            {
                // system
                if (!string.IsNullOrEmpty(ruling.System))
                    builder.AddValue("system", ruling.System);

                // type
                if (!string.IsNullOrEmpty(ruling.Type))
                    builder.AddValue("type", ruling.Type);

                // features
                if (ruling.Features?.Count > 0)
                    builder.AddValues("feature", ruling.Features);
            }
        }

        return builder.Build(this);
    }

    /// <summary>
    /// Gets the definitions of data pins used by the implementor.
    /// </summary>
    /// <returns>Data pins definitions.</returns>
    public override IList<DataPinDefinition> GetDataPinDefinitions()
    {
        return new List<DataPinDefinition>(
        [
            new DataPinDefinition(DataPinValueType.Integer,
               "tot-count",
               "The total count of entries."),
            new DataPinDefinition(DataPinValueType.String,
               "system",
               "The ruling systems.",
               "M"),
            new DataPinDefinition(DataPinValueType.String,
               "type",
               "The ruling types.",
               "M"),
            new DataPinDefinition(DataPinValueType.String,
               "feature",
               "The ruling features.",
               "M")
        ]);
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new();

        sb.Append("[CodFrRulings]");

        if (Rulings?.Count > 0)
        {
            sb.Append(' ');
            int n = 0;
            foreach (var entry in Rulings)
            {
                if (++n > 3) break;
                if (n > 1) sb.Append("; ");
                sb.Append(entry);
            }
            if (Rulings.Count > 3)
                sb.Append("...(").Append(Rulings.Count).Append(')');
        }

        return sb.ToString();
    }
}
