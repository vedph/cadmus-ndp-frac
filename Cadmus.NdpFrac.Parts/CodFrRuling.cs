using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmus.NdpFrac.Parts;

/// <summary>
/// Data about ruling in a codicological fragment.
/// </summary>
public class CodFrRuling
{
    /// <summary>
    /// The ruling system. Usually from thesaurus <c>cod-fr-ruling-systems</c>.
    /// </summary>
    public string? System { get; set; }

    /// <summary>
    /// The features of the ruling, like "a secco", "a mina", "a inchiostro", etc.
    /// Usually from thesaurus <c>cod-fr-ruling-features</c>.
    /// </summary>
    public List<string>? Features { get; set; }

    // TODO
}
