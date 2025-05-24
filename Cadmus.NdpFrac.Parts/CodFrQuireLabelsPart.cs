using System;
using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Configuration;

namespace Cadmus.NdpFrac.Parts;

/// <summary>
/// Codicological fragments quire labels for signatures.
/// <para>Tag: <c>it.vedph.ndp.cod-fr-quire-labels</c>.</para>
/// </summary>
[Tag("it.vedph.ndp.cod-fr-quire-labels")]
public sealed class CodFrQuireLabelsPart : PartBase
{
    /// <summary>
    /// Gets or sets the labels.
    /// </summary>
    public List<CodFrQuireLabel> Labels { get; set; } = [];

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins: <c>tot-count</c> and a collection of pins with
    /// these keys: ....</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        // TODO: remove the filter if not using it, or make it a singleton
        // if using it in several components in the same library
        // e.g. using DataPinHelper.DefaultFilter as an argument
        DataPinBuilder builder = new(new StandardDataPinTextFilter());

        builder.Set("tot", Labels?.Count ?? 0, false);

        if (Labels?.Count > 0)
        {
            foreach (CodFrQuireLabel label in Labels)
            {
                // TODO: add values or increase counts like:
                // id unique values if not null:
                // builder.AddValue("id", entry.Id);
                // type-X-count counts if not null, unfiltered:
                // builder.Increase(entry.Type, false, "type-");
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
            // TODO: add pins definitions...
            new DataPinDefinition(DataPinValueType.Integer,
               "tot-count",
               "The total count of entries.")
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

        sb.Append("[CodFrQuireLabels]");

        if (Labels?.Count > 0)
        {
            sb.Append(' ');
            int n = 0;
            foreach (var entry in Labels)
            {
                if (++n > 3) break;
                if (n > 1) sb.Append("; ");
                sb.Append(entry);
            }
            if (Labels.Count > 3)
                sb.Append("...(").Append(Labels.Count).Append(')');
        }

        return sb.ToString();
    }
}