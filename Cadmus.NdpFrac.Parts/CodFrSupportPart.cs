﻿using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Configuration;

namespace Cadmus.NdpFrac.Parts;

/// <summary>
/// Codicological fragment material support part.
/// <para>Tag: <c>it.vedph.ndp.cod-fr-support</c>.</para>
/// </summary>
[Tag("it.vedph.ndp.cod-fr-support")]
public sealed class CodFrSupportPart : PartBase
{
    /// <summary>
    /// The material of the support, usually from thesaurus
    /// <c>cod-fr-support-materials</c>.
    /// </summary>
    public string Material { get; set; } = "";

    /// <summary>
    /// A location relative to an ideal rectangular grid overlaid on top of the
    /// surface of the object the fragment belonged to. The location is expressed
    /// as a set of coordinates, like A1, B2, C3, etc.,
    /// see <https://cadmus-bricks.fusi-soft.com/mat/physical-grid> for a demo
    /// in the UI.
    /// </summary>
    public string Location { get; set; } = "";

    /// <summary>
    /// True if the support has a pricking, false if not.
    /// </summary>
    public bool HasPricking { get; set; }

    /// <summary>
    /// The layout formula.
    /// </summary>
    public string Layout { get; set; } = "";

    /// <summary>
    /// The reuse type, usually from thesaurus <c>cod-fr-support-reuse-types</c>.
    /// </summary>
    public string? Reuse { get; set; }

    /// <summary>
    /// The supposed reuse type, usually from thesaurus
    /// <c>cod-fr-support-reuse-types</c>.
    /// </summary>
    public string? SupposedReuse { get; set; }

    /// <summary>
    /// The preservation place, usually from thesaurus <c>cod-fr-support-places</c>.
    /// </summary>
    public string PreservationPlace { get; set; } = "";

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins.</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new();

        // material
        if (!string.IsNullOrEmpty(Material))
            builder.AddValue("material", Material);

        // location
        if (!string.IsNullOrEmpty(Location))
            builder.AddValue("location", Location);

        // has-pricking
        if (HasPricking)
            builder.AddValue("has-pricking", HasPricking);

        // layout
        if (!string.IsNullOrEmpty(Layout))
            builder.AddValue("layout", Layout);

        // reuse
        if (!string.IsNullOrEmpty(Reuse))
            builder.AddValue("reuse", Reuse);

        // preservation place
        if (!string.IsNullOrEmpty(PreservationPlace))
            builder.AddValue("preservation-place", PreservationPlace);

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
            new DataPinDefinition(DataPinValueType.String,
               "material",
               "The fragment support material."),
            new DataPinDefinition(DataPinValueType.String,
               "location",
               "The location of the fragment support on the original object."),
            new DataPinDefinition(DataPinValueType.Boolean,
               "has-pricking",
               "True if the support has a pricking."),
            new DataPinDefinition(DataPinValueType.String,
               "layout",
               "The layout formula."),
            new DataPinDefinition(DataPinValueType.String,
               "reuse",
               "The reuse type."),
            new DataPinDefinition(DataPinValueType.String,
               "preservation-place",
               "The preservation place of the fragment support."),
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

        sb.Append("[CodFrSupport]").Append(' ').Append(Material);
        if (HasPricking) sb.Append('%');

        if (!string.IsNullOrEmpty(Location))
            sb.Append(" (").Append(Location).Append(')');

        return sb.ToString();
    }
}
